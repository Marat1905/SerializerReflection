using SerializerReflection.Classes;
using SerializerReflection.Extensions;
using System.Reflection.Emit;
using System.Text.Json;

namespace SerializerReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> collectionSizes = [100_000, 1_000_000, 10_000_000];
            PrintInfoPC.PrintSystemInfo();

            var testClass = new F().Get();

            Console.WriteLine(SerializationToString.Serialize(testClass));

            foreach (int i in collectionSizes)
            {
                Logger.WriteTitle($"_______________Расчет сериализации  {i.ToString("0,0")} раз_______________");

                TimingControl<string>.MeasureTime(() => SerializationToString.Serialize(testClass),i, "Расчет сериализации с помощью Reflection");

                TimingControl<string>.MeasureTime(() => JsonSerializer.Serialize(testClass), i, "Расчет сериализации с помощью JsonSerializer");
            }
        }
    }
}
