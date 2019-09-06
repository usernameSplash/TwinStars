using UnityEngine;
using System.Collections;

public class InGameObject : MonoBehaviour {
    private bool isInitialized = false;

    // Use this for initialization
    void Start() {
        
    }

    protected virtual void onInitialized() {

    }

    protected virtual void onUpdate() {

    }

    // Update is called once per frame
    void Update() {
        if(!isInitialized && !GameState.saveData.tutorialShowing[GameState.StageLevel]) {
            onInitialized();
            isInitialized = true;
        }

        if(isInitialized) {
            onUpdate();
        }
    }
}
