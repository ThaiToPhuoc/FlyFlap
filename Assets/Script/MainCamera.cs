using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
    public Transform robot;

    public float smoothspeed = 0.125f;

    private float rowWidth;

    public Vector3 offset;
    public SpriteRenderer mainbg;
    public List<SpriteRenderer> bg;
    public Sprite[] layer1, layer2, layer3, layer4, layer5, bg1;


    // Start is called before the first frame update
    void Start()
    {
        rowWidth = Gamedata.instance.width();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < bg.Count; i++)
        {
            bg[i].transform.position += (i / 2 + 1) * Time.deltaTime * Vector3.left;
            if(bg[i].transform.position.x < transform.position.x - rowWidth)
            {
                bg[i].transform.position = new Vector3(transform.position.x + rowWidth, bg[i].transform.position.y);
            }
        }
        if (Gamedata.instance.changeBG)
        {
            changeBG();
            Gamedata.instance.changeBG = false;
        }
    }

    private void changeBG()
    {
        mainbg.sprite = bg1[Gamedata.instance.backgroundIndex];
        bg[0].sprite = layer1[Gamedata.instance.backgroundIndex];
        bg[1].sprite = layer2[Gamedata.instance.backgroundIndex];
        bg[2].sprite = layer3[Gamedata.instance.backgroundIndex];
        bg[3].sprite = layer4[Gamedata.instance.backgroundIndex];
        bg[4].sprite = layer5[Gamedata.instance.backgroundIndex];
        Gamedata.instance.backgroundIndex = (Gamedata.instance.backgroundIndex < 5) ? Gamedata.instance.backgroundIndex + 1 : 0;
    }
}
