using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DatorController : MonoBehaviour
{
    [SerializeField] private GameObject datorTrigger, UISprite, task1, player, UIbutton, redButton, blueButton, greenButton, yellowButton, correctOrWrong, colorDisplay;
    [SerializeField] private Sprite[] UISprites;
    [SerializeField] private AudioClip powerOn;
    private AudioSource audioSource;
    private bool inArea;
    private bool lockedIn = false;
    private bool canExit = true;
    private Image UIImage, correctOrWrongImage, displayColorImage;
    [SerializeField] private TMP_Text codeInputTxt;
    private string noSpacesCode;
    private string colorString;
    private string answerString;
    private int answerAmount;
    private int level;
    void Start()
    {
        UIImage = UISprite.GetComponent<Image>();
        correctOrWrongImage = correctOrWrong.GetComponent<Image>();
        displayColorImage = colorDisplay.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        level = 1;
    }
    void Update()
    {
        inArea = datorTrigger.GetComponent<Task1Trigger>().isAtTerminal;
        if (lockedIn && Input.GetButtonDown("e") && canExit)
        {
            UISprite.SetActive(false);
            UIbutton.SetActive(false);
            codeInputTxt.gameObject.SetActive(false);
            lockedIn = false;
            player.GetComponent<PlayerScript>().canMove = true;
        }
        else if (Input.GetButtonDown("e") && inArea && !lockedIn)
        {
            UISprite.SetActive(true);
            audioSource.PlayOneShot(powerOn, 1f);
            player.GetComponent<PlayerScript>().StopMovement();
            lockedIn = true;
            codeInputTxt.text = "";
            codeInputTxt.gameObject.SetActive(true);
            noSpacesCode = "";
        }
        else if (lockedIn && Input.GetKeyDown(KeyCode.Backspace) && canExit)
        {
            if (codeInputTxt.text.Length > 1)
            {
                string placeholder = codeInputTxt.text;
                placeholder = placeholder.Remove(placeholder.Length - 1, 1);
                codeInputTxt.text = placeholder.Remove(placeholder.Length - 1, 1);
                noSpacesCode = noSpacesCode.Remove(noSpacesCode.Length - 1, 1);
            }
        }
        else if (lockedIn && Input.anyKeyDown && canExit)
        {
            if (codeInputTxt.text.Length < 8)
            {
                codeInputTxt.text += Input.inputString + " ";
                if (noSpacesCode.Length < 4)
                {
                    noSpacesCode += Input.inputString;
                    print(noSpacesCode);
                    if (noSpacesCode == "1337")
                    {
                        StartCoroutine(Captcha());
                        canExit = false;
                        codeInputTxt.gameObject.SetActive(false);
                    }
                }
            }

        }

    }
    private IEnumerator Captcha()
    {
        yield return new WaitForSeconds(1);
        UIImage.sprite = UISprites[1];
        yield return new WaitForSeconds(1);
        UIImage.sprite = UISprites[2];
        yield return new WaitForSeconds(0.5f);
        UIImage.sprite = UISprites[3];
        yield return new WaitForSeconds(0.5f);
        UIImage.sprite = UISprites[2];
        yield return new WaitForSeconds(0.5f);
        UIImage.sprite = UISprites[3];
        yield return new WaitForSeconds(0.5f);
        UIImage.sprite = UISprites[4];
        UIbutton.SetActive(true);
    }
    private IEnumerator CaptchaMinigame()
    {
        UIbutton.SetActive(false);
        StartCoroutine(MinigameLevel(1, 1));
        yield return new WaitUntil(() => level == 2);
        StartCoroutine(MinigameLevel(4, 2));
        yield return new WaitUntil(() => level == 3);
        StartCoroutine(MinigameLevel(8, 3));
        yield return new WaitUntil(() => level == 4);
        print("No Way");
    }
    public void StartMinigame()
    {
        StartCoroutine(CaptchaMinigame());
    }
    public void RedPressed()
    {
        answerString += "red";
        answerAmount++;
    }
    public void BluePressed()
    {
        answerString += "blue";
        answerAmount++;
    }
    public void YellowPressed()
    {
        answerString += "yellow";
        answerAmount++;
    }
    public void GreenPressed()
    {
        answerString += "green";
        answerAmount++;
    }

    private void EnableColorButtons(bool yesOrNo)
    {
        redButton.SetActive(yesOrNo);
        blueButton.SetActive(yesOrNo);
        greenButton.SetActive(yesOrNo);
        yellowButton.SetActive(yesOrNo); 
    }
    private void ChooseRandomColor()
    {
        var value = Random.Range(1, 5);
        if (value == 1)
        {
            displayColorImage.color = Color.red;
            colorString += "red";
        } else if (value == 2)
        {
            displayColorImage.color = Color.green;
            colorString += "green";
        } else if (value == 3)
        {
            displayColorImage.color = Color.blue;
            colorString += "blue";
        } else if (value == 4)
        {
            displayColorImage.color = Color.yellow;
            colorString += "yellow";
        }
    }
    private IEnumerator MinigameLevel(int colorAmount, int thisLevel)
    {
        while (level == thisLevel)
        {
        answerString = "";
        colorString = "";
        answerAmount = 0;
        UIImage.sprite = UISprites[5];
        yield return new WaitForSeconds(2f);
        UIImage.sprite = UISprites[6];
        for (int i = 0; i < colorAmount; i++)
        {
        ChooseRandomColor();
        colorDisplay.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        colorDisplay.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        }
        if (colorAmount > 1)
        {
            UIImage.sprite = UISprites[8];
        }
        else
        {
            UIImage.sprite = UISprites[7];
        }
        EnableColorButtons(true);
        yield return new WaitUntil(() => answerAmount == colorAmount);
        EnableColorButtons(false);
        if (answerString == colorString)
        {
            correctOrWrongImage.sprite = UISprites[10];
        }
        else
        {
            correctOrWrongImage.sprite = UISprites[11];
        }
        correctOrWrong.SetActive(true);
        //play sfx depending on
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
        if (answerString == colorString)
        {
            level++;
        }
        }
    }
}
//10 = correct 11 = wrong