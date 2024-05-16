using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour {
    public static HashSet<Timer> timers;

    void Start() {
        timers = new HashSet<Timer>();
    }

    void Update() {
        List<Timer> removeTimers = new List<Timer>();
        foreach (Timer timer in timers) {
            timer.coolDown -= Time.deltaTime;
            if (timer.coolDown <= 0) {
                removeTimers.Add(timer);
                if (!gameObject || !gameObject.activeSelf) continue;
                timer.action();
            }
        }

        foreach (Timer timer in removeTimers) {
            timers.Remove(timer);
        }
    }
}