using System;
using UnityEngine;

public class Timer {
    public Action action;
    public float coolDown, originCD;
    public GameObject gameObject;

    // public Timer() {
    //     TimerManager.timers.Add(this);
    // }
    public Timer() {
        TimerManager.timers.Add(this);
    }

    public Timer runTaskLater(Action action, GameObject gameObject, float coolDown) {
        this.gameObject = gameObject;
        this.action = action;
        this.originCD = this.coolDown = coolDown;
        return this;
    }

    public void resetTime() {
        this.coolDown = this.originCD;
    }

    public void resetTime(float coolDown) {
        this.coolDown = this.originCD = coolDown;
    }

    public bool exist() {
        return TimerManager.timers.Contains(this);
    }
}