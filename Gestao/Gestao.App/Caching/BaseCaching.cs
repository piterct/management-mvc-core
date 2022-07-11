using Gestao.Business.Interfaces;

namespace Gestao.App.Caching
{
    public abstract class BaseCaching<T> where T : class
    {
        protected string GetKey(string key)
        {
            return $"{typeof(T).FullName}:{key}";
        }

    }
}
