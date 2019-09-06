using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage : MonoBehaviour {
    public RuntimeAnimatorController controller;
    public Transform BombPreFab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    protected GameObject AddBullet(int bulletType, bool useFire) {
        GameObject obj = new GameObject("Bullet");
        obj.tag = "Bullet";

        obj.AddComponent<SpriteRenderer>();
        obj.GetComponent<SpriteRenderer>().sortingLayerName = "BarrageLayer";
        obj.GetComponent<SpriteRenderer>().sortingOrder = 0;
        obj.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        
        obj.AddComponent<Animator>();
        obj.GetComponent<Animator>().runtimeAnimatorController = controller;
        obj.GetComponent<Animator>().SetBool("UseFire", useFire);
        obj.GetComponent<Animator>().SetInteger("BulletType", bulletType);
        obj.GetComponent<Animator>().enabled = true;

        obj.transform.position = transform.position;


        obj.AddComponent<CircleCollider2D>();
        CircleCollider2D col = obj.GetComponent<CircleCollider2D>();
        col.isTrigger = true;
        col.radius = 0.25f;

        if(useFire)
        {
            col.offset = new Vector2(0.0f, 0.5f);
        }

        obj.AddComponent<Bullet>();

        return obj;
    }

    protected GameObject Bomb(Vector3 pos) {
        GameObject obj = Instantiate(BombPreFab, pos, Quaternion.identity).gameObject;

        return obj;
    }
}
