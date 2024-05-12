using System;
using UnityEngine;

public class Timer : MonoBehaviour {
    private Action action;
    private float coolDown;
    private float interval, invCoolDown;

    public void runTaskLater(Action action, float coolDown) {
        this.action = action;
        this.coolDown = coolDown;
    }

    public void runTaskTimer(Action action, float coolDown, float interval) {
        this.action = action;
        this.coolDown = coolDown;
        this.interval = interval;
        this.invCoolDown = interval;
    }

    private void Update() {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0) {
            if (interval == 0) {
                action();
                Destroy(this);
            }
            else {
                invCoolDown -= Time.deltaTime;
                if (invCoolDown <= 0) {
                    action();
                    invCoolDown = interval;
                }
            }
        }
    }
}