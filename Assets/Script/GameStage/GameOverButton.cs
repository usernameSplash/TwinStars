using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickRestart()
    {
        GameState.isGamePaused = false;
        GameState.isGameOver = false;
        GameState.isGameClear = false;
        PauseButton.isInit = false;
        GameOverPanel.isInit = false;
        GameClearPanel.isInit = false;
        SceneManager.LoadScene("GameStage");
    }

    public void onClickQuit()
    {
        GameState.isGamePaused = false;
        GameState.isGameOver = false;
        GameState.isGameClear = false;
        PauseButton.isInit = false;
        GameOverPanel.isInit = false;
        GameClearPanel.isInit = false;
        SceneManager.LoadScene("Main");
    }
}
