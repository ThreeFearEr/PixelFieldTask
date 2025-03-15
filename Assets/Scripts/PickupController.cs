using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupController : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") && collider.enabled) {
            collider.enabled = false;// <-- handles double trigger case together with "&& collider.enabled" check
            ScoreManager.Instance.AddScore(1);
            AudioManager.Instance.PlayAudio("pickup");
            Destroy(gameObject);
        }
    }
}
