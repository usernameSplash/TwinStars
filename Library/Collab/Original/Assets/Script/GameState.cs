using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    //게임이 몇 스테이지인지를 의미함
    public static int StageLevel = 1;

    //게임이 멈추었는지를 의미함. 일시정지 뿐만 아니라 클리어 등도 포함함
    public static bool isGamePaused = false;

    //이게 true일경우 게임 오버
    public static bool isGameOver = false;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
