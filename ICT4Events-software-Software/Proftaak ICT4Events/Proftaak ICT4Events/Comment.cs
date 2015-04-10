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

        public Comment(int commentID, string filePath, string content)
        {
            this.CommentID = commentID;
            this.FilePath = filePath;
            this.Content = content;
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
