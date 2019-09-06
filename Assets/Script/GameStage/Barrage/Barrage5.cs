using UnityEngine;
using System.Collections;

public class Barrage5 : Barrage {
    

    RepeatAction repeatAction;
    // Use this for initialization
    void Start() {
        repeatAction = new RepeatAction(3f, () => {

            for (float d = 0; d < 360; d += 45) {
                GameObject obj = AddBullet(2, true);
                obj.AddComponent<StrightBullet>();

                obj.GetComponent<StrightBullet>().setDirection(d);
                obj.GetComponent<StrightBullet>().setSpeed(3.5f);
            }

        });
    }

    // Update is called once per frame
    void Update() {
        if (GameState.isGamePaused) return;
        repeatAction.Update();
    }
}
