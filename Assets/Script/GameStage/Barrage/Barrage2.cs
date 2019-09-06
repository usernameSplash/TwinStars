using UnityEngine;
using System.Collections;

public class Barrage2 : Barrage {
    RepeatAction repeatAction;
    // Use this for initialization
    void Start() {
        repeatAction = new RepeatAction(1f, () => {
            GameObject obj = AddBullet(1, true);
            obj.transform.Translate(new Vector3(-5.5f, 4.0f));
            obj.AddComponent<StrightBullet>();
            obj.GetComponent<StrightBullet>().setDirection(0);
            obj.GetComponent<StrightBullet>().setSpeed(4);


            obj = AddBullet(1, true);
            obj.transform.Translate(new Vector3(-5.5f, -4.0f));
            obj.AddComponent<StrightBullet>();
            obj.GetComponent<StrightBullet>().setDirection(0);
            obj.GetComponent<StrightBullet>().setSpeed(4);
        });
    }

    // Update is called once per frame
    void Update() {
        if (GameState.isGamePaused) return;

        repeatAction.Update();
    }
}
