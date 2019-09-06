using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage11 : Barrage {
    Vector3 target;
    GameObject centerBullet;
    float angle;
    float speed;
    List<GameObject> bulletList;

    bool isShootStright = false;
    Vector3 strightBulletSpot;

    RepeatAction repeatAction;

    RepeatAction strightBulletAction;
    RepeatAction flagAction;

    // Use this for initialization
    void Start () {
        target = transform.position;
        centerBullet = AddBullet(4, true);
        centerBullet.AddComponent<StrightBullet>();

        angle = 90;
        speed = 1;
        bulletList = new List<GameObject>();

        strightBulletSpot = target;
        target = GameObject.Find("RedStar").transform.position;
        angle = Vector3.Angle(target - centerBullet.transform.position, Vector3.right);
        if ((target - centerBullet.transform.position).y < 0) {
            angle = 360 - angle;
        }

        speed = (centerBullet.transform.position - target).magnitude / 2;
        centerBullet.GetComponent<StrightBullet>().setSpeed(speed);
        centerBullet.GetComponent<StrightBullet>().setDirection(angle);
        for (float a = 0; a < 360; a += 20f) {
            GameObject obj = AddBullet(1, false);

            CircularOrbitBullet cob = obj.AddComponent<CircularOrbitBullet>();
            cob.SetCenter(new Vector3(Mathf.Cos(a * Mathf.Deg2Rad), Mathf.Sin(a * Mathf.Deg2Rad)) * 1 + centerBullet.transform.position);
            cob.SetRadius(1);
            cob.SetAngle(a + 180);
            cob.SetSpeed(360 / 2);

            bulletList.Add(obj);

            
        }

        repeatAction = new RepeatAction(2, () => {
            foreach (GameObject obj in bulletList) {
                Destroy(obj);
            }

            bulletList.Clear();

            strightBulletSpot = target;
            target = GameObject.Find("RedStar").transform.position;
            angle = Vector3.Angle(target - centerBullet.transform.position, Vector3.right);
            if ((target - centerBullet.transform.position).y < 0) {
                angle = 360 - angle;
            }

            speed = (centerBullet.transform.position - target).magnitude / 2;
            centerBullet.GetComponent<StrightBullet>().setSpeed(speed);
            centerBullet.GetComponent<StrightBullet>().setDirection(angle);

            for (float a = 0; a < 360; a += 20f) {
                GameObject obj = AddBullet(1, false);

                CircularOrbitBullet cob = obj.AddComponent<CircularOrbitBullet>();
                cob.SetCenter(new Vector3(Mathf.Cos(a * Mathf.Deg2Rad), Mathf.Sin(a * Mathf.Deg2Rad)) * 1 + centerBullet.transform.position);
                cob.SetRadius(1);
                cob.SetAngle(a + 180);
                cob.SetSpeed(360 / 2);

                bulletList.Add(obj);
            }

            isShootStright = true;
        });
        
        strightBulletAction = new RepeatAction(0.1f, () => {
            if(isShootStright) {
                for (float a = 0; a < 360; a += 60) {
                    GameObject obj = AddBullet(3, false);

                    obj.AddComponent<StrightBullet>();

                    float an = Vector3.Angle(strightBulletSpot - target, Vector3.right);
                    if ((strightBulletSpot - target).y < 0) an = 360 - an;
                    obj.GetComponent<StrightBullet>().setDirection(a + an);
                    obj.GetComponent<StrightBullet>().setSpeed(5.5f);
                    obj.transform.position = strightBulletSpot;
                }
            }
        });

        flagAction = new RepeatAction(0.5f, () => {
            isShootStright = false;
        });
    }
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused) return;

        strightBulletAction.Update();
        flagAction.Update();
        repeatAction.Update();
    }
}
