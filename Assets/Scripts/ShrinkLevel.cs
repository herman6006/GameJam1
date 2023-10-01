using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkLevel : MonoBehaviour
{
    [SerializeField] private GameObject leftWall, rightWall, topWall, botWall, leftVoid, rightVoid, leftSpikes, rightSpikes, musicPlayer;
    private BoxCollider2D box;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private IEnumerator Shrink()
    {
        for (int i = 0; i< 1000 ; i++)
        {
            leftSpikes.transform.position = new Vector3(leftSpikes.transform.position.x + 0.001f, leftSpikes.transform.position.y);
            rightSpikes.transform.position = new Vector3(rightSpikes.transform.position.x - 0.001f, rightSpikes.transform.position.y);
            yield return new WaitForSeconds(0.001f);
        }
        musicPlayer.GetComponent<MusicScript>().StartMusic();
        for (int i = 0; i < 14; i++)
        {
            yield return new WaitForSeconds(2);
            rightWall.transform.position = new Vector3(rightWall.transform.position.x - 0.5f, rightWall.transform.position.y); 
            leftWall.transform.position = new Vector3(leftWall.transform.position.x + 0.5f, leftWall.transform.position.y);
            topWall.transform.localScale = new Vector3(topWall.transform.localScale.x - 1, topWall.transform.localScale.y, 0);
            botWall.transform.localScale = new Vector3(botWall.transform.localScale.x - 1, botWall.transform.localScale.y, 0);

            rightVoid.transform.position = new Vector3(rightVoid.transform.position.x - 0.5f, rightVoid.transform.position.y);
            leftVoid.transform.position = new Vector3(leftVoid.transform.position.x + 0.5f, leftVoid.transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        StartCoroutine(Shrink());
        box.enabled = false;
        }
    }
}
