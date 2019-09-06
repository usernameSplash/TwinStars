using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //    GameState.isGamePaused = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) && (!GameState.isGameOver && !GameState.isGameClear)) {
            if (GameState.isGamePaused) { GameState.isGamePaused = false; PauseButton.isInit = false; }
            else GameState.isGamePaused = true;
        }
	}
}
