using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Utils
{
    public class SessionFactoryTests
    {
        [Fact]
        public void ConnectMysql_GenerateDatabaseSchema()
        {
            string connectionString = @"server=localhost;port=3307;user id=root;password=811122;database=PracticePilot";
            SessionFactory.Init(connectionString);


        }
    }
}
