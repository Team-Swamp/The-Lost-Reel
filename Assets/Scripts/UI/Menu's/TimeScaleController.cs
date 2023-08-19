using UnityEngine;

public static class TimeScaleController
{
    public static void SetTimeScaleOnActive() => Time.timeScale = 1;

    public static void SetTimeScaleOnInactive() => Time.timeScale = 0;
}
