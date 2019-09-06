using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeLoader : MonoBehaviour {
    public Sprite[] wallSprite;
    public Sprite backgroundSprite;
    public RuntimeAnimatorController portalAnimation;

    GameObject[,] maze;
    GameObject[,] backgrounds;
    Vector2 mazeView = new Vector2();
    Vector2 mazeSize;

    bool isInitialized = false;

    // Use this for initialization
    void Start () {
        if (!GameState.saveData.tutorialShowing[GameState.StageLevel - 1]) {
            LoadMaze();
            isInitialized = true;
        }
    }

    void LoadMaze() {
        TextAsset text = Resources.Load("Stage" + GameState.StageLevel) as TextAsset;

        string str = text.text;
        string[] lines = str.Split('\n');

        int width = int.Parse(lines[0].Split(':')[1]);
        int height = int.Parse(lines[1].Split(':')[1]);
        mazeView.x = float.Parse(lines[2].Split(':')[1]);
        mazeView.y = float.Parse(lines[3].Split(':')[1]);

        mazeSize = new Vector2(width, height);

        GameObject.Find("RedStar").transform.Translate(
            float.Parse(lines[4].Split(':')[1]),
            float.Parse(lines[5].Split(':')[1]),
            0,
            Space.World);

        maze = new GameObject[width, height];
        backgrounds = new GameObject[width / 22 + 1, height / 14 + 1];
        for (int x = 0; x * 22 < width; x++) {
            for (int y = 0; y * 14 < height; y++) {
                GameObject obj = backgrounds[x, y] = new GameObject("BackGround");

                obj.transform.SetParent(transform);
                obj.transform.localPosition = new Vector3(x * 22 + 11 - 0.5f, y * 14 + 7 - 0.5f);
                obj.transform.Translate(new Vector3(-mazeView.x, -mazeView.y, 0));

                SpriteRenderer spr = obj.AddComponent<SpriteRenderer>();
                spr.sprite = backgroundSprite;
                spr.sortingLayerName = "MazeLayer";
                spr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                spr.sortingOrder = -1;
            }
        }
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                switch (lines[(height - (y + 1)) + 6].ToCharArray()[x]) {
                    case '.':
                        maze[x, y] = null;
                        break;
                    case '#':
                        maze[x, y] = new GameObject("Wall");
                        maze[x, y].tag = "Wall";

                        maze[x, y].transform.SetParent(transform);
                        maze[x, y].transform.localPosition = new Vector3(x, y);
                        maze[x, y].transform.Translate(new Vector3(-mazeView.x, -mazeView.y, 0));

                        SpriteRenderer spr = maze[x, y].AddComponent<SpriteRenderer>();
                        spr.sprite = wallSprite[0];
                        spr.sortingLayerName = "MazeLayer";
                        spr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

                        int adjWallCount = 0;
                        bool[] isAdj = new bool[4];
                        //순서대로 상하좌우
                        adjWallCount += (isAdj[0] = (y < height - 1 && lines[(height - (y + 2)) + 6].ToCharArray()[x] == '#')) ? 1 : 0;
                        adjWallCount += (isAdj[1] = (y > 0 && lines[(height - (y)) + 6].ToCharArray()[x] == '#')) ? 1 : 0;

                        adjWallCount += (isAdj[2] = (x > 0 && lines[(height - (y + 1)) + 6].ToCharArray()[x - 1] == '#')) ? 1 : 0;
                        adjWallCount += (isAdj[3] = (x < width - 1 && lines[(height - (y + 1)) + 6].ToCharArray()[x + 1] == '#')) ? 1 : 0;

                        switch (adjWallCount) {
                            case 0:
                                spr.sprite = wallSprite[4];
                                break;
                            case 1:
                                if (isAdj[0]) {
                                    spr.sprite = wallSprite[5];
                                    maze[x, y].transform.rotation = Quaternion.AngleAxis(180f, Vector3.forward);
                                }
                                else if (isAdj[1]) {
                                    spr.sprite = wallSprite[5];
                                }
                                else if (isAdj[2]) {
                                    spr.sprite = wallSprite[5];
                                    maze[x, y].transform.rotation = Quaternion.AngleAxis(270f, Vector3.forward);
                                }
                                else if (isAdj[3]) {
                                    spr.sprite = wallSprite[5];
                                    maze[x, y].transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
                                }
                                break;
                            case 2:
                                if ((isAdj[0] && isAdj[1])) {
                                    spr.sprite = wallSprite[1];
                                    maze[x, y].transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
                                }
                                else if ((isAdj[2] && isAdj[3])) {
                                    spr.sprite = wallSprite[1];
                                }
                                else if ((isAdj[1] && isAdj[3])) {
                                    spr.sprite = wallSprite[2];
                                }
                                else if ((isAdj[0] && isAdj[3])) {
                                    spr.sprite = wallSprite[2];
                                    maze[x, y].transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
                                }
                                else if ((isAdj[1] && isAdj[2])) {
                                    spr.sprite = wallSprite[2];
                                    maze[x, y].transform.rotation = Quaternion.AngleAxis(270f, Vector3.forward);
                                }
                                else if ((isAdj[0] && isAdj[2])) {
                                    spr.sprite = wallSprite[2];
                                    maze[x, y].transform.rotation = Quaternion.AngleAxis(180f, Vector3.forward);
                                }
                                break;
                            case 3:
                                if (!isAdj[0]) {
                                    spr.sprite = wallSprite[3];

                                }
                                else if (!isAdj[1]) {
                                    spr.sprite = wallSprite[3];
                                    maze[x, y].transform.rotation = Quaternion.AngleAxis(180f, Vector3.forward);
                                }
                                else if (!isAdj[2]) {
                                    spr.sprite = wallSprite[3];
                                    maze[x, y].transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
                                }
                                else if (!isAdj[3]) {
                                    spr.sprite = wallSprite[3];
                                    maze[x, y].transform.rotation = Quaternion.AngleAxis(270f, Vector3.forward);
                                }
                                break;
                            case 4:
                                spr.sprite = wallSprite[0];
                                break;
                        }

                        maze[x, y].AddComponent<BoxCollider2D>();

                        Rigidbody2D rig = maze[x, y].AddComponent<Rigidbody2D>();
                        rig.gravityScale = 0;
                        rig.bodyType = RigidbodyType2D.Kinematic;
                        break;
                    case '@':
                        GameObject.Find("BlueStar").transform.position = new Vector3(x, y, -transform.position.z) + transform.position;
                        GameObject.Find("BlueStar").transform.Translate(new Vector3(-mazeView.x, -mazeView.y, 0));
                        break;
                    case 'P':
                        maze[x, y] = new GameObject("Portal");
                        maze[x, y].tag = "Portal";

                        maze[x, y].transform.SetParent(transform);
                        maze[x, y].transform.localPosition = new Vector3(x, y);
                        maze[x, y].transform.Translate(new Vector3(-mazeView.x, -mazeView.y, 0));

                        spr = maze[x, y].AddComponent<SpriteRenderer>();
                        spr.sortingLayerName = "MazeLayer";
                        spr.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

                        Animator ani = maze[x, y].AddComponent<Animator>();
                        ani.runtimeAnimatorController = portalAnimation;

                        rig = maze[x, y].AddComponent<Rigidbody2D>();
                        rig.gravityScale = 0;
                        rig.bodyType = RigidbodyType2D.Kinematic;

                        BoxCollider2D col = maze[x, y].AddComponent<BoxCollider2D>();
                        col.size = new Vector2(1, 1);
                        break;
                }

                if(maze[x,y] != null) {
                    Physics2D.IgnoreCollision(maze[x, y].GetComponent<Collider2D>(), GameObject.Find("RedStar").GetComponent<Collider2D>());
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!isInitialized && !GameState.saveData.tutorialShowing[GameState.StageLevel - 1]) {
            LoadMaze();
            isInitialized = true;
        }
        else if(!isInitialized) {
            return;
        }

        Vector3 starPos = GameObject.Find("BlueStar").transform.position - transform.position + new Vector3(0.5f, 0.5f, 0);
        Vector2 delta = new Vector2(0, 0);

        if (starPos.x < 1 && mazeView.x > 0) {
            delta.x = Mathf.Max(starPos.x - 1, -mazeView.x);
        }
        else if (starPos.x > 10 && mazeView.x < mazeSize.x - 11) {
            delta.x = Mathf.Min(starPos.x - 10, mazeSize.x - 11 - mazeView.x);
        }

        if (starPos.y < 1 && mazeView.y > 0) {
            delta.y = Mathf.Max(starPos.y - 1, -mazeView.y);
        }
        else if (starPos.y > 13 && mazeView.y < mazeSize.y - 14) {
            delta.y = Mathf.Min(starPos.y - 13, mazeSize.y - 14 - mazeView.y);
        }

        if (delta.sqrMagnitude != 0) {
            mazeView += delta;
            GameObject.Find("BlueStar").transform.Translate(-delta);
            foreach (GameObject obj in maze) {
                if (obj) {
                    obj.GetComponent<Rigidbody2D>().MovePosition(
                        obj.GetComponent<Rigidbody2D>().position - delta);
                }
            }

            foreach (GameObject obj in backgrounds) {
                obj.transform.Translate(-delta);
            }
        }
    }
}
