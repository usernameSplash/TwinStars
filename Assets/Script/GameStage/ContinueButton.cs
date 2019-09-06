using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickContinue()
    {
        GameClearPanel.isInit = false;
        GameOverPanel.isInit = false;
        PauseButton.isInit = false;
        GameState.StageLevel++;
        SceneManager.LoadScene("GameStage");
    }
}
