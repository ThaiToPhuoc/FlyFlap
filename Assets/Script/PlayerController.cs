using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public enum STATE
{
    FALLING, FLYING
}
public class PlayerController : MonoBehaviour
{
    //component
    public Rigidbody2D rigidbody2D;

    public BoxCollider2D boxCollider2D;

    public SkeletonAnimation animation;

    public Transform top, bottom;

    public audioManager audio;

    //properties
    public float speed = 150f, force = 200f;
    public bool down = false, fall = false;
    public STATE currentState = STATE.FLYING;
    private bool coin = false;

    float horizontalMove = 0f;
    // Start is called before the first frame update
    void Start()
    {
        setCharacterState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Gamedata.instance.pause == false)
        {
            audio.Play("Jump");
            down = true;
        }

        if(transform.position.y > top.position.y)
        {
            fall = true;
        }

        if(fall)
        {
            currentState = STATE.FALLING;
            setCharacterState(currentState);
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.gravityScale = 1f;
            rigidbody2D.AddForce(new Vector2(0f, -10f));
            boxCollider2D.isTrigger = true;
            fall = false;
        }

        if(transform.position.y < - Gamedata.instance.height()/2 - 1f)
        {
            Gamedata.instance.gameover = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove, rigidbody2D.velocity.y);
        rigidbody2D.velocity = targetVelocity;

        if (transform.position.x > -5f)
        {
            horizontalMove = 0f;
        }
        else
        {
            horizontalMove = speed * Time.deltaTime;
        }

        if(down)
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.AddForce(new Vector2(0f, -force));
            down = false;
        }
    }
    private void setCharacterState(STATE state)
    {
        switch (state)
        {
            case STATE.FLYING:
                animation.AnimationName = "Fly";
                break;
            case STATE.FALLING:
                animation.AnimationName = "Falldemo";
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fall = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Coin(Clone)"))
        {
            if(!Gamedata.instance.scoreCoin)
                audio.Play("Coin");
            Gamedata.instance.scoreCoin = true;
        }

    }
}
