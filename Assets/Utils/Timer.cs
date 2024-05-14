using System;
using UnityEngine;

public class Timer {
    public Action action;
    public float coolDown;

    public Timer() {
        TimerManager.timers.Add(this);
    }

    public void runTaskLater(Action action, float coolDown) {
        this.action = action;
        this.coolDown = coolDown;
    }
}