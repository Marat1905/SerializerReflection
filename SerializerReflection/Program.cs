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

           

            foreach (int i in collectionSizes)
            {
                Logger.WriteTitle($"_______________Расчет сериализации тестового класса  {i.ToString("0,0")} раз_______________");

                TimingControl<string>.MeasureTime(() => SerializationToString.Serialize(testClass),i, "Расчет сериализации с помощью Reflection");

                TimingControl<string>.MeasureTime(() => JsonSerializer.Serialize(testClass), i, "Расчет сериализации с помощью JsonSerializer");

                Console.WriteLine(SerializationToString.Serialize(testClass));

                // указываем путь к файлу csv
                string pathCsvFile = "Test.csv";

                var rowsToDeserialize = File.ReadAllLines(pathCsvFile);
                var myCsvSerializer = new SerializationToCsv(",");
                var t = myCsvSerializer.Deserialize<Dev>(rowsToDeserialize);

                TimingControl<Dev>.MeasureTime(() => myCsvSerializer.Deserialize<Dev>(rowsToDeserialize), i, "Расчет десериализации с помощью SerializationToCsv");
                
                Console.WriteLine(SerializationToString.Serialize(myCsvSerializer.Deserialize<Dev>(rowsToDeserialize)));
            }
        }
    }
}
