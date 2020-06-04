namespace DockerNames
{
    /// <summary>
    /// Describe methods for a Name Factory.
    /// </summary>
    public interface INameFactory
    {
        /// <summary>
        /// Builds a new name with a given separator.
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        string Build(char separator = '_');
    }
}