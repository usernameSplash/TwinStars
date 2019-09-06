using UnityEngine;
using System.Collections;

public class Barrage6 : Barrage {
    float acTime = 0;
    RepeatAction repeatAction;
    float dir = 0;

    // Use this for initialization
    void Start() {
        repeatAction = new RepeatAction(0.85f, () => {
            for (int i = 0; i < 3; i++) {

                GameObject obj = AddBullet(1, false);

                obj.AddComponent<CurvedBullet>();

                obj.GetComponent<CurvedBullet>().setDirection(dir + 120 * i);
                obj.GetComponent<CurvedBullet>().setSpeed(4);
                obj.GetComponent<CurvedBullet>().setRotation(-0.4f);
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
