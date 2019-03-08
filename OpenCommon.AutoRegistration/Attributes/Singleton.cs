namespace OpenCommon.AutoRegistration.Attributes
{
    /// <summary>
    /// Use to only create a single instance per lifetime scope when injected.
    /// </summary>
    public class Singleton : BaseAutoRegistration
    {
        public override short RegistrationPriority => 3;
    }
}
