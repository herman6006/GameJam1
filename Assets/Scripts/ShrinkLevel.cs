using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkLevel : MonoBehaviour
{
    [SerializeField] private GameObject leftWall, rightWall, topWall, botWall;  
    void Start()
    {
        StartCoroutine(Shrink());
    }
    private IEnumerator Shrink()
    {
        for (int i = 0; i < 14; i++)
        {
            yield return new WaitForSeconds(2);
            rightWall.transform.position = new Vector3(rightWall.transform.position.x - 0.5f, rightWall.transform.position.y); 
            leftWall.transform.position = new Vector3(leftWall.transform.position.x + 0.5f, leftWall.transform.position.y);
            topWall.transform.localScale = new Vector3(topWall.transform.localScale.x - 1, topWall.transform.localScale.y, 0);
            botWall.transform.localScale = new Vector3(botWall.transform.localScale.x - 1, botWall.transform.localScale.y, 0);
        }
    }
}
