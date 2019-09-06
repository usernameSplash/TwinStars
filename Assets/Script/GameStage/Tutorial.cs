using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public GameObject[] Help;
    public GameObject OKbutton;
    public GameObject image;
    public GameObject itself;
    public int Page { set; get; }
    public int Stage;

    // Use this for initialization
    void Start()
    {
        Page = 0;
        
        if (GameState.StageLevel == Stage && GameState.saveData.tutorialShowing[Stage - 1]) 
        {
            Debug.Log(GameState.StageLevel);
            Help[0].SetActive(true);
            for(int i = 1; i < Help.Length; i++)
            {
                Help[i].SetActive(false);
            }
            OKbutton.SetActive(true);
            image.SetActive(true);
        }
        else
        {
            itself.SetActive(false);
            for (int i = 0; i < Help.Length; i++)
            {
                Help[i].SetActive(false);
            }
            OKbutton.SetActive(false);
            image.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Page >= Help.Length)
        {
            Help[Page - 1].SetActive(false);
            OKbutton.GetComponent<Button>().interactable = false;
            OKbutton.GetComponent<Button>().GetComponentInChildren<Text>().color -= new Color(0.0f, 0.0f, 0.0f, 0.05f);
            image.GetComponent<Image>().color -= new Color(0.0f, 0.0f, 0.0f, 0.05f);
            if (OKbutton.GetComponentInChildren<Text>().color.a <= 0.0f)
            {
                GameState.saveData.tutorialShowing[Stage - 1] = false;
                GameState.SaveData();
            }
        }
        else if (Page > 0)
        {
            Help[Page - 1].SetActive(false);
            Help[Page].SetActive(true);
        }

        Debug.Log(Page + " " + Help.Length);
        if (Page == Help.Length - 1)
        {
            OKbutton.GetComponent<Button>().GetComponentInChildren<Text>().text = "Start";
        }
    }
}