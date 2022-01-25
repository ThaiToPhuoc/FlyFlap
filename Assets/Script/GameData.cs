using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamedata : MonoBehaviour
{
    static Gamedata _instance;
    public static Gamedata instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("Gamedata");
                _instance = go.AddComponent<Gamedata>();
            }

            return _instance;

        }
    }

    // Get Resolution
    private int ActualResolutionWidth(float orthoSize)
    {
        return (int)(orthoSize * 2.0 * (Screen.width * 1.0) / Screen.height * 100);
    }

    private int ActualResolutionHeight(float orthoSize)
    {
        return (int)(orthoSize * 2.0 * 100);
    }

    public float width()
    {
        return ActualResolutionWidth(Camera.main.orthographicSize) / 100f;
    }

    public float height()
    {
        return ActualResolutionHeight(Camera.main.orthographicSize) / 100f;
    }


    public string[] levelDatastring = new string[]
    {
        "0;1;0 - 1;0;0 - 0;1;0 | 0;1;0 - 0;1;0 - 0;0;1	| 0;1;0 - 1;0;0 - 1;0;0",
        "0;1;0C - 1;0;0 - 0;1;0 | 0;0;1 - 0;1;0C - 0;1;0 | 0;1;0 - 0;1;0 - 1;0;0C",
        "0;1;0 - 0;1;0 - 0;1;0 | 0;1;0 - 0;0;1 - 0;0;1	| 0;1;0 - 1;0;0 - 1;0;0",
        "0;0;1C - 0;0;1 - 0;1;0	| 0;0;1 - 0;1;0C - 0;1;0 | 0;1;0 - 1;0;0C - 1;0;0",
        "0;1;0C - 0;1;0 - 0;1;0 | 0;1;0 - 0;0;1C - 0;0;1 | 0;1;0 - 1;0;0C - 0;1;0",
        "0;1;0 - 0;0;1 - 0;0;1 | 0;1;0 - 1;0;0 - 0;1;0 | 1;0;0 - 1;0;0 - 0;1;0",
        "0;0;1C - 0;0;1 - 0;1;0C | 0;0;1 - 0;1;0C - 0;1;0C | 0;1;0C - 1;0;0 - 0;1;0C",
        "0;0;1 - 0;0;1 - 0;1;0C | 0;1;0 - 1;0;0C - 1;0;0 | 0;0;1 - 1;0;0C - 0;0;1",
        "0;0;1C - 0;1;0 - 1;0;0C | 0;1;0C - 1;0;0 - 0;1;0C | 0;0;1 - 0;1;0C - 0;0;1C",
        "0;0;1 - 0;0;1 - 0;1;0C | 0;0;1C - 0;1;0 - 0;0;1 | 0;1;0C - 0;0;1 - 0;1;0",
        "0;1;1 - 0;0;1 - 0;1;0 | 0;1;0 - 0;1;1 - 0;0;1 | 0;1;0 - 0;0;1 - 1;0;1",
        "0;1;0 - 0;1;1 - 0;0;1C | 0;1;1 - 0;1;0C - 1;0;0 | 0;1;1 - 0;0;1C - 0;1;0",
        "0;1;1C - 0;1;0 - 1;0;1C | 1;0;1 - 0;1;1C - 1;0;1C | 0;1;0 - 0;1;1C - 1;0;1C",
        "0;1;1C - 0;0;1 - 1;0;0C | 0;1;0C - 1;1;0 - 0;0;1C | 0;1;0C - 1;1;0C - 0;1;0",
        "1;1;0 - 0;1;1 - 0;0;1 | 0;1;1 - 0;1;0 - 1;1;0 | 0;1;0 - 1;1;0 - 0;1;1",
        "0;1;1C - 0;0;1 - 1;0;0C | 0;1;0C - 1;1;0C - 0;1;0 | 1;0;1 - 0;1;1C - 1;0;1C",
        "0;1;1 - 0;1;0 - 1;1;0 | 0;1;0 - 1;1;0 - 0;1;1 | 1;1;0 - 0;1;1 - 0;0;1",
        "0;1;1 - 0;0;1 - 0;1;0 | 0;1;0 - 0;1;1 - 0;0;1 | 0;1;0 - 0;0;1 - 1;0;1",
        "0;1;1C - 0;0;1 - 1;0;0C | 0;1;0C - 1;1;0 - 0;0;1C | 0;1;0C - 1;1;0C - 0;1;0",
        "1;1;0 - 0;1;1 - 0;0;1 | 0;1;1 - 0;1;0 - 1;1;0 | 0;1;0 - 1;1;0 - 0;1;1"
    };

    public int score = 0, coin = 0, coinCount = 0, finalScore = 0;
    public bool Ccoin = false, gameover = false, pause = false, scoreCoin = false, changeBG = false;

    public int[] bonusLevel = new int[] { 10, 20, 30, 35, 40, 45, 50, 60, 70, 80, 90, 100 };
    public int[] bonusScore = new int[] { 5, 5, 10, 5, 10, 15, 20, 20, 20, 25, 25, 50 };
    public int bonusIndex = 0, backgroundIndex = 0;

}
