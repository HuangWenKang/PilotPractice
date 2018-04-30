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
    public class CourseMap : ClassMap<Course>
    {
        public CourseMap()
        {
            Id(x=>x.Id);

            Map(x=>x.Title);
            Map(x => x.Description);
            Map(x => x.PublishedOn);
            Map(x => x.Level);

            Component(x=>x.Author,y=> {
                y.Map(x=>x.FirstName);
                y.Map(x => x.LastName);                
            });

            HasMany<Module>(Reveal.Member<Course>("Modules"))
                .Cascade.Delete()
                .Cascade.SaveUpdate()
                .Not.LazyLoad()
                .Inverse();
        }
    }
}
