using UnityEngine;

public static class TimeScaleController
{
    public static void SetTimeScale(int targetTime) => Time.timeScale = targetTime;
}
