using System;
using UnityEngine;

public class Timer {
    public Action action;
    public float coolDown;
    public GameObject gameObject;

    // public Timer() {
    //     TimerManager.timers.Add(this);
    // }
    public Timer() {
        TimerManager.timers.Add(this);
    }

    public void runTaskLater(Action action, GameObject gameObject, float coolDown) {
        this.gameObject = gameObject;
        this.action = action;
        this.coolDown = coolDown;
    }
}