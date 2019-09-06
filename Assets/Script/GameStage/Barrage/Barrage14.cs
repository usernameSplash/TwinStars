using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage14 : Barrage {

    float acTime = 0;

    float dir = 0;

    int color_parameter = 1;

    RepeatAction repeatAction;

    // Use this for initialization
    void Start () {
        repeatAction = new RepeatAction(0.7f, () => {
            for (int i = 0; i < 6; i++)
            {
                GameObject obj = AddBullet(color_parameter, false);
                if (i < 3)
                {
                    color_parameter = 1;
                }
                else if (i >= 3)
                {
                    color_parameter = 2;
                }

                obj.AddComponent<CurvedBullet>();

                obj.GetComponent<CurvedBullet>().setDirection(dir + 60 * i);
                obj.GetComponent<CurvedBullet>().setSpeed(4);
                obj.GetComponent<CurvedBullet>().setRotation(1.0f);
            }
            dir += 23;
        });
    }
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused) return;
        repeatAction.Update();
	}
}
