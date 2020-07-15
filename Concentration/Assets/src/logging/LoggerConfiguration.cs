/*using UnityEngine;
using log4net.Config;
using System.IO;

public static class LoggerConfiguration 
{
    public const string LOGGER_FILE = "LoggerConfig.xml";
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void ConfigureLogging()
    {
        XmlConfigurator.Configure(new FileInfo($"{Application.dataPath}/{LOGGER_FILE}"));
    }
}
*/