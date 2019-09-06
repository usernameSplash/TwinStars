using UnityEngine;
using System.Collections;

public class Bomb : Bullet {
    // Use this for initialization
    void Start() {
        Invoke("DeleteSelf", 0.6f);
    }

    // Update is called once per frame
    void Update() {

    }

    void DeleteSelf() {
        Destroy(gameObject);
    }
}