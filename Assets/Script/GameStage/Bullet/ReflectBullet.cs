using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectBullet : MonoBehaviour {
    float Speed = 0;
    float Acc = 0; //가속도
    int MaxReflectCount = 1; //반사 횟수, 이게 0이되면 삭제됨
    Vector3 Dir = new Vector3(0, 0, 0);

    public void setSpeed(float speed) {
        Speed = speed;
    }

    public void setAcc(float acc)
    {
        Acc = acc;
    }

    public void setDirection(float dir) {
        Dir = new Vector3(Mathf.Cos(dir * Mathf.Deg2Rad), Mathf.Sin(dir * Mathf.Deg2Rad), 0);
        transform.rotation = Quaternion.AngleAxis(dir - 90, Vector3.forward);
    }

    public void setMaxReflectCount(int n) {
        MaxReflectCount = n;
    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (GameState.isGamePaused) {
            GetComponent<Animator>().enabled = false;
            return;
        }

        GetComponent<Animator>().enabled = true;
        transform.Translate(Dir * Time.deltaTime * Speed, Space.World);

        Speed += Acc;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "BulletBorder") {
            if(MaxReflectCount > 0) {
                Vector3 center = GameObject.Find("BarrageLoader").transform.position;
                Vector3 pos = transform.position;
                Debug.Log(center);
                Debug.Log(pos);
                if (pos.x < center.x - 5.0f || pos.x > center.x + 5.0f) {
                    Dir.x = -Dir.x;
                }
                if (pos.y < center.y - 6.5f || pos.y > center.y + 6.5f) {
                    Dir.y = -Dir.y;
                }
                MaxReflectCount -= 1;

                float dir = Vector3.Angle(Dir, Vector3.right);
                if (Dir.y < 0) {
                    dir = 360 - dir;
                }
                transform.rotation = Quaternion.AngleAxis(dir - 90, Vector3.forward);
            }
            else {
                Destroy(gameObject);
            }
        }
    }
}
