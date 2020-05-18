using System;

namespace LiteLoader.Pooling
{
    /// <summary>
    /// Provides a interface for pooling arrays
    /// </summary>
    public interface IArrayPool
    {
        /// <summary>
        /// Gets a array with zero length
        /// </summary>
        Array Empty { get; }

        /// <summary>
        /// Get array from the pool
        /// </summary>
        /// <param name="length">Desired array length</param>
        /// <returns>Array of <see cref="T"/></returns>
        Array Get(int length);

        /// <summary>
        /// Returns the array back to the pool
        /// </summary>
        /// <param name="array">The array</param>
        void Free(Array array);
    }
}
