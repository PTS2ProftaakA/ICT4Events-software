using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class DiscussionManager
    {
        Database database;

        public DiscussionManager(Database database)
        {
            this.database = database;
        }


        public List<Comment> GetReactions(MediaFile file)
        {
            return Comment.GetAllFromFile(file.FilePath, database);
        }
    }
}
