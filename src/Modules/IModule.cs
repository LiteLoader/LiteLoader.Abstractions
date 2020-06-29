using System;

namespace LiteLoader.Modules
{
    public interface IModule : IEquatable<IModule>, IComparable<IModule>
    {
        #region Hook Subscriptions

        /// <summary>
        /// Executes a hool this module is currently subscribed to
        /// </summary>
        /// <param name="methodName">The method name to execute</param>
        /// <param name="arguments">Provided arguments for type matching</param>
        /// <returns>The value returned from the method</returns>
        object ExecuteHook(string methodName, object[] arguments);

        /// <summary>
        /// Subscribe to a method with optional parameter type matching
        /// </summary>
        /// <param name="methodName">The name of the method to subscribe to</param>
        /// <param name="parameterTypes">Parameter Type Matching (Optional)</param>
        /// <param name="returnType">Return Type Matching (Optional)</param>
        void SubscribeTo(string methodName, Type[] parameterTypes = null, Type returnType = null);

        /// <summary>
        /// Unsubscribe to a method with optional parameter type matching
        /// </summary>
        /// <param name="methodName">The name of the method to unsubscribe from</param>
        /// <param name="parameterTypes">Parameter Type Matching (Optional)</param>
        /// <param name="returnType">Return Type Matching (Optional)</param>
        void UnsubscribeFrom(string methodName, Type[] parameterTypes = null, Type returnType = null);

        #endregion
    }
}
