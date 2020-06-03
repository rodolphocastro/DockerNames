using System;
using System.Collections.Generic;
using System.Linq;

namespace DockerNames
{
    /// <summary>
    /// Base for Name Factories. Inherit this class if you want to customize any aspect of Name Generation.
    /// </summary>
    public abstract class NameFactoryBase
    {
        protected readonly IEnumerable<string> _left;
        protected readonly IEnumerable<string> _right;
        protected readonly Random _rand = new Random();

        protected NameFactoryBase(IEnumerable<string> left, IEnumerable<string> right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left));
            _right = right ?? throw new ArgumentNullException(nameof(right));
        }

        /// <summary>
        /// Builds a new name.
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public virtual string Build(char separator = '_') => JoinStrings(separator, LeftElement, RightElement);

        /// <summary>
        /// Joins a number of strings using a given separator.
        /// </summary>
        /// <param name="separator"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected static string JoinStrings(char separator, params string[] args) => string.Join(separator.ToString(), args);

        /// <summary>
        /// Picks an index randomly within the collection's bounds.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        protected virtual int PickIndex<T>(IEnumerable<T> collection) => _rand.Next(0, collection.Count());

        /// <summary>
        /// Left Element, picked randomly.
        /// </summary>
        protected virtual string LeftElement => _left.ElementAt(PickIndex(_left));

        /// <summary>
        /// Right element, picked randomly.
        /// </summary>
        protected virtual string RightElement => _right.ElementAt(PickIndex(_right));
    }
}