using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Task1Controller : MonoBehaviour
{
    [SerializeField] private GameObject pressurePlate, task1trigger, taskBackground, error, button, loadingBar, yellowBar, yellowBarPos;
    private bool canStart;
    private bool inArea;
    private bool lockedIn = false;
    private bool checkDetection = false;
    private bool buttonCooldown = false;
    private RectTransform yellowRectTransform;

    private void Start()
    {
        
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
            lockedIn = false;
            //Enable player movement
        }
        else if (Input.GetButtonDown("e") && canStart && inArea && !lockedIn)
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
    }
    private IEnumerator Minigame()
    {
        yield return new WaitForSeconds(2); // make random
        Instantiate(yellowBar, yellowRectTransform.position, Quaternion.identity, transform);
        yield return new WaitForSeconds(2);
        Instantiate(yellowBar, yellowRectTransform.position, Quaternion.identity, transform);
    }

    public void ButtonPessed()
    {
        if (!buttonCooldown)
        {
            //play sfx?
            checkDetection = true;
            buttonCooldown = true;
            Invoke("ButtonDeactivate", 0.05f);
            Invoke("RemoveCooldown", 0.5f);

        }
    }
    private void ButtonDeactivate()
    {
        checkDetection=false;   
    }

    private void RemoveCooldown()
    {
        buttonCooldown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Yes");
        if (other.CompareTag("YellowBar") && checkDetection == true)
        {
            Destroy(other.gameObject);
        }
    }
}
