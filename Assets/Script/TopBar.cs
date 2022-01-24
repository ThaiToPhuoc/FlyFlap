using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBar : MonoBehaviour
{
    public Text score, coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Level: " + Gamedata.instance.score;
        coin.text = Gamedata.instance.coinCount.ToString();
    }
}
