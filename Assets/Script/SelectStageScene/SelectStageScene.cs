using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectStageScene : MonoBehaviour {

    public int Page { set; get; }
    private int prevPage;
    public GameObject[] Buttons;
    public GameObject BackGround;

    private float i = 1.0f, j = 1.0f;

    static public bool isStarted { set; get; }

	// Use this for initialization
	void Start () {
        Page = 0;
        prevPage = -1;
        isStarted = false;
        Buttons[10].GetComponent<PageButton>().isLeft = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(prevPage != Page)
        {
            for(int i = 1; i <= 10; i++)
            {
                if(!GameState.saveData.isPlayable[Page * 10 + i - 1])
                {
                    Buttons[i - 1].GetComponent<Button>().interactable = false;
                }
                else
                {
                    Buttons[i - 1].GetComponent<Button>().interactable = true;
                }

                Buttons[i - 1].GetComponentInChildren<Text>().text = (Page * 10 + i).ToString();
                Buttons[i - 1].GetComponent<NumberButton>().StageNumber = Page * 10 + i;
            }
        }

        if(isStarted)
        {   
            for(int k = 0; k < Buttons.Length; k++)
            {
                Buttons[k].GetComponentInChildren<Text>().color -= new Color(0.0f, 0.0f, 0.0f, 0.05f);
            }

            BackGround.GetComponent<SpriteRenderer>().color -= new Color(0.05f, 0.05f, 0.05f, 0.0f);

            if (BackGround.GetComponent<SpriteRenderer>().color.r <= 0.0f)
            {
                SceneManager.LoadScene("GameStage");
            }
        }

        if(Page == 0)
        {
            Buttons[10].GetComponent<Button>().interactable = false;
        }
        else
        {
            Buttons[10].GetComponent<Button>().interactable = true;
        }

        if(Page == 4)
        {
            Buttons[11].GetComponent<Button>().interactable = false;
        }
        else
        {
            Buttons[11].GetComponent<Button>().interactable = true;
        }
	}
}
