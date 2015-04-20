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

        public Rating(string RFID, string FilePath, int RatingID, int CommentID, bool Positive)
        {
            this.RatingID = RatingID;
            this.RFID = RFID;
            this.FilePath = FilePath;
            this.CommentID = CommentID;
        }

        public List<Rating> getAllFromFile(string filePath, Database database)
        {
            List<string> ratingColumns = new List<string>();
            List<Rating> allRating = new List<Rating>();

            ratingColumns.Add("OORDEELID");
            ratingColumns.Add("RFID");
            ratingColumns.Add("BESTANDLOCATIE");
            ratingColumns.Add("REACTIEID");
            ratingColumns.Add("POSITIEF");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  RATING WHERE BESTANDLOCATIE = " + filePath, ratingColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allRating.Add(new Rating(
                        dataTable[1][i],
                        dataTable[2][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i]),
                        Convert.ToBoolean(dataTable[4][i])
                        ));
                }
            }

            return allRating;
        }

        public List<Rating> getAllFromUser(string RFID, Database database)
        {
            List<string> ratingColumns = new List<string>();
            List<Rating> allRating = new List<Rating>();

            ratingColumns.Add("OORDEELID");
            ratingColumns.Add("RFID");
            ratingColumns.Add("BESTANDLOCATIE");
            ratingColumns.Add("REACTIEID");
            ratingColumns.Add("POSITIEF");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  RATING WHERE RFID = " + RFID, ratingColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allRating.Add(new Rating(
                        dataTable[1][i],
                        dataTable[2][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i]),
                        Convert.ToBoolean(dataTable[4][i])
                        ));
                }
            }

            return allRating;
        }

        public Rating Get(string ratingID, Database database)
        {
            List<string> ratingColumns = new List<string>();
            Rating getRating = null;

            ratingColumns.Add("OORDEELID");
            ratingColumns.Add("RFID");
            ratingColumns.Add("BESTANDLOCATIE");
            ratingColumns.Add("REACTIEID");
            ratingColumns.Add("POSITIEF");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  RATING WHERE RFID = " + RFID, ratingColumns);

            if (dataTable[0].Count() > 1)
            {
                     getRating = new Rating(
                        dataTable[1][1],
                        dataTable[2][1],
                        Convert.ToInt32(dataTable[0][1]),
                        Convert.ToInt32(dataTable[3][1]),
                        Convert.ToBoolean(dataTable[4][1]));
            }

            return getRating;
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
