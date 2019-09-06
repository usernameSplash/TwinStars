using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage18 : Barrage {
    List<GameObject> bullets;
    // Use this for initialization
    void Start () {
        bullets = new List<GameObject>();

        for(int a = 0; a < 4; a++) {
            for(float d = 0; d < 14; d += 0.5f) {
                if (d >= 4.5 && d <= 5.0)
                {
                    continue;
                }
                if(d >= 6.0 && d <= 6.5)
                {
                    continue;
                }
                GameObject obj = AddBullet(1, false);
                obj.AddComponent<CircularOrbitBullet>();
                obj.GetComponent<CircularOrbitBullet>().SetCenter(transform.position);
                obj.GetComponent<CircularOrbitBullet>().SetRadius(d);
                obj.GetComponent<CircularOrbitBullet>().SetSpeed(-45);
                obj.GetComponent<CircularOrbitBullet>().SetAngle(a * 90 + 45);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused) return;

    }
}
