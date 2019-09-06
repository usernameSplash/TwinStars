using UnityEngine;
using System.Collections;

public class Barrage8 : Barrage {
    RepeatAction repeatAction;

    float lastHolePosition;
    // Use this for initialization
    void Start() {
        lastHolePosition = 0;
        repeatAction = new RepeatAction(3f, () => {
            lastHolePosition = Mathf.Max(Mathf.Min(3.5f, lastHolePosition), -3.5f);
            lastHolePosition = Random.value * 4 - 2 + lastHolePosition;
            lastHolePosition = Mathf.Min(5.5f, Mathf.Max(-5.5f, lastHolePosition));

            for (float x = -5.3f; x < 5.5f; x += 0.4f) {
                if(Mathf.Abs(x - lastHolePosition) > 0.7f) {
                    GameObject obj = AddBullet(4, true);
                    obj.transform.Translate(new Vector3(x, 6.8f));
                    obj.AddComponent<StrightBullet>();
                    obj.GetComponent<StrightBullet>().setDirection(270);
                    obj.GetComponent<StrightBullet>().setSpeed(5);
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
