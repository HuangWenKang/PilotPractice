using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.NetWork
{
    public class RedisCacheClientWrapper : ICacheClientWrapper
    {
        public T Load<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Save(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
