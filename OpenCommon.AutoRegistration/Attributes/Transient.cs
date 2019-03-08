namespace OpenCommon.AutoRegistration.Attributes
{
    /// <summary>
    /// Use to always create a new instance when injected.
    /// </summary>
    public class Transient : BaseAutoRegistration
    {
        public virtual short RegistrationSequence => 1;
    }
}
