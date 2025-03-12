using System.Diagnostics;

namespace SerializerReflection.Extensions
{
    internal static class TimingControl<T>
    {
        public delegate T TimingDelegate();

        public static void MeasureTime(TimingDelegate TimingDelegate, int NumberOfIterations, string calculationType)
        {
            Stopwatch sw = Stopwatch.StartNew();

            sw.Start();
            for (int i = 0; i < NumberOfIterations; i++)
            {
                var result = TimingDelegate();
            }
            sw.Stop();

            Console.WriteLine();
            Logger.WriteDescription("Тип расчета", $"{calculationType}");
            Logger.WriteDescription("Затраченное время", $"{sw.ElapsedMilliseconds} мс");
        }
    }

}
