using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DockerNames.Unit")]
namespace DockerNames
{
    /// <summary>
    /// Factory for building Docker names.
    /// </summary>
    public class DockerNameFactory
    {
        private readonly Random _rand = new Random();
        private readonly IEnumerable<string> _left;
        private readonly IEnumerable<string> _right;

        private DockerNameFactory() { }

        protected internal DockerNameFactory(IEnumerable<string> left, IEnumerable<string> right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left));
            _right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public virtual string Build(char separator = '_') => string.Join(separator.ToString(), PickLeft(), PickRight());

        protected virtual string PickLeft() => _left.ElementAt(PickIndex(_left));

        protected virtual string PickRight() => _right.ElementAt(PickIndex(_right));

        protected virtual int PickIndex<T>(IEnumerable<T> collection) => _rand.Next(0, collection.Count());

        public static DockerNameFactory Instance { get; } = new DockerNameFactory(Adjectives.Values, Personalities.Values);
    }
}
