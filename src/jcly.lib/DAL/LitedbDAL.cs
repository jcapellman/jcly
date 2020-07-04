using System;
using System.Threading.Tasks;

using jcly.lib.DAL.Base;

namespace jcly.lib.DAL
{
    public class LitedbDal : BaseDAL
    {
        private const string DB_FileName = "litedb.db";

        public class URLObject
        {
            public string Key { get; set; }

            public string URL { get; set; }
        }
        
        public override Task<string> GetURLAsync(string key)
        {
            throw new NotImplementedException();
        }

        public override async Task<string> InsertURLAsync(string url)
        {
            using (var db = new LiteDB.LiteDatabase(DB_FileName))
            {
                var collection = db.GetCollection<URLObject>();

                var urlObject = new URLObject()
                {
                    URL = url
                };

                collection.Insert(urlObject);

                return urlObject.Key;
            }
        }
    }
}