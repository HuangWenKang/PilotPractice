using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public class Initer
    {
        public static void Init(string connectionString)
        {
            SessionFactory.Init(connectionString);            
        }
    }
}
