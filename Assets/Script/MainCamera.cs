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

    public List<SpriteRenderer> bg;

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
    }
}
