using System;

namespace Logger.Core
{
    public interface ILogModel
    {
        TimeSpan Time { get; set; }
        LogLevel Level { get; set; }
        string Message { get; set; }
        string FilePath { get; set; }
        int LineNumber { get; set; }
        string Origin { get; set; }
    }
}
