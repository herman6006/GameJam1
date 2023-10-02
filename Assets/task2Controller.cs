using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class task2Controller : MonoBehaviour
{
    [SerializeField] private GameObject pressurePlate2, task2trigger, UIImage, player, correctOrWrong, confirmButton, button1, button2, button3;
    [SerializeField] private AudioClip powerOn;
    [SerializeField] private TMP_Text codeDisplayTxt, pictureText;
    [SerializeField] private Sprite correct, wrong;
    [SerializeField] private Sprite[] BananaSprites;
    [SerializeField] private Sprite[] xSprites;
    [SerializeField] private Sprite[] ySprites;
    [SerializeField] private Sprite[] correctSprites;
    [SerializeField] private Image[] frames;
    private AudioSource audioSource;
    private bool canStart;
    private bool canExit = true;
    private bool inArea;
    private bool lockedIn = false;
    private bool isFinished = false;
    private int answer;
    private int playerAnswer;
    private int wasRight = 0;
    private Image correctOrWrongIMG;
    private int stage;
    public string code2;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        correctOrWrongIMG = correctOrWrong.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        canStart = pressurePlate2.GetComponent<PressurePlate>().isActive;
        inArea = task2trigger.GetComponent<Task1Trigger>().isAtTerminal;
        if (lockedIn && Input.GetButtonDown("e") && canExit)
        {
            lockedIn = false;
            UIImage.SetActive(false);
            codeDisplayTxt.gameObject.SetActive(false);
            isFinished = true;
            player.GetComponent<PlayerScript>().canMove = true;
        }
        else if (Input.GetButtonDown("e") && canStart && inArea && !lockedIn && !isFinished)
        {
            UIImage.SetActive(true);
            lockedIn = true;
            audioSource.PlayOneShot(powerOn, 1f);
            player.GetComponent<PlayerScript>().StopMovement();
            stage = 1;
            StartCoroutine(PictureGame());
            canExit = false;
            //Disable player movement
        }
    }
    private IEnumerator PictureGame()
    {
        while (stage == 1)
        {
        yield return new WaitForSeconds(0.01f);
        Randomize();
            pictureText.gameObject.SetActive(true);
            frames[0].gameObject.SetActive(true);
        frames[1].gameObject.SetActive(true);
        frames[2].gameObject.SetActive(true);
        confirmButton.SetActive(true);
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);

        yield return new WaitUntil(() => wasRight != 0);
        confirmButton.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        if (wasRight == 1)
        {
            correctOrWrongIMG.sprite = wrong;
        } else
        {
            correctOrWrongIMG.sprite = correct;
        }
        correctOrWrong.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        if (wasRight == 2)
        {
                wasRight = 0;
                stage++;
        }
            wasRight = 0;
        }
        while (stage == 2)
        {

        yield return new WaitForSeconds(0.01f);
        Randomize();
            pictureText.gameObject.SetActive(true);
            frames[0].gameObject.SetActive(true);
        frames[1].gameObject.SetActive(true);
        frames[2].gameObject.SetActive(true);
        confirmButton.SetActive(true);
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);

        yield return new WaitUntil(() => wasRight != 0);
        confirmButton.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        if (wasRight == 1)
        {
            correctOrWrongIMG.sprite = wrong;
        }
        else
        {
            correctOrWrongIMG.sprite = correct;
        }
        correctOrWrong.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        if (wasRight == 2)
        {
            wasRight = 0;
            stage++;
        }
        wasRight = 0;
        }
        while (stage == 3)
        {
        yield return new WaitForSeconds(0.01f);
        Randomize();
        pictureText.gameObject.SetActive(true);
        frames[0].gameObject.SetActive(true);
        frames[1].gameObject.SetActive(true);
        frames[2].gameObject.SetActive(true);
        confirmButton.SetActive(true);
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);

        yield return new WaitUntil(() => wasRight != 0);
        confirmButton.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        if (wasRight == 1)
        {
            correctOrWrongIMG.sprite = wrong;
        }
        else
        {
            correctOrWrongIMG.sprite = correct;
        }
        correctOrWrong.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        correctOrWrong.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        if (wasRight == 2)
        {
            code2 = Random.Range(10, 100).ToString();

            codeDisplayTxt.text = "CODE = ??" + code2;
            codeDisplayTxt.gameObject.SetActive(true);
            StopAllCoroutines();
                canExit = true;
            }
            else
            {
                wasRight = 0;
            }
        }
    }

    private void Randomize()
    {
        playerAnswer = 0;
        var value = Random.Range(1, 2);
        var numbers = new List<int>() { 0, 1, 2, 3, 4 };
        if (value == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                var randomValue = Random.Range(0, numbers.Count);
                frames[i].sprite = BananaSprites[numbers[randomValue]];
                numbers.RemoveAt(randomValue);
                pictureText.text = "Banana";
                
            }
        }
        else if (value == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                var randomValue = Random.Range(0, numbers.Count);
                frames[i].sprite = xSprites[numbers[randomValue]];
                numbers.RemoveAt(randomValue);
                // HÄR
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
        if (numbers.Contains(4))
        {
            answer = 0;
        } else { answer = 1; }
    }
    public void ConfirmAnswer()
    {
        if (answer == 0 && playerAnswer != 0)
        {
            wasRight = 1;
        } else if (answer == 0 && playerAnswer == 0)
        {
            wasRight = 2;
        } else if (answer == 1 && playerAnswer == 0)
        {
            wasRight = 1;
        }
        else if (frames[playerAnswer - 1].sprite == correctSprites[0] || frames[playerAnswer - 1].sprite == correctSprites[1] || frames[playerAnswer - 1].sprite == correctSprites[2])
        {
            wasRight = 2;
        } else
        {
            wasRight = 1;
        }
    }
    public void Button1()
    {
        playerAnswer = 1;
    }
    public void Button2()
    {
        playerAnswer = 2;
    }
    public void Button3()
    {
        playerAnswer = 3;
    }
}
