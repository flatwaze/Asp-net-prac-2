using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;

namespace WebStore.Logger
{
    public static class Log4NetExtensions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory Factory, string ConfigurationFile = "log4net.config")
        {
            if (!Path.IsPathRooted(ConfigurationFile))
            {
                var assembly = Assembly.GetEntryAssembly()
                               ?? throw new InvalidOperationException("Не удалось определить сборку");

                var dir = Path.GetDirectoryName(assembly.Location)
                          ?? throw new InvalidOperationException("Не удалось определить каталог");

                ConfigurationFile = Path.Combine(dir, ConfigurationFile);
            }

            Factory.AddProvider(new Log4NetProvider(ConfigurationFile));

            return Factory;
        }
    }
}
