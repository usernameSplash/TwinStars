using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage12 : Barrage {
    Vector3 center;
    Vector3 direction;
    List<GameObject> bulletList = new List<GameObject>();

    float p = 0;
    Vector3[] vertex = { new Vector3(12,7), new Vector3(1,7), new Vector3(1,-7), new Vector3(12,-7)};

	// Use this for initialization
	void Start () {
        center = GameObject.Find("BarrageLoader").transform.position;
        direction = new Vector3(0, -1f);

        float x, y;

        x = 0;
        for(y = -5f; y <= 5f; y += 0.5f) {
            GameObject obj = AddBullet(1, false);
            bulletList.Add(obj);

            obj.transform.position = new Vector3(x, y) + center;

            CircularOrbitBullet cb = obj.AddComponent<CircularOrbitBullet>();
            cb.SetCenter(center);
            cb.SetSpeed(60);
            cb.SetRadius(Mathf.Abs(y));

            if(y > 0) {
                cb.SetAngle(90);
            }
            else {
                cb.SetAngle(270);
            }
        }

        y = 0;
        for (x = -5f; x <= 5f; x += 0.5f) {
            GameObject obj = AddBullet(1, false);
            bulletList.Add(obj);

            obj.transform.position = new Vector3(x, y) + center;

            CircularOrbitBullet cb = obj.AddComponent<CircularOrbitBullet>();
            cb.SetCenter(center);
            cb.SetSpeed(60);
            cb.SetRadius(Mathf.Abs(x));

            if (x > 0) {
                cb.SetAngle(0);
            }
            else {
                cb.SetAngle(180);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused) return;

        Vector3 pos = center - GameObject.Find("BarrageLoader").transform.position;

        if (Mathf.Abs(pos.y) > 5f) direction.y = -direction.y;

        center += direction * Time.deltaTime;

        foreach(GameObject obj in bulletList) {
            obj.GetComponent<CircularOrbitBullet>().SetCenter(center);
        }

        for(int i = 0; i < 4; i++) {
            Vector3 start = vertex[i];
            Vector3 mid = vertex[(i + 1) % 4];
            Vector3 end = vertex[(i + 2) % 4];

            Vector3 b = start + (mid - start) * p;
            Vector3 e = mid + (end - mid) * p;

            GameObject obj = AddBullet(1, false);
            obj.AddComponent<StrightBullet>();
            obj.transform.position = b;

            obj.GetComponent<StrightBullet>().setSpeed(3);
            float angle = Vector3.Angle(e - b, Vector3.right);
            if ((e - b).y < 0) {
                angle = 360 - angle;
            }
            obj.GetComponent<StrightBullet>().setDirection(angle);
        }

        p += Time.deltaTime / 3f;
        while (p > 1) p -= 1;
    }
}
