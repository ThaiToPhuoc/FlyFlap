using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Result : MonoBehaviour
{
    public int currentScore = 0, highScore;

    public Text Score, highest;

    public audioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        Gamedata.instance.finalScore += Gamedata.instance.score + Gamedata.instance.coin;
        if (PlayerPrefs.GetInt("highScore") == null)
        {
            PlayerPrefs.SetInt("highScore", Gamedata.instance.finalScore);
        }
        else
        {
            if (Gamedata.instance.finalScore > PlayerPrefs.GetInt("highScore"))
                PlayerPrefs.SetInt("highScore", Gamedata.instance.finalScore);
        }
        audio.Play("Dead");
    }

    // Update is called once per frame
    void Update()
    {

        Score.text = Gamedata.instance.finalScore.ToString();
        highest.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void restart(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
