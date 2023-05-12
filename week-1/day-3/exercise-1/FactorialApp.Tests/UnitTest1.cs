using System;
using System.IO;

class FileLogger : IDisposable
{
    private StreamWriter _writer;
    private bool _disposed = false;

    public FileLogger(string filePath)
    {
        _writer = new StreamWriter(filePath, true);
    }

    public void Log(string message)
    {  
        if (_disposed)
        {
            throw new ObjectDisposedException("FileLogger", "Cannot write to a disposed FileLogger instance.");
        }

        _writer.WriteLine($"{DateTime.Now}: {message}");
    }


    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _writer.Dispose();
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~FileLogger()
    {
        Dispose(false);
    }
}
class Program
{
    static void Main(string[] args)
    {
        using (var logger = new FileLogger("log.txt"))
        {
            logger.Log("Log entry 1");
            logger.Log("Log entry 2");
            logger.Log("Log entry 3");
        }

        Console.WriteLine("Log entries written. FileLogger disposed.");
    }
}
