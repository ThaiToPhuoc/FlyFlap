using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public List<Level> levelList;

    public Level levelPrefab;

    public GameObject result;

    public audioManager audio;

    public float speed = 1f;

    private int level = 0;

    private float position;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        position = Gamedata.instance.width()/2;
        createLevel();
    }

    // Update is called once per frame
    void Update()
    {
        moving();
        if(Gamedata.instance.gameover)
        {
            audio.VolumeChange("Background", 0.4f);
            Time.timeScale = 0;
            result.SetActive(true);
        }


        if (Gamedata.instance.score == Gamedata.instance.bonusLevel[Gamedata.instance.bonusIndex])
        {
            Gamedata.instance.finalScore += Gamedata.instance.bonusScore[Gamedata.instance.bonusIndex];
            Gamedata.instance.bonusIndex++;
        }

    }

    private void createLevel()
    {
        for(int i = 0; i < 3; i++)
        {
            levelList.Add(Instantiate(levelPrefab, new Vector3(position, 0,0), Quaternion.identity));
            levelList[i].transform.SetParent(transform);
            levelList[i].setLevel(level);
            position += Gamedata.instance.width() *3/4;
            level++;
        }
    }

    private void moving()
    {
        Level deleteLevel;
        for (int i = 0; i < 3; i++)
        {
            levelList[i].transform.position += speed * Time.deltaTime * Vector3.left;
            if(levelList[i].transform.position.x < -Gamedata.instance.width ())
            {
                deleteLevel = levelList[i];
                levelList.Remove(levelList[i]);
                Destroy(deleteLevel.gameObject);
                levelList.Add(Instantiate(levelPrefab, new Vector3(Gamedata.instance.width() * 5/4, 0, 0), Quaternion.identity));
                levelList[2].transform.SetParent(transform);
                levelList[2].setLevel(level);
                level++;
            }
        }
    }
}
