using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLogo : MonoBehaviour {

    float scaleParameter = 1.0f;
    float scaleVariation = 0.005f;

    const float max = 1.05f;
    const float min = 1.0f;

    float timer = 0.0f;
    float movementTime = 0.75f;
    float movementSpeed;

    const float targetScale = 0.3f;
    const float targetPos = 2.15f;

    private bool isSceneChanged = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.anyKey)
        {
            isSceneChanged = true;
            timer = 0.0f;
        }

        if (!isSceneChanged)
        {
            LogoAnimation();
        }
        else
        {

            if (gameObject.transform.localPosition.y < 3.15f)
            {
                if (gameObject.transform.localPosition.y + targetPos / movementTime * Time.deltaTime > 3.15f)       //다음 프레임 때 3.15를 넘길 때 초과방지
                {
                    gameObject.transform.localPosition = new Vector3(0.0f, 3.15f, 1.0f);
                }
                else
                {
                    gameObject.transform.localPosition += new Vector3(0.0f, targetPos / movementTime * Time.deltaTime, 0.0f);
                }
            }
            else
            {
                gameObject.transform.localScale = new Vector3(0.0f, 3.15f, 1.0f);       //초과했을 시 3.15 대입
            }

            if (gameObject.transform.localScale.x > 0.7f)       //0.7 사이즈까지 줄이기
            {
                gameObject.transform.localScale -= new Vector3(targetScale / movementTime * Time.deltaTime, targetScale / movementTime * Time.deltaTime, 0.0f);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);        //초과했을 시 대입
            }


            if (gameObject.transform.localPosition.y >= 3.15f && gameObject.transform.localScale.x <= 0.7f)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    void LogoAnimation()
    {
        gameObject.transform.localScale = new Vector3(scaleParameter, scaleParameter, 1.0f);
        scaleParameter += scaleVariation;

        if (scaleParameter >= max)
        {
            scaleVariation = -0.00375f;
        }
        else if (scaleParameter <= min)
        {
            scaleVariation = 0.0f;
            timer += Time.deltaTime;

            if (timer >= 1.0f)
            {
                timer = 0.0f;
                scaleVariation = 0.005f;
            }
        }
    }
}
