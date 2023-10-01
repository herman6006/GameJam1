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
    [SerializeField] private AudioClip buttonHit, yellowT, yellowF;
    private bool canStart;
    private bool inArea;
    private bool lockedIn = false;
    private bool buttonCooldown = false;
    private bool pointRecieved = false;
    private RectTransform yellowRectTransform;
    private Image loadBarImage;
    private AudioSource audioSource;
    private int points = 0;
    public string code;
    private bool isFinished = false;
    private void Start()
    {
        loadBarImage = loadingBar.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        canStart = pressurePlate.GetComponent<PressurePlate>().isActive;
        inArea = task1trigger.GetComponent<Task1Trigger>().isAtTerminal;
        yellowRectTransform = yellowBarPos.GetComponent<RectTransform>();

        if (lockedIn && Input.GetButtonDown("e"))
        {
            error.SetActive(false);
            taskBackground.SetActive(false);
            button.SetActive(false);
            loadingBar.SetActive(false);
            yellowBar.SetActive(false);
            displayCode.SetActive(false);
            lockedIn = false;
            StopAllCoroutines();
            BroadcastMessage("DestroyAllRemaining");
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
            button.SetActive(true);
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
        yield return new WaitForSeconds(0.2f);
        while (points <= 6)
        {
        Instantiate(yellowBar, yellowRectTransform.position, Quaternion.identity, transform);
        yield return new WaitForSeconds(Random.value+0.7f); // make random
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
            audioSource.PlayOneShot(buttonHit, 1f);
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
            audioSource.PlayOneShot(yellowF, 1f);
        }
    }
    private void AddPoint()
    {   if (points <= 6)
        {
        audioSource.PlayOneShot(yellowT, 0.7f);
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
