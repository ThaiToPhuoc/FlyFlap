using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int level = 0;

    private string[] levelData;

    public List<pile> piles;

    public coin coin;

    private float width, height;
    // Start is called before the first frame update
    void Start()
    {
        width = Gamedata.instance.width();
        height = Gamedata.instance.height();
        getLevelData();
        createPile();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 0)
        {
            Gamedata.instance.score = this.level * 3 + 1;
        }
        if(transform.position.x < -6f)
        {
            Gamedata.instance.score = this.level * 3 + 2;
        }
        if (transform.position.x < -12f)
        {
            Gamedata.instance.score = this.level * 3 + 3;
        }

    }

    private void getLevelData()
    {
        string levelData = Gamedata.instance.levelDatastring[level % 20];
        string [] levelplits = levelData.Split('|');
        int random = Random.Range(0,3);
        levelData = levelplits[random];
        levelplits = levelData.Split('-');
        this.levelData = levelplits;
    }

    private void createPile()
    {
        for(int i = 0; i < levelData.Length; i++)
        {
            switch (levelData[i].Trim())
            { 
                case "1;0;0":
                    Instantiate(piles[0], new Vector3(width * i /4 - width / 4 + transform.position.x, height / 4, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "1;1;0":
                    Instantiate(piles[0], new Vector3(width * i / 4 - width / 4 + transform.position.x, 0, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "0;1;0":
                    Instantiate(piles[1], new Vector3(width * i / 4 - width / 4 + transform.position.x, 0, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "0;1;1":
                    Instantiate(piles[2], new Vector3(width * i / 4 - width / 4 + transform.position.x, 0, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "0;0;1":
                    Instantiate(piles[2], new Vector3(width * i / 4 - width / 4 + transform.position.x, - height / 4, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "1;0;1":
                    Instantiate(piles[5], new Vector3(width * i / 4 - width / 4 + transform.position.x, 0, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "1;0;0C":
                    Instantiate(piles[0], new Vector3(width * i / 4 - width / 4 + transform.position.x, height / 4, 0), Quaternion.identity).transform.SetParent(transform);
                    Instantiate(coin, new Vector3(width * i / 4 - width / 4 + 1f + transform.position.x, height / 4, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "1;1;0C":
                    Instantiate(piles[0], new Vector3(width * i / 4 - width / 4 + transform.position.x, 0, 0), Quaternion.identity).transform.SetParent(transform);
                    Instantiate(coin, new Vector3(width * i / 4 - width / 4 + 1f + transform.position.x, 0, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "0;1;0C":
                    Instantiate(piles[1], new Vector3(width * i / 4 - width / 4 + transform.position.x, 0, 0), Quaternion.identity).transform.SetParent(transform);
                    Instantiate(coin, new Vector3(width * i / 4 - width / 4 + 1f + transform.position.x, 0, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "0;1;1C":
                    Instantiate(piles[2], new Vector3(width * i / 4 - width / 4 + transform.position.x, 0, 0), Quaternion.identity).transform.SetParent(transform);
                    Instantiate(coin, new Vector3(width * i / 4 - width / 4 + 1f + transform.position.x, 0, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "0;0;1C":
                    Instantiate(piles[2], new Vector3(width * i / 4 - width / 4 + transform.position.x, - height / 4, 0), Quaternion.identity).transform.SetParent(transform);
                    Instantiate(coin, new Vector3(width * i / 4 - width / 4 + 1f + transform.position.x, - height / 4, 0), Quaternion.identity).transform.SetParent(transform);
                    break;
                case "1;0;1C":
                    Instantiate(piles[5], new Vector3(width * i / 4 - width / 4 + transform.position.x, 0 , 0), Quaternion.identity).transform.SetParent(transform);
                    Instantiate(coin, new Vector3(width * i / 4 - width / 4 + 1f + transform.position.x, 0 , 0), Quaternion.identity).transform.SetParent(transform);
                    break;
            }
        }
    }

    public void setLevel(int level)
    {
        this.level = level;
    }
}
