using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage21 : Barrage {

    float dir = 0.0f;
    int color = 1;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Action", 0.2f, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Action()
    {
        if (GameState.isGamePaused)
            return;

        for (int i = 0; i < 12; i++)
        {
            GameObject obj = AddBullet(color, false);

            obj.AddComponent<ReflectBullet>();
            obj.GetComponent<ReflectBullet>().setDirection(dir + i * 30);
            obj.GetComponent<ReflectBullet>().setSpeed(3);
            obj.GetComponent<ReflectBullet>().setAcc(0.02f);
            obj.GetComponent<ReflectBullet>().setMaxReflectCount(2);

        }
        if(color == 1)
        {
            color = 2;
        }
        else if(color == 2)
        {
            color = 1;
        }
    }
}
