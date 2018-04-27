using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Course
{
    public class Module : Entity
    {
        public virtual string Title { get; }
        public virtual int Ordering { get; }
        public virtual IList<Clip> Clips { get; set; }
        public virtual Course Course { get; set; }

        protected Module()
        {
            Clips = new List<Clip>();
        }

        public Module(string title, int ordering)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Ordering = ordering;            
        }

        public virtual Clip GetClip(string title)
        {
            return Clips.Single(c=>c.Title.Equals(title));
        } 

        public virtual void InsertClip(Clip clip)
        {
            if (Clips.Any(c => c.Ordering == clip.Ordering))
            {
                throw new InvalidOperationException();
            }

            Clips.Add(clip);
        }

        public virtual int GetDuration() => Clips.Sum(c => c.Duration);
        
    }
}
