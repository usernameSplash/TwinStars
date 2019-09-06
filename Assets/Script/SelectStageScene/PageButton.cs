using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageButton : MonoBehaviour {

    public bool isLeft { get; set; }
    private float i = 0.0f;
    private bool isInitialized = false;

    public GameObject StageScene;

    // Use this for initialization
    void Start()
    {
        GetComponentInChildren<Text>().color = new Vector4(0.0f, 3.0f / 255.0f, 126.0f / 255.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
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

    public void onClickPage()
    {
        if(isLeft)
        {
            StageScene.GetComponent<SelectStageScene>().Page--;
        }
        else
        {
            StageScene.GetComponent<SelectStageScene>().Page++;
        }
    }
}
