using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimerSetter : MonoBehaviour {
    public int minutes;
    public int seconds;
    public int milliSeconds;

    public void ResetTimer()
    {
        DataPersistor.persist.mTime.minutes = minutes;
        DataPersistor.persist.mTime.seconds = seconds;
        DataPersistor.persist.mTime.milliseconds = milliSeconds;
    }
}
