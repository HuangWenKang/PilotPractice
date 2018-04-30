using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Courses
{
    public class Clip : Entity
    {
        public virtual string Title { get; }
        public virtual int Duration { get; }
        public virtual int Ordering { get; }
        public virtual string Url { get; }
        public virtual Module Module { get; set; }

        protected Clip()
        {
        }

        public Clip(string title, int duration, int ordering, string url)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Duration = duration;
            Ordering = ordering;
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }
        
    }
}
