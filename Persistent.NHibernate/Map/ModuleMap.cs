using Domain.Courses;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistent.NHibernate.Map
{
    public class ModuleMap : ClassMap<Module>
    {
        public ModuleMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Ordering);

            HasMany<Clip>(Reveal.Member<Module>("Clips"))
                .Cascade.Delete()
                .Cascade.SaveUpdate()
                .Not.LazyLoad()
                .Inverse();

            References(x => x.Course);
        }
    }
}
