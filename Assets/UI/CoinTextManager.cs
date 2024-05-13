using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoinTextManager : MonoBehaviour {
    public static CoinTextManager instance;
    public TextMeshProUGUI coinText;
    private float timer;

    void Start() {
        if (instance == null) {
            instance = this;
        }

        timer = 0;
    }

    void Update() {
        timer += Time.deltaTime;
    }

    private bool hasScore;

    public void updateCoinText() {
        if (hasScore) return;
        if (CoinManager.instance.collectedCoinNum >= CoinManager.instance.targetCoinNum) {
            hasScore = true;
            coinText.SetText(Math.Round(timer, 2).ToString(CultureInfo.InvariantCulture));
            DOTween.To(() => coinText.fontSize,
                val => coinText.fontSize = val, 46, 0.1f);
            DOTween.To(() => coinText.fontSize,
                    val => coinText.fontSize = val, 30, 1f)
                .SetDelay(0.1f);
        } else {
            coinText.SetText(CoinManager.instance.collectedCoinNum.ToString());
            DOTween.To(() => coinText.fontSize,
                val => coinText.fontSize = val, 32, 0.1f);
            DOTween.To(() => coinText.fontSize,
                    val => coinText.fontSize = val, 22, 0.4f)
                .SetDelay(0.1f);
        }
    }
}