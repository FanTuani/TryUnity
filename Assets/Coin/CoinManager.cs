using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinManager : MonoBehaviour {
    public static CoinManager instance;
    public int targetCoinNum = 5;
    public GameObject coinTemplate;

    private int collectedCoinNum = 0;

    private void Start() {
        if (instance == null) {
            instance = this;
        }

        for (int i = 0; i < targetCoinNum; i++) {
            spawnCoinRandomly();
        }
    }

    private void Update() {
        // if (Input.GetMouseButtonDown(0)) {
        //     Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     position.z = 0;
        //     spawnCoin(position);
        // }
    }

    private GameObject spawnCoin(Vector3 position) {
        GameObject coin = Instantiate(coinTemplate);
        coin.transform.position = position;
        return coin;
    }

    private GameObject spawnCoinRandomly() {
        GameObject coin = Instantiate(coinTemplate);

        Vector2 randomScreenPosition =
            new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));

        Vector3 position = Camera.main.ScreenToWorldPoint(randomScreenPosition);
        position.z = 0f;

        coin.transform.position = position;
        return coin;
    }

    public int collectCoin(int num) {
        collectedCoinNum += num;
        if (collectedCoinNum == targetCoinNum) {
            GameManager.instance.winGame();
        }

        spawnCoinRandomly();

        return collectedCoinNum;
    }
}