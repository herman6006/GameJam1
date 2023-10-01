using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DatorController : MonoBehaviour
{
    [SerializeField] private GameObject datorTrigger, UISprite, task1, player;
    [SerializeField] private Sprite[] UISprites;
    [SerializeField] private AudioClip powerOn;
    private AudioSource audioSource;
    private bool inArea;
    private bool lockedIn = false;
    private bool canExit = true;
    private Image UIImage;
    [SerializeField] private TMP_Text codeInputTxt;
    private string noSpacesCode;
    void Start()
    {
        UIImage = UISprite.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        inArea = datorTrigger.GetComponent<Task1Trigger>().isAtTerminal;
        if (lockedIn && Input.GetButtonDown("e") && canExit)
        {
            UISprite.SetActive(false);
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
                    if (noSpacesCode == task1.GetComponent<Task1Controller>().code.ToString())
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
    }
}
//