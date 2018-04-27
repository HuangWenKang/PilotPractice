using Domain.Common;
using Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Course
{
    public class Course : AggregateRoot
    {
        public virtual string Title { get; }
        public virtual string Description { get; }
        public virtual DateTime PublishedOn { get; }
        public virtual Level Level { get; }
        public virtual Author Author { get; set; }
        public virtual IList<Module> Modules { get; set; }

        public Course(string title, string description, DateTime publishedOn, Level level)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            PublishedOn = publishedOn;
            Level = level;
        }

        public virtual int CalculateDuration() => Modules.Sum(m => m.GetDuration());

        public virtual IList<Clip> GetClips()
        {
            return Modules
                .OrderBy(m=>m.Ordering)
                .SelectMany(m=>m.Clips)
                .ToList();
        }
    }
}
