using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social.Pinterest
{
    class Execute
    {
        public void ReadBoard()
        {
            Query query = new Query();
            var boards = query.Get_Reach_Board();
            if (boards != null)
            {
                foreach(var board in boards)
                {
                    LoadData(board.Board, board.Category);
                    query.Update_Board(board.Id);
                }
            }
        }

        public void PinToPinterest()
        {
            Query query = new Query();
            var products = query.Get_Type_Image_Is_Not_Pin().ToArray();
            var images = query.Get_Type_Image_Is_Not_Pin().ToArray();

            List<DataLoad> datas = new List<DataLoad>();
            DataLoad call = new DataLoad();
            for(int i = 0; i < 980; i++ ){
                if (images.Count() >= i)
                    datas.Add(call.ImportDataToDataLoad(images[i], 2));
                else if (products.Count() >= i)
                    datas.Add(call.ImportDataToDataLoad(products[i], 1));
                else
                    break;
            }
            if (datas != null)
            {
                foreach (var data in datas)
                {
                    PinHub hub = new PinHub();
                    var jsonPost = hub.Pin(data.Board, data.Note, data.Image_Url, data.Backlink, data.Type);
                    if (jsonPost != null)
                    {
                        JObject jsonObj = new JObject(JObject.Parse(jsonPost));
                        query.Update_Pin(data.Id, jsonObj["data"]["id"].ToString());
                    }
                }
            }
        }
        
        private int CountPinsBoard(string board)
        {
            int count = 0;
            string url = "https://api.pinterest.com/v3/pidgets/boards/" + board + "/pins/";
            CallApi call = new CallApi();
            var json = call.Get(url);
            if (json != null)
            {
                JObject jsonObj = new JObject(JObject.Parse(json)) ;
                var jsonBoard = jsonObj["data"]["board"];
                if (!IsNullOrEmpty(jsonBoard))
                {
                    count = Int32.Parse(jsonBoard["pin_count"].ToString());
                }
            }
            return count;
        }

        public void LoadData(string board, string category)
        {
            string url = "https://api.pinterest.com/v1/boards/" + board + "/pins/?access_token=Ab1rhweqeChC5tmKgfILFrE6t-TYFNwv7w_soZhELMu2AwBCWQAAAAA&fields=id,note,image";
            int total_pins = CountPinsBoard(board);
            for (int i = 0; i <= (total_pins / 25); i++)
            {
                CallApi call = new CallApi();
                var json = call.Get(url);
                if (json != null)
                {
                    JObject pinObj = new JObject(JObject.Parse(json));
                    var pins = pinObj["data"];
                    if (!IsNullOrEmpty(pins))
                        Parse_Data(pins, category);
                    var next = pinObj["page"]["next"];
                    if (!IsNullOrEmpty(next))
                        url = next.ToString();
                    else
                        break;
                }
            }
        }
        private void Parse_Data(dynamic data, string board)
        {
            Query query = new Query();
            foreach (var pin in data)
            {
                var exits = query.Find_Pin_By_Id(pin["id"].ToString());
                if (exits == null) { 
                    DataLoad load = new DataLoad();
                    load.OldId = pin["id"].ToString();
                    load.Board = board;
                    load.Image_Url = pin["image"]["original"]["url"].ToString();
                    load.Note = pin["note"].ToString();
                    load.Type = 2;
                    load.Backlink = "https://www.besttshirtusa.com/" + board;
                    query.Insert_Pin(load);
                }
            }
        }

        private bool IsNullOrEmpty(JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                   (token.Type == JTokenType.Null);
        }
    }
}
