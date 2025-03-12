using System.Reflection;

namespace SerializerReflection
{
    /// <summary>Класс для сериализации в строку</summary>
    public static class SerializationToString
    {
        /// <summary>Сериализатор в строку</summary>
        /// <typeparam name="T">Тип класса</typeparam>
        /// <param name="instance">Объект класса</param>
        /// <returns>Возвращаем строку</returns>
        public static string Serialize<T>(T instance)
        {
            var fields = instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            return string.Format("{{{0}}}", string.Join(" ", fields.Select(x => string.Format("{0} = {1};", x.Name.Replace("k__BackingField", String.Empty), x.GetValue(instance)))));
        }
    }
}
