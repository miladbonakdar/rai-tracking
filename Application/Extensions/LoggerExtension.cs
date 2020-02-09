using System;
using Serilog;

namespace Application.Extensions
{
    public static class LoggerExtension
    {
        public static void Error(this ILogger logger, Exception e) =>
            logger.Error($"Error With Exception : {e.Message}\n" +
                         $"At : {DateTime.Now}\n" +
                         $"Details : ${e}");

        public static void Fatal(this ILogger logger, Exception e) =>
            logger.Error($"!!!FATAL!!! Error With Exception : {e.Message}\n" +
                         $"At : {DateTime.Now}\n" +
                         $"Details : ${e}");
    }
}