﻿using _04_SRV.Interfaces;
using log4net;
using System.Reflection;

namespace _04_SRV.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILog _logger;
        public LoggerService()
        {
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        }
        public void Debug(string message)
        {
            _logger?.Debug(message);
        }
        public void Info(string message)
        {
           _logger?.Info(message);
        }
        public void Error(string message, Exception? ex = null)
        {
            _logger?.Error(message, ex?.InnerException);
        }
    }
}
