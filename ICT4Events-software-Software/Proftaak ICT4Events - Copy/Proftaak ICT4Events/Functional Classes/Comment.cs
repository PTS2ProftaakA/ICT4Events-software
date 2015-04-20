using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    public class Comment : IDatabase<Comment>
    {
        private string filePath;
        private string content;
        private string RFID;

        private int commentID;
        private int commentedOnID;

        private List<Rating> ratings;

        #region properties
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
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

        public Comment(int commentID, int commentedOnID, string filePath, string content, string RFID)
        {
            this.CommentID = commentID;
            this.commentedOnID = commentedOnID;
            this.FilePath = filePath;
            this.Content = content;
            this.RFID = RFID;

            ratings = new List<Rating>();
        }

        public static List<Comment> GetAllFromFile(string filePath, Database database)
        {
            List<string> commentColumns = new List<string>();
            List<Comment> allComments = new List<Comment>();

            commentColumns.Add("REACTIEID");
            commentColumns.Add("BESTANDSLOCATIE");
            commentColumns.Add("RFID");
            commentColumns.Add("REACTIEOPID");
            commentColumns.Add("INHOUD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM REACTIE WHERE BESTANDSLOCATIE = " + filePath, commentColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allComments.Add(new Comment(
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i]),
                        dataTable[1][i],
                        dataTable[4][i],
                        dataTable[2][i]));
                }
            }

            return allComments;
        }

        public static List<Comment> GetAllFromUser(string RFID, Database database)
        {
            List<string> commentColumns = new List<string>();
            List<Comment> allComments = new List<Comment>();

            commentColumns.Add("REACTIEID");
            commentColumns.Add("BESTANDSLOCATIE");
            commentColumns.Add("RFID");
            commentColumns.Add("REACTIEOPID");
            commentColumns.Add("INHOUD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM REACTIE WHERE RFID = " + RFID, commentColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allComments.Add(new Comment(
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i]),
                        dataTable[1][i],
                        dataTable[4][i],
                        dataTable[2][i]));
                }
            }

            return allComments;
        }

        public Comment Get(string commentID, Database database)
        {
            List<string> commentColumns = new List<string>();
            Comment getComment = null;

            commentColumns.Add("REACTIEID");
            commentColumns.Add("BESTANDSLOCATIE");
            commentColumns.Add("RFID");
            commentColumns.Add("REACTIEOPID");
            commentColumns.Add("INHOUD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM REACTIE WHERE REACTIEID = " + commentID, commentColumns);

            if (dataTable[0].Count() > 1)
            {
                getComment = new Comment(
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[3][1]),
                    dataTable[1][1],
                    dataTable[4][1],
                    dataTable[2][1]);
            }
            return getComment;
        }

        public void Add(Comment newComment, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO REACTIE VALUES ({0}, '{1}', '{2}', {3}, '{4}')",
                newComment.commentID, newComment.filePath, newComment.RFID, newComment.commentedOnID, newComment.content));
        }

        public void Edit(Comment updateComment, Database database)
        {
            database.editDatabase(String.Format("UPDATE REACTIE SET INHOUD = '{0}' WHERE REACTIEID = '{1}'",
                updateComment.content, updateComment.commentID));

        }

        public void Remove(Comment removeComment, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM REACTIE WHERE REACTIEID = '{0}'",
                removeComment.commentID));
        }
    }
}
