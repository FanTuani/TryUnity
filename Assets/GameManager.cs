using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    private void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    public void winGame() {
        Debug.Log("Win");
    }
}