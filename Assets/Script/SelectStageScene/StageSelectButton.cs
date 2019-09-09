using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectButton : MonoBehaviour {
    static private float i = 0.0f;
    private bool isInitialized = false;
	// Use this for initialization
	void Start () {
        GetComponentInChildren<Text>().color = new Vector4(0.0f, 3.0f / 255.0f, 126.0f / 255.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (i <= 1.0f)
        {
            GetComponentInChildren<Text>().color = new Vector4(0.0f, 3.0f / 255.0f, 126.0f / 255.0f, i);
            i += 0.05f;
        }
        else
        {
            if (!isInitialized)
            {
                GetComponentInChildren<Text>().color = new Vector4(0.0f, 3.0f / 255.0f, 126.0f / 255.0f, 1.0f);
                isInitialized = true;
            }
        }
    }
}
