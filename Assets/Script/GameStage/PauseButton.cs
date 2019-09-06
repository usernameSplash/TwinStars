using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour {

    public GameObject initial;
    public static bool isInit = false;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(!isInit)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(initial, new BaseEventData(EventSystem.current));            
            isInit = true;
        }
	}

    public void onClickContinue()
    {
        isInit = false;
        GameState.isGamePaused = false;
    }

    public void onClickRestart()
    {
        isInit = false;
        GameState.isGamePaused = false;
        SceneManager.LoadScene("GameStage");
    }

    public void onClickQuit()
    {
        isInit = false;
        GameState.isGamePaused = false;
        SceneManager.LoadScene("Main");
    }
}
