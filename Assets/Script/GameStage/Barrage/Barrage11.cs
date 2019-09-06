using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage11 : Barrage {
    // Use this for initialization
    Vector3[,] cellPos = {
        {new Vector3(-2.75f, -4.67f), new Vector3(2.75f, -4.67f) },
        {new Vector3(-2.75f, 0f), new Vector3(2.75f, 0f) },
        {new Vector3(-2.75f, +4.67f), new Vector3(2.75f, +4.67f) },
    };

    Vector3 target;
    GameObject bullet;

    void Start () {
        float y = 0;

        for(y = -2.3f; y < 3; y += 4.6f) {
            for (float x = -5f; x < 6f; x += 2) {
                GameObject obj = AddBullet(1, false);
                obj.transform.position = transform.position + new Vector3(x, y);
            }
        }

        for(y = -6f; y < 7; y += 2) {
            float x = 0;
            GameObject obj = AddBullet(1, false);
            obj.transform.position = transform.position + new Vector3(x, y);
        }

        bullet = AddBullet(1, true);
        bullet.transform.position = transform.position;
        bullet.AddComponent<StrightBullet>();
        bullet.GetComponent<StrightBullet>().setSpeed(0);

        InvokeRepeating("setTarget", 2.5f, 2.5f);

        Vector3 tTarget = cellPos[0, 0] + transform.position;
        float minD = (tTarget - GameObject.Find("RedStar").transform.position).sqrMagnitude;

        foreach (Vector3 i in cellPos) {
            Vector3 c = i + transform.position;
            if ((c - GameObject.Find("RedStar").transform.position).sqrMagnitude < minD) {
                tTarget = c;
                minD = (c - GameObject.Find("RedStar").transform.position).sqrMagnitude;
            }
        }

        target = tTarget;
        float angle = Vector3.Angle(target - bullet.transform.position, Vector3.right);
        if ((target - bullet.transform.position).y < 0) {
            angle = 360 - angle;
        }

        bullet.GetComponent<StrightBullet>().setDirection(angle);
        bullet.GetComponent<StrightBullet>().setSpeed((target - bullet.transform.position).magnitude / 2.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused) return;
	}

    void setTarget() {
        if (GameState.isGamePaused) return;
        
        for(float x = target.x - 11f / 4f + 0.5f; x <= target.x + 11f/ 4f - 0.5f; x += 0.5f) {
            for(float y = target.y - 14f / 6f + 0.5f; y <= target.y + 14f / 6f - 0.5f; y += 0.5f) {
                Bomb(new Vector3(x, y));
            }
        }
        Vector3 tTarget = cellPos[0, 0] + transform.position;
        float minD = (tTarget - GameObject.Find("RedStar").transform.position).sqrMagnitude;

        foreach (Vector3 i in cellPos) {
            Vector3 c = i + transform.position;
            if((c - GameObject.Find("RedStar").transform.position).sqrMagnitude < minD) {
                tTarget = c;
                minD = (c - GameObject.Find("RedStar").transform.position).sqrMagnitude;
            }
        }

        target = tTarget;
        float angle = Vector3.Angle(target - bullet.transform.position, Vector3.right);
        if ((target - bullet.transform.position).y < 0) {
            angle = 360 - angle;
        }

        bullet.GetComponent<StrightBullet>().setDirection(angle);
        bullet.GetComponent<StrightBullet>().setSpeed((target - bullet.transform.position).magnitude / 2.5f);
    }
}
