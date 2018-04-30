using Persistent.NHibernate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;
using Domain.Utils;
using Domain.Courses;

namespace Domain.Repository
{
    public class CourseRepositoryTests
    {


        [Fact]
        public void Init_Database_Schema()
        {
            string connectionString = @"server=localhost;port=3306;user id=root;password=811122;database=PracticePilot";
            Initer.Init(connectionString);

            var session = SessionFactory.OpenSession();
            session.Connection.Should().NotBeNull();

        }

        [Fact]
        public void Get_AllCourseList()
        {
            string connectionString = @"server=localhost;port=3306;user id=root;password=811122;database=PracticePilot";
            Initer.Init(connectionString);

            CourseRepository repository = new CourseRepository();
            var courses = repository.GetClipList();

            courses.Count.Should().Be(0);

        }

        [Fact]
        public void Insert_Course()
        {
            string connectionString = @"server=localhost;port=3306;user id=root;password=811122;database=PracticePilot";
            Initer.Init(connectionString);

            var clip = new Clip("DemoClip", 10, 1, "");
            var module = new Module("DemoModule", 1);            
            var course = new Course("DemoCourse", "", DateTime.Now, Level.Intermediate);

            clip.Module = module;
            module.Clips = new List<Clip>() { clip };

            module.Course = course;
            course.Modules = new List<Module>() { module };

            CourseRepository repository = new CourseRepository();
            repository.Save(course);

        }

        [Fact]
        public void Load_Course()
        {
            string connectionString = @"server=localhost;port=3306;user id=root;password=811122;database=PracticePilot";
            Initer.Init(connectionString);
            
            CourseRepository repository = new CourseRepository();
            Course course = repository.GetById(3);
            course.Title.Should().Be("DemoCourse");
            course.Modules.Count().Should().Be(1);
            course.Modules[0].Clips.Count.Should().Be(1);
        }

        [Fact]
        public void Delete_Course()
        {
            string connectionString = @"server=localhost;port=3306;user id=root;password=811122;database=PracticePilot";
            Initer.Init(connectionString);

            CourseRepository repository = new CourseRepository();
            Course course = repository.GetById(3);
            repository.Delete(course);
            
        }
    }
}
