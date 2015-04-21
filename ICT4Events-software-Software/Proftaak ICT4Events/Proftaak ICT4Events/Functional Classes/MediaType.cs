using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public class MediaType : IDatabase<MediaType>
    {
        //Fields
        private string type;

        private int mediaTypeID;

        private Database database;

        //Properties
        #region properties
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int MediaTypeID
        {
            get { return mediaTypeID; }
            set { mediaTypeID = value; }
        }
        #endregion

        //Constructor that creates a single mediatype that is used by mediafile
        public MediaType(string type, int mediaTypeID)
        {
            this.mediaTypeID = mediaTypeID;
            this.type = type;

            database = new Database();
        }

        //A function that returns a list of all the mediatypes
        public static List<MediaType> GetAll(Database database)
        {
            List<string> mediaTypeColumns = new List<string>();
            List<MediaType> allMediaType = new List<MediaType>();

            mediaTypeColumns.Add("MEDIATYPEID");
            mediaTypeColumns.Add("TYPE");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM MEDIATYPE", mediaTypeColumns);

            if(dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allMediaType.Add(new MediaType(
                        dataTable[1][i],
                        Convert.ToInt32(dataTable[0][i])));
                }
            }

            return allMediaType;
        }

        //returns a single mediatype that corresponds with the input ID
        public MediaType Get(string mediaTypeID, Database database)
        {
            List<string> mediaTypeColumns = new List<string>();
            MediaType getMediaType = null;

            mediaTypeColumns.Add("MEDIATYPEID");
            mediaTypeColumns.Add("TYPE");

            List<string>[] dataTable = database.selectQuery("SELECT TYPE FROM MEDIATYPE WHERE MEDIATYPEID = " + mediaTypeID, mediaTypeColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    getMediaType = new MediaType(
                        dataTable[1][i],
                        Convert.ToInt32(dataTable[0][i]));
                }
            }

            return getMediaType;
        }

        //Adds a single mediatype to the database
        public void Add(MediaType newMediaType, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO MEDIATYPE VALUES ({0},'{1}')",
                newMediaType.mediaTypeID, newMediaType.type));
        }

        //Edits the input mediatype to his current values in the database
        public void Edit(MediaType updateMediaType, Database database)
        {
            database.editDatabase(String.Format("UPDATE MEDIATYPE SET TYPE = '{0}' WHERE MEDIATYPEID = {1}",
                updateMediaType.type, updateMediaType.mediaTypeID));
        }

        //Removes a mediatype from the database
        public void Remove(MediaType removeMediaType, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM MEDIATYPE WHERE MEDIATYPEID = {0}",
                removeMediaType.mediaTypeID));
        }

        //Converts the mediatype to a more readable string
        public override string ToString()
        {
            return type;
        }
    }
}
