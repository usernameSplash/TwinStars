using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrightBullet : MonoBehaviour {
    float Speed = 0;
    float Acc = 0; //가속도
    Vector3 Dir = new Vector3(0, 0, 0);

    public void setSpeed(float speed) {
        Speed = speed;
    }

    public void setAcc(float acc)
    {
        Acc = acc;
    }

    public void setDirection(float dir) {
        Dir = new Vector3(Mathf.Cos(dir * Mathf.Deg2Rad), Mathf.Sin(dir * Mathf.Deg2Rad), 0);
        transform.rotation = Quaternion.AngleAxis(dir - 90, Vector3.forward);
    }

	// Use this for initialization
	void Start () {
        Debug.Log(Speed);
        Debug.Log(Acc);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (GameState.isGamePaused) {
            GetComponent<Animator>().enabled = false;
            return;
        }

        GetComponent<Animator>().enabled = true;
        transform.Translate(Dir * Time.deltaTime * Speed, Space.World);

        Speed += Acc;

        if(!gameObject.GetComponent<SpriteRenderer>().isVisible)
        {
            //Destroy(gameObject);
        }
    }
}
