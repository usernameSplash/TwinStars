using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedBullet : MonoBehaviour
{
    float Speed = 0;
    float Acc = 0;
    float Rotation = 0;
    float RotAcc = 0;
    float direction = 0;
    Vector3 Dir = new Vector3(0, 0, 0);

    public void setSpeed(float speed)
    {
        Speed = speed;
    }

    public void setAcc(float acc)
    {
        Acc = acc;
    }
    public void setRotation(float rotation)
    {
        Rotation = rotation;
    }
    public void setRotAcc(float rotacc)
    {
        RotAcc = rotacc;
    }

    public void setDirection(float dir)
    {
        direction = dir;
        Dir = new Vector3(Mathf.Cos(dir * Mathf.Deg2Rad), Mathf.Sin(dir * Mathf.Deg2Rad), 0);
        transform.rotation = Quaternion.AngleAxis(dir - 90, Vector3.forward);
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<Bullet>().shouldDeleteOnOutBorder = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.isGamePaused)
        {
            GetComponent<Animator>().enabled = false;
            return;
        }

        direction += Rotation;
        Rotation += RotAcc;
        setDirection(direction);

        GetComponent<Animator>().enabled = true;
        transform.Translate(Dir * Time.deltaTime * Speed, Space.World);

        Speed += Acc;

        if (!gameObject.GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
}
