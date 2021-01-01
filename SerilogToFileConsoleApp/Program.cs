using Serilog;
using Serilog.Formatting.Compact;

namespace SerilogToFileConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialSerilog();
        }

        private static void InitialSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(new CompactJsonFormatter(), "log.clef")
                .CreateLogger();

            var itemCount = 99;
            for (var itemNumber = 0; itemNumber < itemCount; ++itemNumber)
                Log.Debug("Processing item {ItemNumber} of {ItemCount}", itemNumber, itemCount);

            Log.CloseAndFlush();
        }
    }
}
