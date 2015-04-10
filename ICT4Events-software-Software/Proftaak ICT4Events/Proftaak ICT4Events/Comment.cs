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

        private int commentID;

        private List<Rating> ratings;
        private User user;

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

        public Comment(int commentID, string filePath, string content, User user)
        {
            this.CommentID = commentID;
            this.FilePath = filePath;
            this.Content = content;
            this.user = user;

            ratings = new List<Rating>();
        }

        public List<Comment> GetAllFromFile(string filePath)
        {
            return null;
        }
        public List<Comment> GetAllFromUser(string RFID)
        {
            return null;
        }

        public void Get(Type comment)
        {

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
