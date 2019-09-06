using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage19 : Barrage {
    float dir = 0;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Action", 0.2f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Action()
    {
        if (GameState.isGamePaused)
            return;
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                GameObject obj = AddBullet(4, false);
                obj.AddComponent<StrightBullet>();
                obj.GetComponent<StrightBullet>().setDirection(dir + (i + 1) * 90);
                obj.GetComponent<StrightBullet>().setSpeed((j + 1) * 1f);
            }
        }
        dir += 20.0f;
    }
}
