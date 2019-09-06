using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageDummy3 : Barrage {

    float acTime = 0;

    float dir = 0;

    int color_parameter = 1;

    RepeatAction repeatAction;
    // Use this for initialization
    void Start () {
        repeatAction = new RepeatAction(0.04f, () =>
        {
            GameObject obj = AddBullet(Random.Range(1, 5), false);
            obj.AddComponent<StrightBullet>();
            obj.GetComponent<StrightBullet>().setDirection(Random.Range(0.0f, 360.0f));
            obj.GetComponent<StrightBullet>().setSpeed(Random.Range(1.0f, 8.0f));
        });
	}
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused) return;
        repeatAction.Update();
	}
}
