﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class Rating
    {
        private string RFID;
        private string filePath;

        private int ratingID;
        private int commentID;

        private bool positive;

        public string propertyRFID
        {
            get { return RFID; }
            set { RFID = value; }
        }
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        public int RatingID
        {
            get { return ratingID; }
            set { ratingID = value; }
        }
        public int CommentID
        {
            get { return commentID; }
            set { commentID = value; }
        }
        public bool Positive
        {
            get { return positive; }
            set { positive = value; }
        }

        public Rating(int RatingID, string RFID, string FilePath, int CommentID, bool Positive)
        {
            this.RatingID = RatingID;
            this.RFID = RFID;
            this.FilePath = FilePath;
            this.CommentID = CommentID;
        }

        public List<Rating> getAll(string filePath)
        {
            return null;
        }

        public List<Rating> getAll(string RFID)
        {
            return null;
        }
    }
}
