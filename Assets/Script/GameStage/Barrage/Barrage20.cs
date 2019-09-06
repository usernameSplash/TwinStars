using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage20 : Barrage
{

    float dir = 0;
    int color = 1;
    RepeatAction repeatAction;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Action", 0.2f, 2.0f);
    }

    void Action()
    {
        if (GameState.isGamePaused) return;
        Vector3 bPos = transform.position;
        Vector3 pPos = GameObject.Find("RedStar").transform.position;

        Vector3 dirVec = pPos - bPos;

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

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject obj = AddBullet(color, false);

                obj.AddComponent<StrightBullet>();

                if (color == 1)
                {
                    obj.GetComponent<StrightBullet>().setDirection(dir + (i - 1) * 36);
                }
                else if (color == 2)
                {
                    obj.GetComponent<StrightBullet>().setDirection(dir + (i - 1) * 36 + 18);
                }
                obj.GetComponent<StrightBullet>().setSpeed(-1.2f * (j + 1));
                obj.GetComponent<StrightBullet>().setAcc(0.02f * (j + 1));
            }
        }

        if (color == 1)
        {
            color = 2;
        }
        else if (color == 2)
        {
            color = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}