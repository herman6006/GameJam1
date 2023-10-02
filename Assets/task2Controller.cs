using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class task2Controller : MonoBehaviour
{
    [SerializeField] private GameObject pressurePlate2, task2trigger, UIImage, player, correctOrWrong;
    [SerializeField] private AudioClip powerOn;
    [SerializeField] private Sprite correct, wrong;
    [SerializeField] private Sprite[] BananaSprites;
    [SerializeField] private Sprite[] xSprites;
    [SerializeField] private Sprite[] ySprites;
    [SerializeField] private Image[] frames;
    private AudioSource audioSource;
    private bool canStart;
    private bool inArea;
    private bool lockedIn = false;
    private bool isFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        canStart = pressurePlate2.GetComponent<PressurePlate>().isActive;
        inArea = task2trigger.GetComponent<Task1Trigger>().isAtTerminal;
        if (lockedIn && Input.GetButtonDown("e"))
        {
            lockedIn = false;
            StopAllCoroutines();
            player.GetComponent<PlayerScript>().canMove = true;
        }
        else if (Input.GetButtonDown("e") && canStart && inArea && !lockedIn && !isFinished)
        {
            UIImage.SetActive(true);
            lockedIn = true;
            audioSource.PlayOneShot(powerOn, 1f);
            player.GetComponent<PlayerScript>().StopMovement();
            //Disable player movement
        }
        else if (Input.GetButtonDown("e") && !canStart && inArea && !lockedIn)
        {
            lockedIn = true;
            player.GetComponent<PlayerScript>().StopMovement();
        }
        else if (Input.GetButtonDown("e") && canStart && inArea && !lockedIn && isFinished)
        {
            UIImage.SetActive(true);
            lockedIn = true;
            player.GetComponent<PlayerScript>().StopMovement();
        }
    }
    private IEnumerator PictureGame()
    {
        yield return new WaitForSeconds(0.01f);
        Randomize();
        frames[0].gameObject.SetActive(true);
        frames[1].gameObject.SetActive(true);
        frames[2].gameObject.SetActive(true);
    }

    private void Randomize()
    {
        var value = Random.Range(1, 4);
        var numbers = new List<int>() { 0, 1, 2, 3, 4 };
        if (value == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                var randomValue = Random.Range(0, numbers.Count);
                frames[i].sprite = BananaSprites[numbers[randomValue]];
                numbers.RemoveAt(randomValue);
            }
        }
        else if (value == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                var randomValue = Random.Range(0, numbers.Count);
                frames[i].sprite = xSprites[numbers[randomValue]];
                numbers.RemoveAt(randomValue);
            }
        }
        else if (value == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                var randomValue = Random.Range(0, numbers.Count);
                frames[i].sprite = ySprites[numbers[randomValue]];
                numbers.RemoveAt(randomValue);
            }
        }
    }
}
