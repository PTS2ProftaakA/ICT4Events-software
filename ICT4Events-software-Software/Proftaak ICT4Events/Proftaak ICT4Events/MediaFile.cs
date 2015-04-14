using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    enum FileType
    {
        Video,
        Plaatje,
        Tekst,
        GIF
    };

    class MediaFile : IDatabase
    {
        private string filePath;
        private string description;
        private string RFID;

        private int evenementID;

        private DateTime uploadDate;

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

        public MediaFile(string filePath, int evenementID, string RFID, FileType type, string description, DateTime uploadDate)
        {
            this.filePath = filePath;
            this.evenementID = evenementID;
            this.RFID = RFID;
            this.type = type;
            this.description = description;
            this.uploadDate = uploadDate;

            ratings = new List<Rating>();
            comments = new List<Comment>();
        }

        public static List<MediaFile> GetFiles(string specification, Database database)
        {
            //Specification can be latest, popular or a text to search with
            List<string> mediaFilesColumns = new List<string>();
            List<MediaFile> selectedMediaFiles = new List<MediaFile>();

            mediaFilesColumns.Add("REACTIEID");
            mediaFilesColumns.Add("BESTANDSLOCATIE");
            mediaFilesColumns.Add("RFID");
            mediaFilesColumns.Add("INHOUD");

            string query;

            if(specification == "latest")
            {
                query = "SELECT * FROM MEDIABESTAND WHERE ROWNUM <= 10 ORDER BY UPLOADDATUM DESC";
            }
            else if(specification == "popular")
            {
                query = "SELECT * FROM MEDIABESTAND WHERE ROWNUM <= 10 ORDER BY DATE DESC"; //<<----------
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
                    FileType extension = (FileType)Enum.Parse(typeof(FileType), dataTable[3][i]);

                    selectedMediaFiles.Add(new MediaFile(
                        dataTable[0][i],
                        Convert.ToInt32(dataTable[1][i]),
                        dataTable[2][i],
                        extension,
                        dataTable[4][i],
                        Convert.ToDateTime(dataTable[5][i])));
                }
            }

            return selectedMediaFiles;
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
