namespace OpenCommon.DependencyInjection.Attributes
{
    /// <summary>
    /// Use to create a single instance per request scope when injected.
    /// </summary>
    public class Scoped : RegistrationAttribute
    {
        public override short RegistrationPriority => 2;
    }
}
