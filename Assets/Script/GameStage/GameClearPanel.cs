using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameClearPanel : MonoBehaviour {
    public GameObject backgroundImage;
    public GameObject icon;
    public GameObject continueButton;
    public GameObject restartButton;
    public GameObject quitButton;
    
    float time;

    GameObject[] initialObjects;

    bool isAnimationEnded;

    public static bool isInit = false;

    // Use this for initialization
    void Start()
    {
        initialObjects = new GameObject[4];
        initialObjects[0] = icon;
        initialObjects[1] = continueButton;
        initialObjects[2] = restartButton;
        initialObjects[3] = quitButton;
        continueButton.GetComponent<Button>().interactable = false;
        restartButton.GetComponent<Button>().interactable = false;
        quitButton.GetComponent<Button>().interactable = false;

        EventSystem.current.SetSelectedGameObject(initialObjects[1], new BaseEventData(EventSystem.current));

        isInit = false;
        isAnimationEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.StageLevel == 50)
        {
            continueButton.SetActive(false);
        }

        if (!isInit)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(initialObjects[1], new BaseEventData(EventSystem.current));
            continueButton.GetComponent<Button>().interactable = true;
            restartButton.GetComponent<Button>().interactable = true;
            quitButton.GetComponent<Button>().interactable = true;
            isInit = true;
        }        

        if (GameState.isGameClear && !isAnimationEnded)
        {
            for (int i = 0; i < 4; i++)
            {
                initialObjects[i].GetComponent<Image>().color += new Color(0.0f, 0.0f, 0.0f, 0.01f);
            }

            if (initialObjects[0].GetComponent<Image>().color.a >= 1.0f)
            {
                time += Time.deltaTime;
                if (time >= 1.0f)
                {
                    isAnimationEnded = true;
                }
            }
        }
    }
}
