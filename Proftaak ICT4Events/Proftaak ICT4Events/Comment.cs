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
        private string comment;

        private int commentID;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
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

        public Comment(int commentID, string filePath, string comment)
        {
            this.CommentID = commentID;
            this.FilePath = filePath;
            this.Comment = comment;
        }

        public List<Comment> GetAll(string RFID)
        {
            return null;
        }
        public List<Comment> GetAll(string filePath)
        {
            return null;
        }
    }
}
