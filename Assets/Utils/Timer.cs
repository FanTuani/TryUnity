using System;
using UnityEngine;

public class Timer {
    public Action action;
    public float coolDown;
    public GameObject gameObject;

    // public Timer() {
    //     TimerManager.timers.Add(this);
    // }
    public Timer(GameObject gameObject) {
        this.gameObject = gameObject;
        TimerManager.timers.Add(this);
    }

    public void runTaskLater(Action action, float coolDown) {
        this.action = action;
        this.coolDown = coolDown;
    }
}