using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour {
    public float AngularAcceleration {
        get; set;
    }

    public float Speed {
        get; set;
    }

    private float Angle;

	// Use this for initialization
	void Start () {
        Vector3 target = GameObject.Find("RedStar").transform.position;
        Angle = Vector3.Angle(target - transform.position, Vector3.right);
        if ((target - transform.position).y < 0) {
            Angle = 360 - Angle;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused) {
            GetComponent<Animator>().enabled = false;
            return;
        }

        GetComponent<Animator>().enabled = true;

        Vector3 target = GameObject.Find("RedStar").transform.position;
        float dAngle = Vector3.Angle(target - transform.position, Vector3.right);
        if ((target - transform.position).y < 0) {
            dAngle = 360 - dAngle;
        }

        if(dAngle > Angle) {
            Angle += Mathf.Min(AngularAcceleration * Time.deltaTime, dAngle - Angle);
        }else {
            Angle -= Mathf.Min(AngularAcceleration * Time.deltaTime, -dAngle + Angle);
        }

        transform.Translate(new Vector3(Mathf.Cos(Angle * Mathf.Deg2Rad) * Speed * Time.deltaTime,
            Mathf.Sin(Angle * Mathf.Deg2Rad) * Speed * Time.deltaTime));
    }
}
