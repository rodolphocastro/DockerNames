
using FluentAssertions;

using Xunit;

namespace DockerNames.Unit
{
    public class NamesConstantsTests
    {
        [Fact]
        public void PersonalitiesContainsOnlyUniqueValues()
        {
            // Arrange
            var subject = Personalities.Values;

            // Act

            // Assert
            subject.Should().OnlyHaveUniqueItems();
        }
    }
}
