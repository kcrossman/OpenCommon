using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OpenCommon.AutoRegistration.Attributes;
using OpenCommon.AutoRegistration.Models;

namespace OpenCommon.AutoRegistration.Extensions
{
    public static class ServicesExtensions
    {
        private static readonly List<Type> SupportedAttributes;

        static ServicesExtensions()
        {
            var baseAttribute = typeof(BaseAutoRegistration);
            SupportedAttributes = Assembly.GetExecutingAssembly().GetTypes().Where(t => baseAttribute.IsAssignableFrom(t) && baseAttribute != t).ToList();
        }

        /// <summary>
        /// This will auto-register any Transient, Scoped, and Singleton-attributed interfaces/classes.
        /// </summary>
        /// <remarks>
        /// The largest scope (Singleton > Scoped > Transient) will override others.
        /// </remarks>
        public static List<DependencyMapping> AutoRegisterDependencies(this IServiceCollection services)
        {
            var assemblies = Assembly.GetCallingAssembly().GetReferencedAssemblies().Select(Assembly.Load).SelectMany(a => a.GetTypes()).ToList();
            var attributedAssemblies = assemblies.Where(at => at.CustomAttributes.Any(ata => SupportedAttributes.Contains(ata.AttributeType))).ToList();

            var dependencyMappings = new List<DependencyMapping>();
            foreach (var attributedAssembly in attributedAssemblies)
            {
                var assemblyAttributes = attributedAssembly.GetCustomAttributes<BaseAutoRegistration>(false).OrderByDescending(a => a.RegistrationPriority).Select(a => a.GetType()).ToList();
                var assemblyAttribute = assemblyAttributes[0];

                if (attributedAssembly.IsClass)
                {
                    services.RegisterDependency(assemblies, dependencyMappings, assemblyAttribute, attributedAssembly);
                }
                else if (attributedAssembly.IsInterface)
                {
                    var implementedTypes = assemblies.Where(at => attributedAssembly.IsAssignableFrom(at) && at != attributedAssembly).ToList();
                    if (implementedTypes.Count == 0)
                    {
                        Debug.Write($"{ attributedAssembly.FullName } is not implemented and will not be auto registered.");
                    }
                    else
                    {
                        foreach (var implementedType in implementedTypes)
                        {
                            services.RegisterDependency(assemblies, dependencyMappings, assemblyAttribute, attributedAssembly, implementedType);
                        }
                    }
                }
                else
                {
                    throw new NotSupportedException($"{attributedAssembly.FullName} is not an expected attributed type in dependency auto registration.");
                }
            }

            return dependencyMappings;
        }

        private static void RegisterDependency(this IServiceCollection services, List<Type> assemblies, List<DependencyMapping> dependencyMappings, Type attributeType, Type serviceType, Type implementationType = null)
        {
            if (!SupportedAttributes.Contains(attributeType))
            {
                throw new NotSupportedException($"{attributeType.FullName} is not supported by dependency auto registration");
            }

            if (implementationType == null)
            {
                implementationType = serviceType;
            }

            if (attributeType == typeof(Transient))
            {
                services.AddTransient(serviceType, implementationType);
            }
            else if (attributeType == typeof(Scoped))
            {
                services.AddScoped(serviceType, implementationType);
            }
            else if (attributeType == typeof(Singleton))
            {
                services.AddSingleton(serviceType, implementationType);
            }

            var dependencyMapping =
                new DependencyMapping
                {
                    AttributeType = attributeType,
                    ServiceType = serviceType,
                    ImplementationType = implementationType
                };
            dependencyMappings.Add(dependencyMapping);
        }
    }
}
