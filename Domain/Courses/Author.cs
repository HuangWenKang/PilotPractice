using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Courses
{
    public sealed class Author : ValueObject<Author>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string DisplayName
        {
            get
            {
                return string.Format(@"{0} {1}",FirstName,LastName);
            }
        }

        private Author()
        {

        }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
