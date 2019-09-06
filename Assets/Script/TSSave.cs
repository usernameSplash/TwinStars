using UnityEngine;
using UnityEditor;

[System.Serializable]
public class TSSave {
    public bool[] isPlayable = new bool[50];
    public bool[] hasPlayed = new bool[50];

    //튜토리얼을 보여주는 스테이지인지 아닌지
    public bool[] tutorialShowing = {
        true, true, false, false, false,
        false, false, false, false, false,
        true, false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false,
        false, false, false, false, false
    };

    public TSSave() {
        for (int i = 0; i < 50; i++) {
            isPlayable[i] = false;
            hasPlayed[i] = false;
        }
        isPlayable[0] = true;
    }
}