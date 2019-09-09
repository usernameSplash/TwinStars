using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectStageScene : MonoBehaviour {

    public int Page { set; get; }
    private int prevPage;
    private int numberPerPage;
    public GameObject[] Buttons;
    public GameObject BackGround;

    private float i = 1.0f, j = 1.0f;

    static public bool isStarted { set; get; }

	// Use this for initialization
	void Start () {
        Page = 0;
        prevPage = -1;
        numberPerPage = 5;
        isStarted = false;
        Buttons[5].GetComponent<PageButton>().isLeft = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(prevPage != Page)
        {
            for(int i = 1; i <= numberPerPage; i++)
            {
                if(!GameState.saveData.isPlayable[Page * numberPerPage + i - 1])
                {
                    Buttons[i - 1].GetComponent<Button>().interactable = false;
                }
                else
                {
                    Buttons[i - 1].GetComponent<Button>().interactable = true;
                }

                Buttons[i - 1].GetComponentInChildren<Text>().text = (Page * numberPerPage + i).ToString();
                Buttons[i - 1].GetComponent<NumberButton>().StageNumber = Page * numberPerPage + i;
                prevPage = Page;
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
            Buttons[5].GetComponent<Button>().interactable = false;
        }
        else
        {
            Buttons[5].GetComponent<Button>().interactable = true;
        }

        if(Page == 4)
        {
            Buttons[6].GetComponent<Button>().interactable = false;
        }
        else
        {
            Buttons[6].GetComponent<Button>().interactable = true;
        }
	}
}
