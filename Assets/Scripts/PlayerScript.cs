using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private GameObject GameOverScreen, musicPlayer;
    private float xvelocity;
    private float yvelocity;
    private Animator anim;
    Vector2 movement;
    public bool canMove;


    private Rigidbody2D rgbd;
    void Start()
    {
        canMove = true;
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        xvelocity = Input.GetAxisRaw("Horizontal");
        yvelocity = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", xvelocity);
        anim.SetFloat("Vertical", yvelocity);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        //anim.SetFloat("Movespeed", Mathf.Abs(rgbd.velocity.x));
        //anim.SetFloat("Movespeed", Mathf.Abs(rgbd.velocity.y));
    }

    void FixedUpdate()
    {
        if (canMove)
        {
        if (xvelocity != 0 && yvelocity != 0)
        {
            xvelocity *= 0.75f;
            yvelocity *= 0.75f;
        }
        rgbd.velocity = new Vector2(xvelocity * moveSpeed, yvelocity * moveSpeed);

        }
    }

    public void StopMovement()
    {
        canMove = false;
        xvelocity = 0;
        yvelocity = 0;
        rgbd.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            GameOverScreen.SetActive(true);
            StopMovement();
            musicPlayer.GetComponent<MusicScript>().StopMusic();
  

        }
    }
}
