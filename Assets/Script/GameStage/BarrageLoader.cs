using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageLoader : MonoBehaviour {
    System.Type[] barrages = {
        typeof(Barrage1),
        typeof(Barrage2),
        typeof(Barrage3),
        typeof(Barrage4),
        typeof(Barrage5),
        typeof(Barrage6),
        typeof(Barrage7),
        typeof(Barrage8),
        typeof(Barrage9),
        typeof(Barrage10),
        typeof(Barrage11),
        typeof(Barrage12),
        typeof(Barrage13),
        typeof(Barrage14),
        typeof(Barrage15),
        typeof(Barrage16),
        typeof(Barrage17),
        typeof(Barrage18),
        typeof(Barrage19),
        typeof(Barrage20),
        typeof(Barrage21),
        typeof(Barrage22)
    };
    bool isInitialized;

    public RuntimeAnimatorController controller;
    public Transform BombPreFab;

    // Use this for initialization
    void Start () {
        if (!GameState.saveData.tutorialShowing[GameState.StageLevel - 1]) {
            gameObject.AddComponent(barrages[GameState.StageLevel - 1]);
            (gameObject.GetComponent(barrages[GameState.StageLevel - 1]) as Barrage).controller = controller;
            (gameObject.GetComponent(barrages[GameState.StageLevel - 1]) as Barrage).BombPreFab = BombPreFab;
            isInitialized = true;
            
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!isInitialized && !GameState.saveData.tutorialShowing[GameState.StageLevel - 1]) {
            isInitialized = true;
            gameObject.AddComponent(barrages[GameState.StageLevel - 1]);
            (gameObject.GetComponent(barrages[GameState.StageLevel - 1]) as Barrage).controller = controller;
            (gameObject.GetComponent(barrages[GameState.StageLevel - 1]) as Barrage).BombPreFab = BombPreFab;

        }
    }
}
