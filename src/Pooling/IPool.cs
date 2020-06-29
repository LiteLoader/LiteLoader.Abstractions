namespace LiteLoader.Pooling
{
    /// <summary>
    /// Provides a interface for pooling items
    /// </summary>
    public interface IPool<T>
    {
        /// <summary>
        /// Returns a item to the pool
        /// </summary>
        /// <param name="item">The item to return</param>
        void Free(T item);

        /// <summary>
        /// Gets a pooled item from this pool
        /// </summary>
        /// <returns>Pooled Item</returns>
        T Get();
    }
}
