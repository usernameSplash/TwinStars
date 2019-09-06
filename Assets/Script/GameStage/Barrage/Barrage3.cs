using UnityEngine;
using System.Collections;

public class Barrage3 : Barrage {
    RepeatAction repeatAction;

    // Use this for initialization
    void Start() {
        repeatAction = new RepeatAction(0.85f, () => {
            GameObject obj = AddBullet(2, true);

            obj.AddComponent<StrightBullet>();

            obj.GetComponent<StrightBullet>().setDirection(Random.value * 360);
            obj.GetComponent<StrightBullet>().setSpeed(3);
        });
    }

    // Update is called once per frame
    void Update() {
        if (GameState.isGamePaused) return;
        repeatAction.Update();
    }
}
