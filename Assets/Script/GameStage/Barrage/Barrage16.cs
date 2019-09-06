using UnityEngine;
using System.Collections;

public class Barrage16 : Barrage
{
    float acTime = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.isGamePaused) return;

        acTime += Time.deltaTime;

        if (acTime > 2)
        {
            acTime -= 2f;
            for (float y = -7; y <= 7f; y += 0.5f)
            {
                GameObject obj = AddBullet(2, false);

                obj.AddComponent<StrightBullet>();


                obj.GetComponent<StrightBullet>().setSpeed(3);
                if (Mathf.FloorToInt(y / 3) % 2 == 0)
                {
                    obj.GetComponent<StrightBullet>().setDirection(0);
                    obj.transform.Translate(new Vector3(-5f, y), Space.World);
                }
                else
                {
                    obj.GetComponent<StrightBullet>().setDirection(180);
                    obj.transform.Translate(new Vector3(5f, y), Space.World);
                }
            }
        }
    }
}
