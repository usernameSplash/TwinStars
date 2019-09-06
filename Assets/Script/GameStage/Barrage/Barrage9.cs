using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barrage9 : Barrage {
    RepeatAction addAction;
    RepeatAction shootAction;

    List<float> lineList = new List<float>();

    // Use this for initialization
    void Start() {
        addAction = new RepeatAction(2, () => {
            lineList.Add(Random.value + 0.1f);
            lineList.Add(-Random.value - 0.1f);
        });
        shootAction = new RepeatAction(0.65f, () => {
            for (int i = 0; i < lineList.Count; i++) {
                GameObject obj = AddBullet(1, false);

                obj.transform.Translate(new Vector3(0, 6.7f));
                obj.AddComponent<StrightBullet>();
                obj.GetComponent<StrightBullet>().setDirection(270 + lineList[i]);
                obj.GetComponent<StrightBullet>().setSpeed(4.5f);

                if (lineList[i] < 0) {
                    lineList[i] -= 9f;
                }
                else {
                    lineList[i] += 9f;
                }

                if (Mathf.Abs(lineList[i]) >= 90) {
                    lineList.RemoveAt(i);
                    i--;
                }
            }
        });
    }

    // Update is called once per frame
    void Update() {
        if (GameState.isGamePaused) return;

        shootAction.Update();
        addAction.Update();
    }
}
