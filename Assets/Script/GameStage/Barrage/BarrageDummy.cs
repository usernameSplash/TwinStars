using UnityEngine;
using System.Collections;

public class BarrageDummy1 : Barrage {
    float acTime = 0;
    float acTime2 = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (GameState.isGamePaused) return;
        acTime += Time.deltaTime;
        acTime2 += Time.deltaTime;

        if (acTime > 1f) {
            acTime -= 1f;

            GameObject obj;
            for (float x = -5.5f; x < 5.5f; x += 2.2f) {
                obj = AddBullet(2, true);
                obj.transform.Translate(new Vector3(x, 7));
                obj.AddComponent<StrightBullet>();
                obj.GetComponent<StrightBullet>().setDirection(270);
                obj.GetComponent<StrightBullet>().setSpeed(4);
            }
        }

        if (acTime2 > 3f) {
            acTime2 -= 3f;

            GameObject obj;
            Vector3 pPos = GameObject.Find("RedStar").transform.position - transform.position;

            for (float x = Mathf.Max(pPos.x - 1, -5.5f); x < Mathf.Min(pPos.x + 1, 5.5f); x += 0.5f) {
                obj = AddBullet(4, true);
                obj.transform.Translate(new Vector3(x, -7));
                obj.AddComponent<StrightBullet>();
                obj.GetComponent<StrightBullet>().setDirection(90);
                obj.GetComponent<StrightBullet>().setSpeed(6);
            }
        }
    }
}
