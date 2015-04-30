using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public enum FileType
    {
        Video,
        Plaatje,
        Tekst,
        GIF
    };

    public class MediaFile : IDatabase<MediaFile>
    {
        //Fields
        private string filePath;
        private string description;

        private int userID;
        private int mediaFileID;
        private int eventID;

        private DateTime uploadDate;

        private MediaType mediaTypeName;

        private List<Rating> ratings;
        private List<Comment> comments;

        //Properties
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
        public int UserID
        {
          get { return userID; }
          set { userID = value; }
        }
        public int MediaFileID
        {
            get { return mediaFileID; }
            set { mediaFileID = value; }
        }
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }
        public DateTime UploadDate
        {
            get { return uploadDate; }
            set { uploadDate = value; }
        }
        public MediaType MediaTypeName
        {
            get { return mediaTypeName; }
            set { mediaTypeName = value; }
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

        //Constructor for creating a single mediafile
        //The mediafile has a strong connection with the user
        public MediaFile(string filePath, string description, int userID, int mediaFileID, int eventID, DateTime uploadDate, MediaType mediaTypeName)
        {
            this.filePath = filePath;
            this.description = description;
            this.userID = userID;
            this.mediaFileID = mediaFileID;
            this.eventID = eventID;          
            this.uploadDate = uploadDate;
            this.mediaTypeName = mediaTypeName;

            ratings = new List<Rating>();
            comments = new List<Comment>();
        }

        //A function that gets all the mediafiledata from the database above a certain report percentage
        //It will construct the mediafiles from the database
        public static List<MediaFile> GetReportedFiles(int percentage, int eventID, Database database)
        {
            //Specification can be latest, popular or a text to search with
            List<string> mediaFilesColumns = new List<string>();
            List<MediaFile> selectedMediaFiles = new List<MediaFile>();

            mediaFilesColumns.Add("MEDIABESTANDID");
            mediaFilesColumns.Add("BESTANDLOCATIE");
            mediaFilesColumns.Add("EVENEMENTID");
            mediaFilesColumns.Add("GEBRUIKERID");
            mediaFilesColumns.Add("BESTANDTYPE");
            mediaFilesColumns.Add("OPMERKING");
            mediaFilesColumns.Add("UPLOADDATUM");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM MEDIABESTAND m1 WHERE m1.EVENEMENTID = " + eventID + " AND (SELECT COUNT(*) FROM OORDEEL o1 WHERE o1.bestandlocatie = m1.bestandlocatie AND o1.positief = 'N') > 0 AND (SELECT COUNT(*) FROM OORDEEL o1 WHERE o1.bestandlocatie = m1.bestandlocatie AND o1.positief = 'N') / (SELECT COUNT(*) FROM OORDEEL o2 WHERE o2.bestandlocatie = m1.bestandlocatie) * 100 >= " + percentage, mediaFilesColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    MediaType thisMediaType = null;

                    foreach (MediaType mediaType in MediaType.GetAll(database))
                    {
                        if (mediaType.MediaTypeID == Convert.ToInt32(dataTable[4][i]))
                        {
                            thisMediaType = mediaType;
                        }
                    }

                    selectedMediaFiles.Add(new MediaFile(
                        dataTable[1][i],
                        dataTable[5][i],
                        Convert.ToInt32(dataTable[3][i]),
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToDateTime(dataTable[6][i]),
                        thisMediaType));
                }
            }

            return selectedMediaFiles;
        }

        //A function that gets all the mediafiledata from the database with a certain specification
        //It is used to construct all the mediafiles
        public static List<MediaFile> GetFiles(string query, Database database)
        {
            //Specification can be latest, popular or a text to search with
            List<string> mediaFilesColumns = new List<string>();
            List<MediaFile> selectedMediaFiles = new List<MediaFile>();

            mediaFilesColumns.Add("MEDIABESTANDID");
            mediaFilesColumns.Add("BESTANDLOCATIE");
            mediaFilesColumns.Add("EVENEMENTID");
            mediaFilesColumns.Add("GEBRUIKERID");
            mediaFilesColumns.Add("BESTANDTYPE");
            mediaFilesColumns.Add("OPMERKING");
            mediaFilesColumns.Add("UPLOADDATUM");





            List<string>[] dataTable = database.selectQuery(query, mediaFilesColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    MediaType thisMediaType = null;

                    foreach (MediaType mediaType in MediaType.GetAll(database))
                    {
                        if (mediaType.MediaTypeID == Convert.ToInt32(dataTable[4][i]))
                        {
                            thisMediaType = mediaType;
                        }
                    }

                    selectedMediaFiles.Add(new MediaFile(
                        dataTable[1][i],
                        dataTable[5][i],
                        Convert.ToInt32(dataTable[3][i]),
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToDateTime(dataTable[6][i]),
                        thisMediaType));
                }
            }

            return selectedMediaFiles;
        }

        //Returns a single mediafile which has the input ID but more accesible
        public static MediaFile GetStatic(int mediaFileID, Database database)
        {
            List<string> mediaFilesColumns = new List<string>();
            MediaFile getMediaFile = null;

            mediaFilesColumns.Add("MEDIABESTANDID");
            mediaFilesColumns.Add("BESTANDLOCATIE");
            mediaFilesColumns.Add("EVENEMENTID");
            mediaFilesColumns.Add("GEBRUIKERID");
            mediaFilesColumns.Add("BESTANDTYPE");
            mediaFilesColumns.Add("OPMERKING");
            mediaFilesColumns.Add("UPLOADDATUM");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  MEDIABESTAND WHERE MEDIABESTANDID = " + mediaFileID, mediaFilesColumns);

            if (dataTable[0].Count() > 1)
            {
                MediaType thisMediaType = null;

                foreach (MediaType mediaType in MediaType.GetAll(database))
                {
                    if (mediaType.MediaTypeID == Convert.ToInt32(dataTable[4][1]))
                    {
                        thisMediaType = mediaType;
                    }
                }

                getMediaFile = new MediaFile(
                    dataTable[1][1],
                    dataTable[5][1],
                    Convert.ToInt32(dataTable[3][1]),
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToDateTime(dataTable[6][1]),
                    thisMediaType);
            }

            return getMediaFile;
        }

        //Returns a single mediafile which has the input ID
        public MediaFile Get(string mediaFileID, Database database)
        {
            List<string> mediaFilesColumns = new List<string>();
            MediaFile getMediaFile = null;

            mediaFilesColumns.Add("MEDIABESTANDID");
            mediaFilesColumns.Add("BESTANDLOCATIE");
            mediaFilesColumns.Add("EVENEMENTID");
            mediaFilesColumns.Add("GEBRUIKERID");
            mediaFilesColumns.Add("BESTANDTYPE");
            mediaFilesColumns.Add("OPMERKING");
            mediaFilesColumns.Add("UPLOADDATUM");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  MEDIABESTAND WHERE MEDIABESTANDID = " + mediaFileID, mediaFilesColumns);

            if (dataTable[0].Count() > 1)
            {
                MediaType thisMediaType = null;

                foreach (MediaType mediaType in MediaType.GetAll(database))
                {
                    if (mediaType.MediaTypeID == Convert.ToInt32(dataTable[4][1]))
                    {
                        thisMediaType = mediaType;
                    }
                }

                getMediaFile = new MediaFile(
                    dataTable[1][1],
                    dataTable[5][1],
                    Convert.ToInt32(dataTable[3][1]),
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToDateTime(dataTable[6][1]),
                    thisMediaType);
            }

            return getMediaFile;
        }

        //Adds a mediafile to the database
        public void Add(MediaFile newMediaFile, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO MEDIABESTAND VALUES ({0}, '{1}', {2}, {3}, '{4}', '{5}', TO_DATE('{6}', 'DD/MM/YYYY HH24:MI:SS'))",
                newMediaFile.mediaFileID, newMediaFile.filePath, newMediaFile.eventID, newMediaFile.userID, newMediaFile.mediaTypeName.MediaTypeID, newMediaFile.description, newMediaFile.uploadDate));
        }

        //Edits a mediafile in the database to its current values
        public void Edit(MediaFile updateMediaFile, Database database)
        {
            database.editDatabase(String.Format("UPDATE MEDIABESTAND SET BESTANDLOCATIE = '{0}', EVENEMENTID = {1}, GEBRUIKERID = {2}, BESTAND = '{3}', OPMERKING = '{4}', UPLOADDATUM = TO_DATE('{5}', 'DD/MM/YYYY HH24:MI:SS') WHERE MEDIABESTANDID = {6}",
                updateMediaFile.filePath, updateMediaFile.eventID, updateMediaFile.userID, updateMediaFile.mediaTypeName.MediaTypeID, updateMediaFile.description, updateMediaFile.uploadDate, updateMediaFile.mediaFileID));

        }

        //Removes a mediafile from the database
        public void Remove(MediaFile removeMediaFile, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM MEDIABESTAND WHERE MEDIABESTANDID = {0}",
                removeMediaFile.mediaFileID));
        }

        public override string ToString()
        {
            return Convert.ToString(mediaFileID);
        }
    }
}
