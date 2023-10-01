using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask Mask;
    GameObject box;
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance,Mask);
        if (hit.collider != null && Input.GetKeyDown(KeyCode.E))
        {
            box = hit.collider.gameObject;
        }

    }
}
