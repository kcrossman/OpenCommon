using System;

namespace OpenCommon.DependencyInjection.Attributes
{
    /// <summary>
    /// The <see cref="RegistrationAttribute"/> is not meant to be used directly and won't do anything. Use <see cref="Transient"/>, <see cref="Scoped"/>, or <see cref="Singleton"/> instead.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class RegistrationAttribute : Attribute
    {
        public virtual short RegistrationPriority => 0;
    }
}
