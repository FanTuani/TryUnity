using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateBall : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != "Player") {
            return;
        }

        Player player = other.gameObject.GetComponent<Player>();
        player.speedEffect(100, 2);
    }
}