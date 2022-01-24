using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public audioManager audio;
    public void pause()
    {
        audio.VolumeChange("Background", 0.4f);
        Gamedata.instance.pause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        audio.VolumeChange("Background", 1f);
        Gamedata.instance.pause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
