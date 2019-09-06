using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePAK : MonoBehaviour {

    float alphaParameter = 0.0f;

    bool isKeyPressed = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if(Input.anyKey)
        {
            isKeyPressed = true;
        }

        if (isKeyPressed)
        {
            if(gameObject.GetComponent<Renderer>().isVisible)
                gameObject.transform.Translate(Vector3.down * 5.0f * Time.deltaTime);
        }
        
        if (alphaParameter >= Mathf.Deg2Rad * 360.0f)
        {
            alphaParameter = 0.0f;
        }

        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Abs(Mathf.Sin(alphaParameter)));
        alphaParameter += 0.05f;
	}
}
