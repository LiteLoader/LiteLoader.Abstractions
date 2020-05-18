﻿using System;

namespace LiteLoader.DependencyInjection
{
    public static class ServiceExtension
    {
        public static void RemoveService<TService>(this IDynamicServices provider)
        {
            provider.RemoveService(typeof(TService));
        }

        #region Singleton Support

        public static void AddSingleton(this IDynamicServices provider, Type serviceType, Type implementationType, Func<IServiceProvider, object> implementationFactory)
        {
            provider.AddService(serviceType, implementationType, implementationFactory, false, null);
        }

        public static void AddSingleton<TService, TImplementation>(this IDynamicServices provider, Func<IServiceProvider, object> implementationFactory)
        {
            AddSingleton(provider, typeof(TService), typeof(TImplementation), implementationFactory);
        }

        public static void AddSingleton(this IDynamicServices provider, Type implementationType, Func<IServiceProvider, object> implementationFactory)
        {
            AddSingleton(provider, implementationType, implementationType, implementationFactory);
        }

        public static void AddSingleton<TImplementation>(this IDynamicServices provider, Func<IServiceProvider, object> implementationFactory)
        {
            AddSingleton(provider, typeof(TImplementation), implementationFactory);
        }

        public static void AddSingleton(this IDynamicServices provider, Type serviceType, Type implementationType)
        {
            provider.AddService(serviceType, implementationType, null, false, null);
        }

        public static void AddSingleton<TService, TImplementation>(this IDynamicServices provider)
        {
            AddSingleton(provider, typeof(TService), typeof(TImplementation));
        }

        public static void AddSingleton(this IDynamicServices provider, Type implementationType)
        {
            AddSingleton(provider, implementationType, implementationType);
        }

        public static void AddSingleton<TImplementation>(this IDynamicServices provider)
        {
            AddSingleton(provider, typeof(TImplementation), typeof(TImplementation));
        }

        public static void AddSingleton(this IDynamicServices provider, Type serviceType, object implementation)
        {
            provider.AddService(serviceType, null, null, false, implementation);
        }

        public static void AddSingleton<TService, TImplementation>(this IDynamicServices provider, TImplementation implementation)
        {
            AddSingleton(provider, typeof(TService), implementation);
        }

        public static void AddSingleton(this IDynamicServices provider, object implementation)
        {
            provider.AddService(null, null, null, false, implementation);
        }

        public static void AddSingleton<TImplementation>(this IDynamicServices provider, TImplementation implementation)
        {
            provider.AddService(typeof(TImplementation), typeof(TImplementation), null, false, implementation);
        }

        #endregion

        #region Transient Support

        public static void AddTransient(this IDynamicServices provider, Type serviceType, Type implementationType, Func<IServiceProvider, object> implementationFactory)
        {
            provider.AddService(serviceType, implementationType, implementationFactory, true, null);
        }

        public static void AddTransient(this IDynamicServices provider, Type serviceType, Type implementationType)
        {
            provider.AddTransient(serviceType, implementationType, null);
        }

        public static void AddTransient(this IDynamicServices provider, Type implementationType)
        {
            provider.AddTransient(implementationType, implementationType);
        }

        public static void AddTransient<TService, TImplementation>(this IDynamicServices provider, Func<IServiceProvider, object> implementationFactory)
        {
            provider.AddTransient(typeof(TService), typeof(TImplementation), implementationFactory);
        }

        public static void AddTransient<TImplementation>(this IDynamicServices provider, Func<IServiceProvider, object> implementationFactory)
        {
            provider.AddTransient(typeof(TImplementation), typeof(TImplementation), implementationFactory);
        }

        public static void AddTransient<TService, TImplementation>(this IDynamicServices provider)
        {
            provider.AddTransient(typeof(TService), typeof(TImplementation), null);
        }

        public static void AddTransient<TImplementation>(this IDynamicServices provider)
        {
            provider.AddTransient<TImplementation, TImplementation>();
        }

        #endregion
    }
}
