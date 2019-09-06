using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage22 : Barrage {

    float dir = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Action", 0.0f, 3.0f);
        InvokeRepeating("Action2", 1.5f, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Action()
    {
        if (GameState.isGamePaused)
            return;
        for (int i = 0; i < 18; i++)
        {
            GameObject obj = AddBullet(4, false);
            obj.AddComponent<CurvedBullet>();
            obj.GetComponent<CurvedBullet>().setDirection(dir + i * 20);
            obj.GetComponent<CurvedBullet>().setSpeed(4);
            obj.GetComponent<CurvedBullet>().setAcc(0.055f);
            obj.GetComponent<CurvedBullet>().setRotAcc(0.033f);
            obj.GetComponent<CurvedBullet>().setRotation(0f);
        }
    }

    void Action2()
    {
        if (GameState.isGamePaused)
            return;
        for(int i = 0; i < 12; i++)
        {
            GameObject obj = AddBullet(3, true);
            obj.AddComponent<StrightBullet>();
            obj.GetComponent<StrightBullet>().setDirection(dir + i * 30);
            obj.GetComponent<StrightBullet>().setSpeed(0);
            obj.GetComponent<StrightBullet>().setAcc(0.3f);
        }
    }
}
