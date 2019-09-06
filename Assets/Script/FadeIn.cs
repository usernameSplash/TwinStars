using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    bool isInitialized = false;
    float i = 0.0f;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (i < 1.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
            i += 0.05f;
        }
        else
        {
            if (!isInitialized)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
                isInitialized = true;
            }
        }
    }
}
