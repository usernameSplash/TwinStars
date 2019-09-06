using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameState : MonoBehaviour {

    //게임이 몇 스테이지인지를 의미함
    public static int StageLevel = 22;

    //게임이 멈추었는지를 의미함. 일시정지 뿐만 아니라 클리어 등도 포함함
    public static bool isGamePaused = false;

    //이게 true일경우 게임 오버(피탄 등)
    public static bool isGameOver = false;

    //true일경우 게임 클리어
    public static bool isGameClear = false;

    public static TSSave saveData = LoadData();

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SaveData() {
        string path = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(path)) {
            file = File.OpenWrite(path);
        }
        else {
            file = File.Create(path);
        }

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, saveData);
        file.Close();
    }

    public static TSSave LoadData() {
        string path = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if(!File.Exists(path)) {
            return new TSSave();
        }

        file = File.OpenRead(path);

        BinaryFormatter bf = new BinaryFormatter();
        TSSave data = (TSSave)bf.Deserialize(file);
        file.Close();

        return data;
    }
}
