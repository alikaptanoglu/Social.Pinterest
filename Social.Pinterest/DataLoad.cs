using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social.Pinterest
{
    class DataLoad
    {
        private int id;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string pin_id;
        public string PinId
        {
            get
            {
                return this.pin_id;
            }
            set
            {
                this.pin_id = value;
            }
        }

        private string old_id;
        public string OldId
        {
            get
            {
                return this.old_id;
            }
            set
            {
                this.old_id = value;
            }
        }

        private string board;
        public string Board
        {
            get
            {
                return this.board;
            }
            set
            {
                this.board = value;
            }
        }

        private string backlink;
        public string Backlink
        {
            get
            {
                return this.backlink;
            }
            set
            {
                this.backlink = value;
            }
        }

        private string note;
        public string Note
        {
            get
            {
                return this.note;
            }
            set
            {
                this.note = value;
            }
        }

        private string image_url;
        public string Image_Url
        {
            get
            {
                return this.image_url;
            }
            set
            {
                this.image_url = value;
            }
        }

        private int type;
        public int Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        private int is_pin;
        public int Is_Pin
        {
            get
            {
                return this.is_pin;
            }
            set
            {
                this.is_pin = value;
            }
        }

        private DateTime created_date;
        public DateTime Created_Date
        {
            get
            {
                return this.created_date;
            }
            set
            {
                this.created_date = value;
            }
        }

        private DateTime update_date;
        public DateTime Update_Date
        {
            get
            {
                return this.update_date;
            }
            set
            {
                this.update_date = value;
            }
        }

        public DataLoad ImportDataToDataLoad(Pinterest pinterest, int type)
        {
            DataLoad data = new DataLoad();
            data.Id = pinterest.Id;
            data.Backlink = pinterest.Backlink;
            data.Board = pinterest.Board;
            data.Image_Url = pinterest.Image_Url;
            data.Note = pinterest.Note;
            data.Type = type;
            return data;
        }
    }
}
