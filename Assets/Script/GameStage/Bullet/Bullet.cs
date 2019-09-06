using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public bool shouldDeleteOnOutBorder = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused && !GameState.isGameOver) {
            GetComponent<Animator>().enabled = false;
            return;
        }

        GetComponent<Animator>().enabled = true;

        if (transform.position.magnitude > 20) {
            Destroy(gameObject);
        }
    }
}
