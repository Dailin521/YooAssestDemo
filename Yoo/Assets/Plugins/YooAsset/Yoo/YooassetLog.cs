using System;
using YooAsset;

public class YooassetLog : ILogger {
    public void Error(string message) {
        UnityEngine.Debug.LogError(message);
    }

    public void Exception(Exception exception) {
        UnityEngine.Debug.LogException(exception);
    }

    public void Log(string message) {

    }

    public void Warning(string message) {
        UnityEngine.Debug.LogWarning(message);
    }
}
