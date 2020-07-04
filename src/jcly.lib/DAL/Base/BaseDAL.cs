using System.Threading.Tasks;

namespace jcly.lib.DAL.Base
{
    public abstract class BaseDAL
    {
        public abstract Task<string> InsertURLAsync(string url);

        public abstract Task<string> GetURLAsync(string key);
    }
}