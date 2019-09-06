using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage13 : Barrage {

    float dir = 0;
    RepeatAction repeatAction;

    // Use this for initialization
    void Start () {
        repeatAction = new RepeatAction(1.5f, () => {
            Vector3 bPos = transform.position;
            Vector3 pPos = GameObject.Find("RedStar").transform.position;

            Vector3 dirVec = pPos - bPos;

            float dir = 0;

            if (dirVec.x == 0)
            {
                if (dirVec.y > 0)
                {
                    dir = 90;
                }
                else
                {
                    dir = 270;
                }
            }
            else
            {
                float t = dirVec.y / dirVec.x;

                if (dirVec.x > 0)
                {
                    dir = Mathf.Atan(t) * Mathf.Rad2Deg + Mathf.PI * 2;
                    if (dir > Mathf.PI * 2)
                    {
                        dir -= Mathf.PI * 2;
                    }
                }
                else
                {
                    dir = Mathf.Atan(t) * Mathf.Rad2Deg + 180;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    GameObject obj = AddBullet(3, false);
                    obj.AddComponent<StrightBullet>();

                    obj.GetComponent<StrightBullet>().setDirection(dir + (i - 1) * 90);
                    obj.GetComponent<StrightBullet>().setSpeed((j + 1)*1.2f);
                }
               
            }
        });
    }
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused) return;
        repeatAction.Update();
	}
}
