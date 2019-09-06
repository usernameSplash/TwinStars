using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBullet : MonoBehaviour {
    Vector3 Dir = new Vector3(0, 0, 0);
    float gravity = 0;
    float maxSpeed = 6;

    public void setSpeed(float speed) {
        Dir.Normalize();
        Dir *= speed;
    }

    public void setDirection(float dir) {
        Dir = new Vector3(Mathf.Cos(dir * Mathf.Deg2Rad), Mathf.Sin(dir * Mathf.Deg2Rad), 0);
        transform.rotation = Quaternion.AngleAxis(dir - 90, Vector3.forward);
    }

    public void setGravity(float gra) {
        gravity = gra;
    }

    public void setMaxSpeed(float mspeed) {
        maxSpeed = mspeed;
    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused) {
            GetComponent<Animator>().enabled = false;
            return;
        }

        Dir += new Vector3(0, -gravity);
        if(Dir.magnitude > maxSpeed) {
            Dir.Normalize();
            Dir *= maxSpeed;
        }

        GetComponent<Animator>().enabled = true;
        transform.Translate(Dir * Time.deltaTime, Space.World);

        if(!gameObject.GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
}
