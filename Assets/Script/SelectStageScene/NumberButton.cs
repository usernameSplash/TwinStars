using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumberButton : MonoBehaviour {
    public int StageNumber { get; set; }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClickNumber()
    {
        GameState.StageLevel = StageNumber;
        SelectStageScene.isStarted = true;
    }
}
