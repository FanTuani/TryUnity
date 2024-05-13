using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public TextMeshProUGUI coinText;
    private float timer;

    void Start() {
        timer = 0;
    }

    void Update() {
        if (CoinManager.instance.collectedCoinNum >= CoinManager.instance.targetCoinNum) {
            coinText.SetText(Math.Round(timer, 2).ToString(CultureInfo.InvariantCulture));
        } else {
            timer += Time.deltaTime;
            coinText.SetText(CoinManager.instance.collectedCoinNum.ToString());
        }
    }
}