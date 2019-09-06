using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage17 : Barrage {
    
    float dir = 45;
    

	// Use this for initialization
	void Start () {

        InvokeRepeating("Action", 0, 0.6f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Action()
    {
        if (GameState.isGamePaused) return;

        for(int i = 0; i < 4; i++)
        {
            GameObject obj = AddBullet(1, false);

            obj.AddComponent<CurvedBullet>();
            obj.GetComponent<CurvedBullet>().setSpeed(4);
            obj.GetComponent<CurvedBullet>().setRotation(0.75f);
            obj.GetComponent<CurvedBullet>().setDirection(90 * i + dir);
        }

        for(int i = 0; i < 4; i++)
        {
            GameObject obj = AddBullet(2, false);

            obj.AddComponent<CurvedBullet>();
            obj.GetComponent<CurvedBullet>().setSpeed(4);
            obj.GetComponent<CurvedBullet>().setRotation(-0.75f);
            obj.GetComponent<CurvedBullet>().setDirection(90 * i - dir);
        }
        dir += 7f;
        dir %= 360f;
    }
}
