using Domain.Courses;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistent.NHibernate.Map
{
    public class ClipMap : ClassMap<Clip>
    {
        public ClipMap()
        {
            Id(x => x.Id);

            Map(x => x.Title);
            Map(x => x.Ordering);
            Map(x => x.Duration);
            Map(x => x.Url);

            References(x => x.Module);


        }
    }
}
