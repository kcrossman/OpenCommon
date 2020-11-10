namespace OpenCommon.DependencyInjection.Attributes
{
    /// <summary>
    /// Use to always create a new instance when injected.
    /// </summary>
    public class Transient : RegistrationAttribute
    {
        public override short RegistrationPriority => 1;
    }
}
