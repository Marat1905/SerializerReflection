using System.Reflection;

namespace SerializerReflection
{
    public class MySerializer
    {
        public static string Serialize<T>(T obj)
        {
            var fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            return string.Format("{{{0}}}", string.Join(" ", fields.Select(x => string.Format("{0} = {1};", x.Name, x.GetValue(obj)))));
        }
    }
}
