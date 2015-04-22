using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public class Rating : IDatabase<Rating>
    {
        //Fields
        private string filePath;

        private int userID;
        private int ratingID;
        private int commentID;

        private bool positive;

        //Properties
        #region properties
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
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

        //Constructor that creates a rating that belongs to a mediafile
        public Rating(string filePath, int userID, int ratingID, int commentID, bool positive)
        {
            this.filePath = FilePath;
            this.userID = userID;
            this.ratingID = RatingID;
            this.commentID = CommentID;
            this.positive = positive;
        }

        //A function that returns all the ratings that correspond to a single mediafile
        //The data is constructed and a list is created
        public static List<Rating> getAllFromFile(string filePath, Database database)
        {
            List<string> ratingColumns = new List<string>();
            List<Rating> allRating = new List<Rating>();

            ratingColumns.Add("OORDEELID");
            ratingColumns.Add("GEBRUIKERID");
            ratingColumns.Add("BESTANDLOCATIE");
            ratingColumns.Add("REACTIEID");
            ratingColumns.Add("POSITIEF");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  OORDEEL WHERE BESTANDLOCATIE = '" + filePath + "'", ratingColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    if(dataTable[2][i] != "")
                    {
                        dataTable[3][i] = "-1";
                    }

                    allRating.Add(new Rating(
                        dataTable[2][i],
                        Convert.ToInt32(dataTable[1][i]), 
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i]),
                        dataTable[4][i] == "Y"
                        ));
                }
            }

            return allRating;
        }

        //A function that returns all the ratings that correspond to a single user
        //The data is constructed and a list is created
        public static List<Rating> getAllFromUser(string RFID, Database database)
        {
            List<string> ratingColumns = new List<string>();
            List<Rating> allRating = new List<Rating>();

            ratingColumns.Add("OORDEELID");
            ratingColumns.Add("GEBRUIKERID");
            ratingColumns.Add("BESTANDLOCATIE");
            ratingColumns.Add("REACTIEID");
            ratingColumns.Add("POSITIEF");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  OORDEEL WHERE RFID = " + RFID, ratingColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    if (dataTable[2][i] != "")
                    {
                        dataTable[3][i] = "-1";
                    }

                    allRating.Add(new Rating(
                        dataTable[2][i],
                        Convert.ToInt32(dataTable[1][i]),
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i]),
                        dataTable[4][i] == "Y"
                        ));
                }
            }

            return allRating;
        }

        //A function that returns all the ratings that correspond to a single comment
        //The data is constructed and a list is created
        public static List<Rating> getAllFromComment(int commentID, Database database)
        {
            List<string> ratingColumns = new List<string>();
            List<Rating> allRating = new List<Rating>();

            ratingColumns.Add("OORDEELID");
            ratingColumns.Add("GEBRUIKERID");
            ratingColumns.Add("BESTANDLOCATIE");
            ratingColumns.Add("REACTIEID");
            ratingColumns.Add("POSITIEF");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  OORDEEL WHERE REACTIEID = " + commentID, ratingColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    if (dataTable[2][i] != "")
                    {
                        dataTable[3][i] = "-1";
                    }

                    allRating.Add(new Rating(
                        dataTable[2][i],
                        Convert.ToInt32(dataTable[1][i]),
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i]),
                        dataTable[4][i] == "Y"
                        ));
                }
            }

            return allRating;
        }

        //Returns a single rating that corresponds to the ratingID
        public Rating Get(string ratingID, Database database)
        {
            List<string> ratingColumns = new List<string>();
            Rating getRating = null;

            ratingColumns.Add("OORDEELID");
            ratingColumns.Add("GEBRUIKERID");
            ratingColumns.Add("BESTANDLOCATIE");
            ratingColumns.Add("REACTIEID");
            ratingColumns.Add("POSITIEF");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  OORDEEL WHERE GEBRUIKERID = " + userID, ratingColumns);

            if (dataTable[0].Count() > 1)
            {
                if (dataTable[2][1] != "")
                {
                    dataTable[3][1] = "-1";
                }

                getRating = new Rating(
                    dataTable[2][1],
                    Convert.ToInt32(dataTable[1][1]), 
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[3][1]),
                    dataTable[4][1] == "Y"
                    );
            }

            return getRating;
        }

        //Adds a rating to the database
        public void Add(Rating newRating, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO OORDEEL VALUES ({0}, {1}, '{2}', '{3}', '{4}')",
                newRating.ratingID, newRating.userID, newRating.filePath, newRating.commentID, newRating.positive));
        }

        //Edits a rating with the current values of the rating
        public void Edit(Rating updateRating, Database database)
        {
            database.editDatabase(String.Format("UPDATE OORDEEL SET POSITIEF = '{0}' WHERE OORDEELID = {1}",
                updateRating.positive, updateRating.ratingID));

        }

        //Remove rating that corresponds to the input rating
        public void Remove(Rating removeRating, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM OORDEEL WHERE OORDEELID = {0}",
                removeRating.ratingID));
        }
    }
}
