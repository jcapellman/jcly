using System.Threading.Tasks;

using jcly.lib.DAL.Base;
using jcly.lib.DAL.Objects;
using jcly.lib.Helpers;

namespace jcly.lib.DAL
{
    public class LitedbDal : BaseDAL
    {
        private const string DB_FileName = "litedb.db";
        
        public override async Task<string> GetURLAsync(string key)
        {
            using (var db = new LiteDB.LiteDatabase(DB_FileName))
            {
                var collection = db.GetCollection<URLObject>();

                var result = collection.FindOne(a => a.Key == key);

                return result?.URL;
            }
        }

        public override async Task<string> InsertURLAsync(string url)
        {
            using (var db = new LiteDB.LiteDatabase(DB_FileName))
            {
                var collection = db.GetCollection<URLObject>();

                url = url.ToLower();

                var existingResult = collection.FindOne(a => a.URL == url);

                if (existingResult != null)
                {
                    return existingResult.Key;
                }
                
                var urlObject = new URLObject
                {
                    URL = url,
                    Key = KeyGenerator.Generate()
                };

                collection.Insert(urlObject);

                return urlObject.Key;
            }
        }
    }
}