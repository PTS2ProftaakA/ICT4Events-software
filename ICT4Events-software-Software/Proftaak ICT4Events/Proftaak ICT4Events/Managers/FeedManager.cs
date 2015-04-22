﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class FeedManager
    {
        Database database;

        public FeedManager(Database database)
        {
            this.database = database;
        }

        //Get all the mediafiles using a custom specification using the MediaFile class
        //this can be the most popular, the latest or mediafiles containing a search word
        public List<MediaFile> GetFiles(string specification, Database database)
        {
            return MediaFile.GetFiles(specification, database);
        }

        //Returns all the types of media
        //These contain things like video or photo
        public List<MediaType> getTypes(Database database)
        {
            return MediaType.GetAll(database);
        }

        //Uses the Add function in MediaFile to create a new mediafile and add it in the database
        public void makePost(MediaType type, string description, string filePath)
        {
            MediaFile newmedia = new MediaFile(filePath, description, CurrentUser.currentUser.UserID, 1, CurrentUser.currentUser.EventID, DateTime.Now, type);
            newmedia.Add(newmedia, database);
        }

    }
}
