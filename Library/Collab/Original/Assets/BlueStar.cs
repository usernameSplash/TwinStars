using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueStar : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        speed = Time.deltaTime * 3;
        print(speed);
        float distanceX = Input.GetAxis("Horizontal") * speed;
        float distanceY = Input.GetAxis("Vertical") * speed;

        float tempX = this.gameObject.transform.position.x + distanceX;
        float tempY = this.gameObject.transform.position.y + distanceY;

        if (distanceX != 0 && distanceY != 0)
        {
            distanceX /= Mathf.Sqrt(2.0f);
            distanceY /= Mathf.Sqrt(2.0f);
        }
        this.gameObject.transform.Translate(distanceX, 0, 0);
        this.gameObject.transform.Translate(0, distanceY, 0);
    }
}
