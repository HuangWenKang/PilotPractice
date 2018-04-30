using Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Domain.Courses
{    
    public class ModuleTests
    {
        [Fact]
        public void GetDuration_When_SumByClips()
        {
            var clips = new List<Clip>
            {
                new Clip("1",10,1,""),
                new Clip("2",20,2,""),
                new Clip("2",30,3,""),
            };

            var module = new Module("Pilot", 1) { Clips = clips};

            module.GetDuration().Should().Be(60);

        }
    }
}
