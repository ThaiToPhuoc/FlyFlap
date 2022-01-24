using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class coin : MonoBehaviour
{
    public SkeletonAnimation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation.state.Complete += AnimationCompleteHandler;
    }
    public void AnimationCompleteHandler(TrackEntry trackEntry)
    {
        if(trackEntry.Animation.Name.Equals("Collect"))
        {
            Gamedata.instance.scoreCoin = false;
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -7f)
            Gamedata.instance.Ccoin = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animation.AnimationName = "Collect";
        if(!Gamedata.instance.scoreCoin)
        {
            Gamedata.instance.coinCount++;
            if (Gamedata.instance.Ccoin)
                Gamedata.instance.coin += 10;
            else
                Gamedata.instance.coin++;
            Gamedata.instance.Ccoin = true;
        }
    }
}
