namespace LiteLoader.Pooling
{
    /// <summary>
    /// Provides a interface for pooling items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPool<T>
    {
        /// <summary>
        /// Get a pooled <see cref="T"/>
        /// </summary>
        /// <returns><see cref="T"/> object</returns>
        T Get();

        /// <summary>
        /// Returns a <see cref="T"/> back to the pool
        /// </summary>
        /// <param name="item"><see cref="T"/> object</param>
        void Free(T item);
    }
}
