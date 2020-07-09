using System.Threading.Tasks;

using jcly.lib.DAL.Base;
using jcly.lib.DAL.Objects;
using jcly.lib.Helpers;

using MongoDB.Driver;

namespace jcly.lib.DAL
{
    public class MongoDAL : BaseDAL
    {
        private const string DEFAULT_HOSTNAME = "localhost";
        private const int DEFAULT_PORTNUMBER = 27017;

        private readonly IMongoDatabase _db;

        public MongoDAL(string hostName = DEFAULT_HOSTNAME, int portNumber = DEFAULT_PORTNUMBER)
        {
            var mongoSettings = new MongoClientSettings()
            {
                Server = new MongoServerAddress(hostName, portNumber)
            };

            var client = new MongoClient(mongoSettings);

            _db = client.GetDatabase(nameof(URLObject));
        }

        public override async Task<string> GetURLAsync(string key)
        {
            var collection = _db.GetCollection<URLObject>(nameof(URLObject));

            var result = (await collection.FindAsync(a => a.Key == key)).FirstOrDefault();

            return result?.URL;
        }

        public override async Task<string> InsertURLAsync(string url)
        {
            var collection = _db.GetCollection<URLObject>(nameof(URLObject));

            var result = await (await collection.FindAsync(a => a.URL == url)).FirstOrDefaultAsync();

            if (result != null)
            {
                return result.Key;
            }

            var urlObject = new URLObject
            {
                URL = url,
                Key = KeyGenerator.Generate()
            };

            await collection.InsertOneAsync(urlObject);

            return urlObject.Key;
        }
    }
}