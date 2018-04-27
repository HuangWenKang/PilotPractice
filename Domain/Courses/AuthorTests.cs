using Xunit;
using FluentAssertions;


namespace Domain.Courses
{
        
    public class AuthorTests
    {

        [Fact]
        public void ShowDisplayname_UsingCombination_FirstnameAndLastname()
        {
            var author = new Author("Gary","Huang");

            var displayName = author.DisplayName;

            displayName.Should().Be("Gary Huang");
        }
    }
}
