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
        speed = Time.deltaTime * 10;

        float deltaX = 0;
        float deltaY = 0;

        if (Input.GetKey(KeyCode.W)) deltaY += speed;
        if (Input.GetKey(KeyCode.S)) deltaY -= speed;
        if (Input.GetKey(KeyCode.A)) deltaX -= speed;
        if (Input.GetKey(KeyCode.D)) deltaX += speed;

        Vector2 delta = new Vector2(deltaX, deltaY);
        delta.Normalize();
        delta *= speed;

        this.gameObject.transform.Translate(delta);
    }
}
