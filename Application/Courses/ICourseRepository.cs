﻿using Application.Interfaces;
using Domain.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses
{
    public interface ICourseRepository : IRepository<Course, long>
    {

        IEnumerable<Course> FindNeedDownlaodCourses();
        IEnumerable<Course> Find(string text);
    }
}