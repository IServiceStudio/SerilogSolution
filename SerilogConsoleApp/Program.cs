using Serilog;

namespace SerilogConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void HelloSerilog()
        {
            using var log =
                   //构建一个日志记录管道
                   new LoggerConfiguration()
                   //将控制器添加到日志记录管道中
                   .WriteTo.Console()
                   //创建日志对象
                   .CreateLogger();
            log.Information("Hello,Serilog!");
            log.Warning("Goodbye,Serilog.");

            var itemNumber = 10;
            var itemCount = 999;
            log.Debug("Processing item {ItemNumber} of {ItemCount}", itemNumber, itemCount);

            var user = new { Name = "Nick", Id = "nblumhardt" };
            log.Information("Logged on user {@User}", user);
        }

        private static void StaticSerilog()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Information("Hello again, Serilog!");
            var itemNumber = 10;
            var itemCount = 999;
            Log.Information("Processing item {ItemNumber} of {ItemCount}", itemNumber, itemCount);
            Log.CloseAndFlush();
        }
    }
}
