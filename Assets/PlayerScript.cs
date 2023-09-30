using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private float xvelocity;
    private float yvelocity;


    private Rigidbody2D rgbd;
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xvelocity = Input.GetAxisRaw("Horizontal");
        yvelocity = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (xvelocity != 0 && yvelocity != 0)
        {
            xvelocity *= 0.75f;
            yvelocity *= 0.75f;
        }
        rgbd.velocity = new Vector2(xvelocity * moveSpeed, yvelocity * moveSpeed);
    }
}
