using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DockerNames.Unit")]
namespace DockerNames
{
    /// <summary>
    /// Factory for building Docker names.
    /// </summary>
    public class DockerNameFactory : NameFactoryBase
    {
        protected internal DockerNameFactory() : base(Adjectives.Values, Personalities.Values)
        {

        }

        public string Element => Build();

        public static DockerNameFactory Instance { get; } = new DockerNameFactory();
    }
}
