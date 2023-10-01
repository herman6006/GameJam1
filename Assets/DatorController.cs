using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEditor.PackageManager;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;


public class DatorController : MonoBehaviour
{
    [SerializeField] private GameObject datorTrigger, UISprite, task1, player;
    [SerializeField] private Sprite[] UISprites;
    private bool inArea;
    private bool lockedIn = false;
    private bool canExit = true;
    private Image UIImage;
    [SerializeField] private TMP_Text codeInputTxt;
    private Text codeInput;
    void Start()
    {
        UIImage = UISprite.GetComponent<Image>();
    }
    void Update()
    {
        inArea = datorTrigger.GetComponent<Task1Trigger>().isAtTerminal;
        if (lockedIn && Input.GetButtonDown("e") && canExit)
        {
            UISprite.SetActive(false);
            lockedIn = false;
            player.GetComponent<PlayerScript>().canMove = true;
        }
        else if (Input.GetButtonDown("e") && inArea && !lockedIn)
        {
            UISprite.SetActive(true);
            player.GetComponent<PlayerScript>().StopMovement();
            lockedIn = true;
            codeInput.text = "a";
            write();
            
        }
    }
    private void write()
    {
        while (codeInput.text != task1.GetComponent<Task1Controller>().code.ToString())
        {
            if (Input.anyKeyDown)
            {
                print(Input.inputString);
                if (codeInput.text.Length < 4)
                {
                    codeInput.text += Input.inputString;
                }
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                string placeholder = codeInput.text;
                codeInput.text = placeholder.Remove(codeInput.text.Length - 1, 1);
            }
            for (int i = 0; i < codeInput.text.Length; i++)
            {
                codeInputTxt.text += codeInput.text[i] + " ";
            }
        }
    }
}
