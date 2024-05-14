using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ParticleManager : MonoBehaviour {
    public static ParticleManager instance;
    public GameObject coinParTemp;

    void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    public void spawnCoinParticle(Vector3 position) {
        int parNum = 8;
        for (int i = 0; i < parNum; i++) {
            GameObject particle = Instantiate(coinParTemp);
            particle.transform.position = position;
            var rb = particle.GetComponent<Rigidbody2D>();
            var dir = new Vector2(500, 0);
            dir = Quaternion.Euler(0, 0, 360f / parNum * i) * dir;
            SpriteRenderer renderer = particle.GetComponent<SpriteRenderer>();
            DOTween.To(() => renderer.color.a,
                val => {
                    var color = renderer.color;
                    color.a = val;
                    renderer.color = color;
                }, 0, 0.5f);
            new Timer().runTaskLater(() => {
                Destroy(particle);
            }, 0.5f);
            rb.AddForce(dir);
        }
    }
}