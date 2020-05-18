using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteLoader.DependencyInjection
{
    public interface IDynamicServices : IServiceProvider
    {
        /// <summary>
        /// Adds a service to this service provider
        /// </summary>
        /// <param name="serviceType">The service type</param>
        /// <param name="implementationType">Implementation Type</param>
        /// <param name="implementationFactory">Factory</param>
        /// <param name="isTransient">Should a new instance be created each time it's called</param>
        /// <param name="implementation">Current instance of the service</param>
        void AddService(Type serviceType, Type implementationType, Func<IServiceProvider, object> implementationFactory, bool isTransient, object implementation);

        /// <summary>
        /// Removes a service from this service provider
        /// </summary>
        /// <param name="serviceType">The service type</param>
        /// <returns>True if success</returns>
        bool RemoveService(Type serviceType);
    }
}
