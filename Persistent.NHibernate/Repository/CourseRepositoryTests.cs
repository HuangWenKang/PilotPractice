using Persistent.NHibernate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Domain.Utils;

namespace Domain.Repository
{
    public class CourseRepositoryTests
    {
        [Fact]
        public void Get_AllCourseList()
        {
            string connectionString = @"server=localhost;port=3307;user id=root;password=811122;database=PracticePilot";
            Initer.Init(connectionString);

            CourseRepository repository = new CourseRepository();
            var courses = repository.GetClipList();

            courses.Count.Should().Be(0);

        }
    }
}
