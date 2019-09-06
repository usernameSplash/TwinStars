using UnityEngine;
using System.Collections;

public class Barrage4 : Barrage {
    RepeatAction repeatAction;
    float dir = 0;

    // Use this for initialization
    void Start() {
        repeatAction = new RepeatAction(1f, () => {
            for (int i = 0; i < 3; i++) {
                GameObject obj = AddBullet(2, false);

                obj.AddComponent<StrightBullet>();

                obj.GetComponent<StrightBullet>().setDirection(dir + 120 * i);
                obj.GetComponent<StrightBullet>().setSpeed(3.5f);
            }
            dir += 17;
        });
    }

    // Update is called once per frame
    void Update() {
        if (GameState.isGamePaused) return;
        repeatAction.Update();
    }
}
