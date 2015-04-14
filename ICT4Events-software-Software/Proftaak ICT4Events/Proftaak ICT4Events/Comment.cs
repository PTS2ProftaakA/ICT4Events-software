using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class Comment : IDatabase
    {
        private string filePath;
        private string content;
        private string RFID;

        private int commentID;

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
        public List<Rating> Ratings
        {
            get { return ratings; }
            set { ratings = value; }
        }
        #endregion

        public Comment(int commentID, string filePath, string content, string RFID)
        {
            this.CommentID = commentID;
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
            commentColumns.Add("INHOUD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM REACTIE WHERE BESTANDSLOCATIE = " + filePath, commentColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {


                    allComments.Add(new Comment(
                        Convert.ToInt32(dataTable[0][i]),
                        dataTable[1][i],
                        dataTable[3][i],
                        dataTable[2][i]));
                }
            }

            return allComments;
        }
        public List<Comment> GetAllFromUser(string RFID)
        {
            return null;
        }

        public Type Get(string commentID)
        {
            return null;
        }

        public void Add(Type comment)
        {

        }

        public void Edit(Type comment)
        {

        }

        public void Remove(Type comment)
        {

        }
    }
}
