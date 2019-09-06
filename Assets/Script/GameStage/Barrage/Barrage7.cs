using UnityEngine;
using System.Collections;

public class Barrage7 : Barrage {
    float dir = 0;

    int color_parameter = 1;

    RepeatAction repeatAction;

    // Use this for initialization
    void Start() {
        repeatAction = new RepeatAction(0.9f, () => {
            for (int i = 0; i < 4; i++) {
                GameObject obj = AddBullet(color_parameter, false);
                if (color_parameter == 1) {
                    color_parameter++;
                }
                else if (color_parameter == 2) {
                    color_parameter--;
                }

                obj.AddComponent<CurvedBullet>();

                obj.GetComponent<CurvedBullet>().setDirection(dir + 90 * i);
                obj.GetComponent<CurvedBullet>().setSpeed(4);
                obj.GetComponent<CurvedBullet>().setRotation(-0.5f);
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
