using Application.Courses;
using Domain.Courses;
using NHibernate;
using NHibernate.Linq;
using Persistent.NHibernate.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Persistent.NHibernate.Courses
{
    public class CourseRepository : NHibernateRepository<Course, long>, ICourseRepository
    {
        public CourseRepository(ISession session)
        : base(session)
        {
        }

        public IEnumerable<Course> Find(string text)
        {
            return _session.Query<Course>().Where(x => x.Title.Contains(text)).ToList();
        }

        public IEnumerable<Course> FindNeedDownlaodCourses()
        {
            return _session.Query<Course>().ToList();
        }        
    }
}
