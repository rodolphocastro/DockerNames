
using AutoFixture.Xunit2;

using FluentAssertions;

using Xunit;

namespace DockerNames.Unit
{
    public class DockerNameFactoryTests
    {
        [Fact]
        public void ConstructableWithoutParams()
        {
            // Arrange
            DockerNameFactory subject;

            // Act
            subject = new DockerNameFactory();

            // Assert
            subject.Should().NotBeNull();
        }

        [Fact]
        public void BuildsNames()
        {
            // Arrange            
            var subject = DockerNameFactory.Instance;

            // Act
            string result = subject.Build();

            // Assert
            result.Should()
                .ContainAny(Personalities.Values).And
                .ContainAny(Adjectives.Values).And
                .Contain('_'.ToString());
        }

        [Theory, AutoData]
        public void BuildNamesWithSeparator(DockerNameFactory subject, char separator)
        {
            // Arrange

            // Act
            string result = subject.Build(separator);

            // Assert
            result.Should()
                .Contain(separator.ToString());
        }

        [Fact]
        public void ReturnsAnElement()
        {
            // Arrange
            var subject = DockerNameFactory.Instance;

            // Act
            string result = subject.Element;

            // Assert
            result.Should()
                .NotBeNull();
        }

        [Fact]
        public void CallableAsINameFactory()
        {
            // Arrange
            INameFactory factory = DockerNameFactory.Instance;

            // Act

            // Assert
            factory.Should()
                .NotBeNull().And
                .BeOfType<DockerNameFactory>();
        }
    }
}
