using Common.HwControl.Model.Utilities;
using LoggerClient;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Common.HwControl.Model
{
    public static class CommonHwExceptionHandler
    {
        public static event Action<string> HwExeptionRaised;

        public static void PrintExceptionMessageToLogger(Exception ex, string message = default, [CallerMemberName] string methodName = default,
                     [CallerLineNumber] int lineNumber = default, [CallerFilePath] string filePath = default)
        { //todo: add printing full stack trace to logger / make it work for tasks (with correct line and class for each frame).
            StackTrace stackTrace = new(ex);
            if (stackTrace.FrameCount != 0)
            {
                Match match = Regex.Match(ex.StackTrace, @"line\s+(\d+)");
                if (match.Success)
                {
                    lineNumber = int.Parse(match.Groups[1].Value);
                }
            }
            string className = Regex.Match(filePath, @"(\w*).cs").Groups[1].Value; //parses the class name from the filepath
            string detailedMessage = $"An exception occurred at {methodName} in {className} class";
            message = string.IsNullOrEmpty(message) ? detailedMessage : detailedMessage + $", {message}";
            string shortMessageForUser = $"{DateTime.Now}: {message}. Please check logger. \r\n";
            if (HwExeptionRaised is null)
            {
                MessageBox.Show(shortMessageForUser);
            }
            else
            {
                HwExeptionRaised.Invoke(shortMessageForUser);
            }
            CLoggerClient.Log((char)LogType.Error, $"{message} at line {lineNumber}. Exception: {ex.Message}");
        }
    }
}