using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.NetWork
{
    public interface ICacheClientWrapper
    {
        void Save(string key, string value);
        T Load<T>(string key);
    }
}
