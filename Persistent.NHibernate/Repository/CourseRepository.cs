using Domain.Common;
using Domain.Courses;
using Domain.Utils;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Persistent.NHibernate.Repository
{
    public class CourseRepository : Repository<Course>
    {
        public IReadOnlyList<Course> GetClipList()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Course>()
                    .ToList();                   
            }
        }
    }
}
