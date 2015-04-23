using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    public class Comment : IDatabase<Comment>
    {
        //Fields
        private string filePath;
        private string content;

        private int userID;
        private int commentID;
        private int commentedOnID;

        private List<Rating> ratings;

        //Properties
        #region properties
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int CommentID
        {
            get { return commentID; }
            set { commentID = value; }
        }
        public int CommentedOnID
        {
            get { return commentedOnID; }
            set { commentedOnID = value; }
        }
        public List<Rating> Ratings
        {
            get { return ratings; }
            set { ratings = value; }
        }
        #endregion

        //Constructor for the Comment class
        public Comment(string filePath, string content, int userID, int commentID, int commentedOnID)
        {
            this.filePath = filePath;
            this.content = content;
            this.userID = userID;
            this.commentID = commentID;
            this.commentedOnID = commentedOnID;

            ratings = new List<Rating>();
        }

        //A function to get all the comments from a single mediafile
        //The data from the database gets converted to a list of comments
        public static List<Comment> GetAllFromFile(string filePath, Database database)
        {
            List<string> commentColumns = new List<string>();
            List<Comment> allComments = new List<Comment>();

            commentColumns.Add("REACTIEID");
            commentColumns.Add("BESTANDLOCATIE");
            commentColumns.Add("GEBRUIKERID");
            commentColumns.Add("REACTIEOPID");
            commentColumns.Add("INHOUD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM REACTIE WHERE BESTANDSLOCATIE = " + filePath, commentColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    if (dataTable[3][i] == "")
                    {
                        dataTable[3][i] = "-1";
                    }

                    allComments.Add(new Comment(
                        dataTable[1][i],
                        dataTable[4][i],
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i])
                        ));
                }
            }

            return allComments;
        }

        //A function to get all the comments from a single user
        //The data from the database gets converted to a list of comments
        public static List<Comment> GetAllFromUser(int userID, Database database)
        {
            List<string> commentColumns = new List<string>();
            List<Comment> allComments = new List<Comment>();

            commentColumns.Add("REACTIEID");
            commentColumns.Add("BESTANDLOCATIE");
            commentColumns.Add("GEBRUIKERID");
            commentColumns.Add("REACTIEOPID");
            commentColumns.Add("INHOUD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM REACTIE WHERE GEBRUIKERID = " + userID, commentColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    if (dataTable[3][i] == "")
                    {
                        dataTable[3][i] = "-1";
                    }

                    allComments.Add(new Comment(
                        dataTable[1][i],
                        dataTable[4][i],
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i])
                        ));
                }
            }

            return allComments;
        }

        //A function to get all the reported comments of an event
        public static List<Comment> GetReportedComments(int percentage, int eventID, Database database)
        {
            List<string> commentColumns = new List<string>();
            List<Comment> allComments = new List<Comment>();

            commentColumns.Add("REACTIEID");
            commentColumns.Add("BESTANDLOCATIE");
            commentColumns.Add("GEBRUIKERID");
            commentColumns.Add("REACTIEOPID");
            commentColumns.Add("INHOUD");

            List<string>[] dataTable = database.selectQuery("SELECT r1.REACTIEID, r1.BESTANDLOCATIE, r1.GEBRUIKERID, r1.REACTIEOPID, r1.INHOUD FROM REACTIE r1, MEDIABESTAND m1 WHERE r1.bestandlocatie = m1.bestandlocatie AND m1.EVENEMENTID = " + eventID + " AND (SELECT COUNT(*) FROM OORDEEL o1 WHERE o1.reactieID = r1.reactieID AND o1.positief = 'N') > 0 AND (SELECT COUNT(*) FROM OORDEEL o1 WHERE o1.reactieID = r1.reactieID AND o1.positief = 'N') / (SELECT COUNT(*) FROM OORDEEL o2 WHERE o2.reactieID = r1.reactieID) * 100 >=" + percentage, commentColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    if (dataTable[3][i] == "")
                    {
                        dataTable[3][i] = "-1";
                    }

                    allComments.Add(new Comment(
                        dataTable[1][i],
                        dataTable[4][i],
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i])
                        ));
                }
            }

            return allComments;
        }

        //Gets a single comment based on the filepath of the comment but more accesible
        public static Comment GetStatic(string filePath, Database database)
        {
            List<string> commentColumns = new List<string>();
            Comment getComment = null;

            commentColumns.Add("REACTIEID");
            commentColumns.Add("BESTANDLOCATIE");
            commentColumns.Add("GEBRUIKERID");
            commentColumns.Add("REACTIEOPID");
            commentColumns.Add("INHOUD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM REACTIE WHERE BESTANDLOCATIE = '" + filePath + "'", commentColumns);

            if (dataTable[0].Count() > 1)
            {
                if (dataTable[1][1] != "")
                {
                    dataTable[3][1] = "-1";
                }

                getComment = new Comment(
                    dataTable[1][1],
                    dataTable[4][1],
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[3][1])
                    );
            }
            return getComment;
        }

        //Gets a single comment based on the ID of the comment but more accesible
        public static Comment GetStatic(int commentID, Database database)
        {
            List<string> commentColumns = new List<string>();
            Comment getComment = null;

            commentColumns.Add("REACTIEID");
            commentColumns.Add("BESTANDLOCATIE");
            commentColumns.Add("GEBRUIKERID");
            commentColumns.Add("REACTIEOPID");
            commentColumns.Add("INHOUD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM REACTIE WHERE REACTIEID = " + commentID, commentColumns);

            if (dataTable[0].Count() > 1)
            {
                if (dataTable[1][1] != "")
                {
                    dataTable[3][1] = "-1";
                }

                getComment = new Comment(
                    dataTable[1][1],
                    dataTable[4][1],
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[3][1])
                    );
            }
            return getComment;
        }

        //Gets a single comment based on the ID of the comment
        public Comment Get(string commentID, Database database)
        {
            List<string> commentColumns = new List<string>();
            Comment getComment = null;

            commentColumns.Add("REACTIEID");
            commentColumns.Add("BESTANDLOCATIE");
            commentColumns.Add("GEBRUIKERID");
            commentColumns.Add("REACTIEOPID");
            commentColumns.Add("INHOUD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM REACTIE WHERE REACTIEID = " + commentID, commentColumns);

            if (dataTable[0].Count() > 1)
            {
                if (dataTable[1][1] != "")
                {
                    dataTable[3][1] = "-1";
                }

                getComment = new Comment(
                    dataTable[1][1],
                    dataTable[4][1],
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToInt32(dataTable[3][1]),
                    Convert.ToInt32(dataTable[0][1])
                    );
            }
            return getComment;
        }


        //The database is called to add a single comment
        public void Add(Comment newComment, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO REACTIE VALUES ({0}, '{1}', {2}, {3}, '{4}')",
                newComment.commentID, newComment.filePath, newComment.userID, newComment.commentedOnID, newComment.content));
        }

        //The database edits a comment to its current values
        public void Edit(Comment updateComment, Database database)
        {
            database.editDatabase(String.Format("UPDATE REACTIE SET INHOUD = '{0}' WHERE REACTIEID = {1}",
                updateComment.content, updateComment.commentID));

        }

        //The database removes the comment that this one represents
        public void Remove(Comment removeComment, Database database)
        {
            if (removeComment.commentID != -1)
            {
                database.editDatabase(String.Format("DELETE FROM REACTIE WHERE REACTIEID = {0}",
                    removeComment.commentID));
            }
            else
            {
                database.editDatabase(String.Format("DELETE FROM REACTIE WHERE BESTANDLOCATIE = '{0}'",
                    removeComment.filePath));
            }
        }
    }
}
