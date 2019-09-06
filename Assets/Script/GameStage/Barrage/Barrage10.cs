using UnityEngine;
using System.Collections.Generic;

public class Barrage10 : Barrage {
    RepeatAction repeatAction;
    float error = 11f;

    bool isErrorUp = false;

    // Use this for initialization
    void Start() {
        repeatAction = new RepeatAction(0.7f, () => {
            GameObject obj = AddBullet(2, false);
            obj.transform.Translate(new Vector3(5.2f, 6.7f));
            obj.AddComponent<StrightBullet>();
            obj.GetComponent<StrightBullet>().setDirection(180 + 45 + error);
            obj.GetComponent<StrightBullet>().setSpeed(4.5f);

            obj = AddBullet(2, false);
            obj.transform.Translate(new Vector3(-5.2f, 6.7f));
            obj.AddComponent<StrightBullet>();
            obj.GetComponent<StrightBullet>().setDirection(270 + 45 + error);
            obj.GetComponent<StrightBullet>().setSpeed(4.5f);

            obj = AddBullet(1, false);
            obj.transform.Translate(new Vector3(-5.2f, -6.7f));
            obj.AddComponent<StrightBullet>();
            obj.GetComponent<StrightBullet>().setDirection(0 + 45 + error);
            obj.GetComponent<StrightBullet>().setSpeed(4.5f);

            obj = AddBullet(1, false);
            obj.transform.Translate(new Vector3(5.2f, -6.7f));
            obj.AddComponent<StrightBullet>();
            obj.GetComponent<StrightBullet>().setDirection(90 + 45 + error);
            obj.GetComponent<StrightBullet>().setSpeed(4.5f);

            if (isErrorUp) {
                error += 1.8f;
                if (error > 15f) {
                    isErrorUp = false;
                }
            }
            else {
                error -= 1.8f;
                if (error < -15f) {
                    isErrorUp = true;
                }
            }
        });
    }

    // Update is called once per frame
    void Update() {
        if (GameState.isGamePaused) return;

        repeatAction.Update();
    }

}
