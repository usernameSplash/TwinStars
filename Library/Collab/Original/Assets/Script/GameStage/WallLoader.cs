using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLoader : MonoBehaviour {
    public Sprite[] wallSprite;

    GameObject[][] maze;
    Vector2 mazeView;

	// Use this for initialization
	void Start () {
        TextAsset text = Resources.Load("Stage1") as TextAsset;
        string str = text.text;
        string[] lines = str.Split('\n');

        int width = int.Parse(lines[0].Split(':')[1]);
        int height = int.Parse(lines[1].Split(':')[1]);
        mazeView.x = int.Parse(lines[2].Split(':')[1]);
        mazeView.y = int.Parse(lines[3].Split(':')[1]);

        maze = new GameObject[width][];
        for(int x = 0; x < width; x++) {
            maze[x] = new GameObject[height];
            for(int y = 0; y < height; y++) {
                switch(lines[(height - (y + 1)) + 4].ToCharArray()[x]) {
                    case '.':
                        maze[x][y] = null;
                        break;
                    case '#':
                        maze[x][y] = new GameObject("Wall");

                        maze[x][y].transform.SetParent(transform);
                        maze[x][y].transform.localPosition = new Vector3(x, y);

                        maze[x][y].tag = "Maze";

                        maze[x][y].AddComponent<SpriteRenderer>();
                        SpriteRenderer spr = maze[x][y].GetComponent<SpriteRenderer>();
                        spr.sprite = wallSprite[0];
                        spr.sortingLayerName = "WallLayer";
                        spr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                        break;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
