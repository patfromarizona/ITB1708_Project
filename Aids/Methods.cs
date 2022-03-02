using System.Reflection;

namespace TeamUP.Aids
{
    public static class Methods
    {
        public static bool HasAttribute<TAttribute>(this Type? t) where TAttribute : Attribute 
            => Safe.Run(() => t?.GetCustomAttributes<TAttribute>()?.FirstOrDefault() is not null, false);
    }

}
