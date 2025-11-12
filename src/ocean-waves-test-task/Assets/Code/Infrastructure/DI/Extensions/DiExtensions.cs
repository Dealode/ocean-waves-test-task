using VContainer;

namespace Code.Infrastructure.DI.Extensions
{
    public static class DiExtensions
    {
        public static T Instantiate<T>(this IObjectResolver resolver) => 
            (T)resolver.Resolve(new RegistrationBuilder(typeof(T), Lifetime.Transient).Build());
    }
}