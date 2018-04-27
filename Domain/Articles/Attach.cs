using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Articles
{
    public sealed class Attach : ValueObject<Attach>
    {
        public int Size { get; }
        public string Format { get; }
        public string Url { get; }

        private Attach()
        {

        }

        public Attach(int size, string format, string url) : this()
        {
            if (size < 0)
                throw new InvalidOperationException();
            if (string.IsNullOrWhiteSpace(format))
                throw new InvalidOperationException();
            if (string.IsNullOrWhiteSpace(url))
                throw new InvalidOperationException();

            Size = size;
            Format = format;
            Url = url;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Size;
            yield return Format;
            yield return Url;
        }
    }
}
