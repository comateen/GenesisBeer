namespace _04_SRV.Interfaces
{
    public interface ILoggerService
    {
        void Debug(string message);
        void Info(string message);
        void Error(string message, Exception? ex = null);
    }
}
