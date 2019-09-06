using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameOverPanel : MonoBehaviour {

    public GameObject backgroundImage;
    public GameObject icon;
    public GameObject brokenIcon;
    public GameObject restartButton;
    public GameObject quitButton;
    
    float time;

    GameObject[] initialObjects;

    bool isAnimationEnded;

    public static bool isInit = false;

    // Use this for initialization
    void Start () {

        initialObjects = new GameObject[3];
        initialObjects[0] = icon;
        initialObjects[1] = restartButton;
        initialObjects[2] = quitButton;
        restartButton.GetComponent<Button>().interactable = false;
        quitButton.GetComponent<Button>().interactable = false;

        isInit = false;
        isAnimationEnded = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!isInit)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(initialObjects[1], new BaseEventData(EventSystem.current));
            restartButton.GetComponent<Button>().interactable = true;
            quitButton.GetComponent<Button>().interactable = true;
            isInit = true;
        }

		if(GameState.isGameOver && !isAnimationEnded)
        {
            for(int i = 0; i < 3; i++)
            {
                initialObjects[i].GetComponent<Image>().color += new Color(0.0f, 0.0f, 0.0f, 0.01f);
            }

            if(initialObjects[0].GetComponent<Image>().color.a >= 1.0f)
            {
                time += Time.deltaTime;
                if (time >= 1.0f)
                {
                    icon.GetComponent<Image>().color -= new Color(0.0f, 0.0f, 0.0f, 10000.0f);
                    brokenIcon.GetComponent<Image>().color += new Color(0.0f, 0.0f, 0.0f, 1.0f);
                    
                    isAnimationEnded = true;                    
                }
            }
           
        }
	}
}
