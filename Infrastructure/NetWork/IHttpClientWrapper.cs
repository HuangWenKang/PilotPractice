using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.NetWork
{
    public interface IHttpClientWrapper
    {
        string Get(string url, KeyValuePair<string, string> headers);
        string Post(string url, KeyValuePair<string, string> headers);
    }
}
