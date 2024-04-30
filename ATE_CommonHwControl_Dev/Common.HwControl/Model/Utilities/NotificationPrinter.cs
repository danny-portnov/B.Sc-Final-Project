using LoggerClient;
using System;

namespace Common.HwControl.Model.Utilities
{
    public static class NotificationPrinter
    {
        public static event Action<string> printNotification;
        public static event Action<string> StatusUpdated;
        public static event EventHandler clearTextBox;


        public static void Print(string message) => printNotification.Invoke($"{message} \r\n");
        public static void Clear() => clearTextBox.Invoke(default, EventArgs.Empty);

        public static void UpdateStatus(string text) => StatusUpdated.Invoke(text);
        public static void EventSubsribed(string eventhandlerName, Delegate eventHandler)
        {
            Print($"New subscriber was added to {eventhandlerName}. View logger for more details.");
            CLoggerClient.Log((char)LogType.Debug,
            $"New subscriber, {eventHandler.Method.Name} from class {eventHandler.Target}, was added to {eventhandlerName}");
        }
    }
}