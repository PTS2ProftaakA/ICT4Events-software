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
        private string filePath;
        private string description;
        private string RFID;

        private int mediaFileID;
        private int eventID;

        private DateTime uploadDate;

        private MediaType mediaTypeName;

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
        public string PropertyRFID
        {
            get { return RFID; }
            set { RFID = value; }
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

        public MediaFile(string filePath, string description, string RFID, int mediaFileID, int eventID, DateTime uploadDate, MediaType mediaTypeName)
        {
            this.filePath = filePath;
            this.description = description;
            this.RFID = RFID;
            this.mediaFileID = mediaFileID;
            this.eventID = eventID;          
            this.uploadDate = uploadDate;
            this.mediaTypeName = mediaTypeName;

            ratings = new List<Rating>();
            comments = new List<Comment>();
        }

        public static List<MediaFile> GetFiles(string specification, Database database)
        {
            //Specification can be latest, popular or a text to search with
            List<string> mediaFilesColumns = new List<string>();
            List<MediaFile> selectedMediaFiles = new List<MediaFile>();

            mediaFilesColumns.Add("MEDIABESTANDID");
            mediaFilesColumns.Add("BESTANDSLOCATIE");
            mediaFilesColumns.Add("EVENEMENTID");
            mediaFilesColumns.Add("RFID");
            mediaFilesColumns.Add("BESTAND");
            mediaFilesColumns.Add("OPMERKING");
            mediaFilesColumns.Add("UPLOADDATUM");

            string query;

            if(specification == "latest")
            {
                query = "SELECT * FROM MEDIABESTAND WHERE ROWNUM <= 10 ORDER BY UPLOADDATUM DESC";
            }
            else if(specification == "popular")
            {
                query = query = "SELECT m.BESTANDLOCATIE, m.RFID, COUNT(*) AS Likes FROM MEDIABESTAND m, OORDEEL o WHERE m.BESTANDLOCATIE = o.BESTANDLOCATIE AND o.POSITIEF = 'Y' AND ROWNUM <= 10 GROUP BY m.BESTANDLOCATIE, m.RFID ORDER BY COUNT(*) DESC;";
            }
            else
            {
                query = "SELECT * FROM MEDIABESTAND WHERE ROWNUM <= 10 AND DESCRIPTION LIKE " + specification; 
            }

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
                        dataTable[3][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToDateTime(dataTable[6][i]),
                        thisMediaType));
                }
            }

            return selectedMediaFiles;
        }

        public MediaFile Get(string mediaFileID, Database database)
        {
            List<string> mediaFilesColumns = new List<string>();
            MediaFile getMediaFile = null;

            mediaFilesColumns.Add("MEDIABESTANDID");
            mediaFilesColumns.Add("BESTANDSLOCATIE");
            mediaFilesColumns.Add("EVENEMENTID");
            mediaFilesColumns.Add("RFID");
            mediaFilesColumns.Add("BESTAND");
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
                    dataTable[3][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToDateTime(dataTable[6][1]),
                    thisMediaType);
            }

            return getMediaFile;
        }

        public void Add(MediaFile newMediaFile, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO MEDIABESTAND VALUES ({0}, '{1}', {2}, '{3}', '{4}', '{5}', TO_DATE('{6}', 'DD/MM/YYYY HH24:MI:SS'))",
                newMediaFile.mediaFileID, newMediaFile.filePath, newMediaFile.eventID, newMediaFile.RFID, newMediaFile.mediaTypeName.MediaTypeID, newMediaFile.description, newMediaFile.uploadDate));
        }

        public void Edit(MediaFile updateMediaFile, Database database)
        {
            database.editDatabase(String.Format("UPDATE MEDIABESTAND SET BESTANDLOCATIE = '{0}', EVENEMENTID = {1}, RFID = '{2}', BESTAND = '{3}', OPMERKING = '{4}', UPLOADDATUM = TO_DATE('{5}', 'DD/MM/YYYY HH24:MI:SS') WHERE MEDIABESTANDID = {6}",
                updateMediaFile.filePath, updateMediaFile.eventID, updateMediaFile.RFID, updateMediaFile.mediaTypeName.MediaTypeID, updateMediaFile.description, updateMediaFile.uploadDate, updateMediaFile.mediaFileID));

        }

        public void Remove(MediaFile removeMediaFile, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM MEDIABESTAND WHERE MEDIABESTANDID = {0}",
                removeMediaFile.mediaFileID));
        }
    }
}
