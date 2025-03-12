using SerializerReflection.Classes;

namespace SerializerReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testClass = new F().Get();

            Console.WriteLine(MySerializer.Serialize(testClass));
        }
    }
}
