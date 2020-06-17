using System;

namespace LiteLoader.Pooling
{
    /// <summary>
    /// Provides a interface for pooling arrays
    /// </summary>
    public interface IArrayPool<T> : IPool<T[]>
    {
        /// <summary>
        /// Gets a array with zero length
        /// </summary>
        T[] Empty { get; }

        /// <summary>
        /// Get array from the pool
        /// </summary>
        /// <param name="length">Desired array length</param>
        /// <returns>Array</returns>
        T[] Get(int length);
    }
}
