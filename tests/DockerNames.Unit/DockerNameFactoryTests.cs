
using System.Collections.Generic;

using AutoFixture.Xunit2;

using FluentAssertions;

using Xunit;

namespace DockerNames.Unit
{
    public class DockerNameFactoryTests
    {
        [Theory, AutoData]
        public void ConstructableWithEnumerables(IEnumerable<string> left, IEnumerable<string> right)
        {
            // Arrange
            DockerNameFactory subject;

            // Act
            subject = new DockerNameFactory(left, right);

            // Assert
            subject.Should().NotBeNull();
        }

        [Theory, AutoData]
        public void BuildsNames(string leftData, string rightData)
        {
            // Arrange
            IEnumerable<string> left, right;
            left = new List<string> { leftData };
            right = new List<string> { rightData };
            var subject = new DockerNameFactory(left, right);

            // Act
            var result = subject.Build();

            // Assert
            result.Should()
                .Contain(leftData).And
                .Contain(rightData).And
                .Contain('_'.ToString());
        }

        [Theory, AutoData]
        public void BuildNamesWithSeparator(DockerNameFactory subject, char separator)
        {
            // Arrange

            // Act
            var result = subject.Build(separator);

            // Assert
            result.Should()
                .Contain(separator.ToString());
        }
    }
}
