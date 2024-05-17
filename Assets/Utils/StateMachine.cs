using System;
using UnityEngine;

public class StateMachine : MonoBehaviour {
    public IState currentState;

    public void changeState(PlayerStates newState) {
        currentState?.exit();
        // currentState = newState;
        currentState.enter();
    }

    private void Update() {
        currentState.stay();
    }
}