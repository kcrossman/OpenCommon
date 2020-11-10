namespace OpenCommon.DependencyInjection.Attributes
{
    /// <summary>
    /// Use to only create a single instance per lifetime scope when injected.
    /// </summary>
    public class Singleton : RegistrationAttribute
    {
        public override short RegistrationPriority => 3;
    }
}
