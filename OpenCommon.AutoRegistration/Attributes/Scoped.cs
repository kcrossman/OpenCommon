namespace OpenCommon.AutoRegistration.Attributes
{
    /// <summary>
    /// Use to create a single instance per request scope when injected.
    /// </summary>
    public class Scoped : BaseAutoRegistration
    {
        public override short RegistrationPriority => 2;
    }
}
