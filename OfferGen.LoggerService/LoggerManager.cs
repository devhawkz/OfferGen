﻿using NLog;
using OfferGen.Contracts;

namespace OfferGen.LoggerService;

public class LoggerManager : ILoggerManager
{
    private static ILogger _logger = LogManager.GetCurrentClassLogger();
    public void LogDebug(string message) => _logger.Debug(message);
    public void LogError(string message) => _logger.Error(message);
    public void LogInfo(string message) => _logger.Info(message);
    public void LogWarn(string message) => _logger.Warn(message);

    public void LogTrace(string message) => _logger.Trace(message);
}
