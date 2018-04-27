using System;
using Domain.Articles;
using Domain.Common;
using Domain.Courses;

namespace Domain.Article
{
    public class Article : AggregateRoot
    {
        public virtual string Title { get; }
        public virtual string Description { get; }
        public virtual Author Author { get; set; }
        public virtual Attach Attach { get; set; }

        public Article(string title, string description)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
