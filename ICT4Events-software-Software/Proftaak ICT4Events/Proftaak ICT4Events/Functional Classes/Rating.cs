using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class Rating : IDatabase<Rating>
    {
        private string RFID;
        private string filePath;

        private int ratingID;
        private int commentID;

        private bool positive;

        #region properties
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
        #endregion

        public Rating(int RatingID, string RFID, string FilePath, int CommentID, bool Positive)
        {
            this.RatingID = RatingID;
            this.RFID = RFID;
            this.FilePath = FilePath;
            this.CommentID = CommentID;
        }

        public List<Rating> getAllFromFile(string filePath)
        {
            return null;
        }

        public List<Rating> getAllFromUser(string RFID)
        {
            return null;
        }

        public Rating Get(string ratingID, Database database)
        {
            return null;
        }

        public void Add(Rating newRating, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO OORDEEL VALUES ({0}, '{1}', '{2}', '{3}', '{4}')",
                newRating.ratingID, newRating.RFID, newRating.filePath, newRating.commentID, newRating.positive));
        }

        public void Edit(Rating updateRating, Database database)
        {
            database.editDatabase(String.Format("UPDATE OORDEEL SET POSITIEF = '{0}' WHERE OORDEELID = {1}",
                updateRating.positive, updateRating.ratingID));

        }

        public void Remove(Rating removeRating, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM OORDEEL WHERE OORDEELID = {0}",
                removeRating.ratingID));
        }
    }
}
