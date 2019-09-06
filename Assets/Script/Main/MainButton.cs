using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButton : MonoBehaviour {

    float i = 0.0f;

	// Use this for initialization
	void Start () {
        GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {

        if (i <= 1.0f)
        {
            i += 0.05f;
            GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
        }
    }
}
