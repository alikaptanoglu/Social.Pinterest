using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social.Pinterest
{
    class Query
    {
        public IEnumerable<Pinterest> Get_Type_Image_Is_Not_Pin()
        {
            MoneyDataContext context = new MoneyDataContext();
            var query = (from pin in context.Pinterests
                         where pin.Is_Pin == 0 && pin.Type == 2
                         select pin)
                         .Take(1000)
                         .OrderBy(c => c.Id);
            return query;
        }

        public IEnumerable<Pinterest> Get_Type_Product_Is_Not_Pin()
        {
            MoneyDataContext context = new MoneyDataContext();
            var query = (from pin in context.Pinterests
                         where pin.Is_Pin == 0 && pin.Type == 1
                         select pin)
                          .Take(1000)
                          .OrderBy(c => c.Id);
            return query;
        }

        public Pinterest Find_Pin_By_Id(string id)
        {
            MoneyDataContext context = new MoneyDataContext();
            var query = (from pin in context.Pinterests
                        where pin.Old_Id == id
                        select pin).FirstOrDefault();
            return query;
        }

        public IEnumerable<ReachBoardPinterest> Get_Reach_Board()
        {
            MoneyDataContext context = new MoneyDataContext();
            var query = from pin in context.ReachBoardPinterests
                        where pin.IsLoad == 0
                        select pin;
            return query;
        }

        public bool Insert_Pin(DataLoad data)
        {
            bool result = false;
            try
            {
                MoneyDataContext db = new MoneyDataContext();
                Pinterest pin = new Pinterest
                {
                    Old_Id = data.OldId,
                    Board = data.Board,
                    Backlink = data.Backlink,
                    Note = data.Note,
                    Image_Url = data.Image_Url,
                    Type = data.Type,
                    Is_Pin = 0,
                    Created_Date = DateTime.Now
                };
                db.Pinterests.InsertOnSubmit(pin);
                db.SubmitChanges();
                result = true;
            }
            catch (Exception ex) { }
            return result;
        }

        public void Update_Pin(int id, string pin_id)
        {
            try
            {
                MoneyDataContext db = new MoneyDataContext();
                Pinterest prod = (from p in db.Pinterests
                                where p.Id == id
                                select p).SingleOrDefault();
                prod.PinId = pin_id;
                prod.Is_Pin = 1;
                prod.Update_Date = DateTime.Now;
                db.SubmitChanges();
            }
            catch (Exception ex) { }
        }

        public void Update_Board(int id)
        {
            try
            {
                MoneyDataContext db = new MoneyDataContext();
                ReachBoardPinterest prod = (from p in db.ReachBoardPinterests
                                  where p.Id == id
                                  select p).SingleOrDefault();
                prod.IsLoad = 1;
                db.SubmitChanges();
            }
            catch (Exception ex) { }
        }
    }
}
