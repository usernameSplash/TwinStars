using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour {
    public GameObject Logo;
    public GameObject OptionButton;
    public GameObject QuitButton;
    public GameObject Background;
    public string SceneName;

    float i = 1.0f;
    float j = 1.0f;
    bool isStarted = false;
    // Use this for initialization
    void Start () {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GetComponent<GameObject>(), new BaseEventData(EventSystem.current));
    }
	
	// Update is called once per frame
	void Update () {
        if (isStarted)
        {
            if (i > 0)
            {
                Logo.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
                this.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
                OptionButton.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
                QuitButton.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, i);
                i -= 0.05f;
            }
            else if(j > 0 && Background != null)
            {
                Logo.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                this.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                OptionButton.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                QuitButton.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);

                Background.GetComponent<SpriteRenderer>().color = new Vector4(j, j, j, 1.0f);
                j -= 0.05f;
            }
            else
            {
                Logo.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                this.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                OptionButton.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
                QuitButton.GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);

                SceneManager.LoadScene(SceneName);
            }
        }
	}

    public void OnClickStart()
    {
        isStarted = true;        
    }
}
