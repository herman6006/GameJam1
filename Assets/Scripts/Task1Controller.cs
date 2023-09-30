using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Task1Controller : MonoBehaviour
{
    [SerializeField] private GameObject pressurePlate, task1trigger, taskBackground, error, button, loadingBar, yellowBar, yellowBarPos, displayCode;
    [SerializeField] private Sprite[] loadingBarSprites;
    [SerializeField] private TMP_Text displayCodeTxt;
    private bool canStart;
    private bool inArea;
    private bool lockedIn = false;
    private bool buttonCooldown = false;
    private bool pointRecieved = false;
    private RectTransform yellowRectTransform;
    private Image loadBarImage;
    private int points = 0;
    public string code;
    private bool isFinished = false;
    private void Start()
    {
        loadBarImage = loadingBar.GetComponent<Image>();
    }
    void Update()
    {
        canStart = pressurePlate.GetComponent<PressurePlate>().isActive;
        inArea = task1trigger.GetComponent<Task1Trigger>().isAtTerminal;
        yellowRectTransform = yellowBarPos.GetComponent<RectTransform>();

        canStart = true;
        if (lockedIn && Input.GetButtonDown("e"))
        {
            error.SetActive(false);
            taskBackground.SetActive(false);
            button.SetActive(false);
            loadingBar.SetActive(false);
            yellowBar.SetActive(false);
            displayCode.SetActive(false);
            lockedIn = false;
            //Enable player movement
        }
        else if (Input.GetButtonDown("e") && canStart && inArea && !lockedIn && !isFinished)
        {
            taskBackground.SetActive(true);
            button.SetActive(true);
            loadingBar.SetActive(true);
            yellowBar.SetActive(true);
            StartCoroutine(Minigame());
            lockedIn = true;
            //Disable player movement
        }
        else if (Input.GetButtonDown("e") && !canStart && inArea && !lockedIn)
        {
            error.SetActive(true);
            lockedIn = true;
            //Disable player movement
        }
        else if (Input.GetButtonDown("e") && canStart && inArea && !lockedIn && isFinished)
        {
            taskBackground.SetActive(true);
            yellowBar.SetActive(true);
            displayCode.SetActive(true);
            lockedIn = true;
            //Disable player movement
        }
    }
    private IEnumerator Minigame()
    {
        while (points <= 6)
        {
        yield return new WaitForSeconds(Random.value+0.7f); // make random
        Instantiate(yellowBar, yellowRectTransform.position, Quaternion.identity, transform);
        }
        yield return new WaitForSeconds(0.2f);
        loadingBar.SetActive(false);
        code = Random.Range(1000, 10000).ToString();
        displayCodeTxt.text = "CODE = " + code;
        displayCode.SetActive(true);
        isFinished = true;
    }

    public void ButtonPessed()
    {
        if (!buttonCooldown)
        {
            pointRecieved = false;
            BroadcastMessage("ButtonPressed");
            buttonCooldown = true;
            Invoke("RemoveCooldown", 0.1f);
            Invoke("CheckIfHit", 0.05f);

        }
    }
    private void RemoveCooldown()
    {
        buttonCooldown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("YellowBar"))
        {
            other.gameObject.GetComponent<yellowBar>().isTouching = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("YellowBar"))
        {
            other.gameObject.GetComponent<yellowBar>().isTouching = false;
        }
    }

    private void CheckIfHit()
    {
        if (!pointRecieved && points > 0 && points <=6)
        {
            points--;
            UpdateLoadBar();
        }
    }
    private void AddPoint()
    {   if (points <= 6)
        {
        print("Ding");
        pointRecieved = true;
        points++;
        UpdateLoadBar();

        }
    }

    private void UpdateLoadBar()
    {
        loadBarImage.sprite = loadingBarSprites[points];
    }
}
