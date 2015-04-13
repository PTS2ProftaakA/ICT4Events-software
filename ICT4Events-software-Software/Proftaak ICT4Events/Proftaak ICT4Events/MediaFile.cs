﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    enum FileType
    {
        Image,
        Video,
        Text,
        Music
    };

    class MediaFile : IDatabase
    {
        private string filePath;
        private string description;

        private FileType type;

        private List<Rating> ratings;
        private List<Comment> comments;

        #region properties
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public FileType Type
        {
            get { return type; }
            set { type = value; }
        }
        public List<Rating> Ratings
        {
            get { return ratings; }
            set { ratings = value; }
        }
        public List<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        #endregion

        public MediaFile(string filePath, FileType type, string description)
        {
            this.filePath = filePath;
            this.type = type;
            this.description = description;

            ratings = new List<Rating>();
            comments = new List<Comment>();
        }

        public MediaFile GetAll() 
        {
            return null;
        }

        public Type Get(string filePath)
        {
            return null;
        }

        public void Add(Type mediaFile)
        {

        }

        public void Edit(Type mediaFile)
        {

        }

        public void Remove(Type mediaFile)
        {

        }
    }
}
