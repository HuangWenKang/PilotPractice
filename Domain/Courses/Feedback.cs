using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Courses
{
    public class Feedback : ValueObject<Feedback>
    {
        public virtual int PopularityScore { get; }
        public virtual int RatersCount { get; }
        public virtual int Average { get; }

        private Feedback()
        {
        }

        public Feedback(int popularityScore, int ratersCount, int average)
        {
            PopularityScore = popularityScore;
            RatersCount = ratersCount;
            Average = average;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PopularityScore;
            yield return RatersCount;
            yield return Average;
        }
    }
}
