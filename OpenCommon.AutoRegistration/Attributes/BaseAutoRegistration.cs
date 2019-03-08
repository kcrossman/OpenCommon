using System;

namespace OpenCommon.AutoRegistration.Attributes
{
    /// <summary>
    /// The <see cref="BaseAutoRegistration"/> attribute is not meant to be used directly and won't do anything. Use <see cref="Transient"/>, <see cref="Scoped"/>, or <see cref="Singleton"/> instead.
    /// </summary>
    public class BaseAutoRegistration : Attribute
    {
        public virtual short RegistrationPriority => 0;
    }
}
