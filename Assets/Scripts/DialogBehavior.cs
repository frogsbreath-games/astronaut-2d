using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBehavior : MonoBehaviour
{
    public GameObject Dialog;
    public Text DialogText;
    public string Text;
    public bool PlayerCanInteract;
    public SignalEvent QuestionOn;
    public SignalEvent QuestionOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerCanInteract)
        {
            if (Dialog.activeInHierarchy)
            {
                Dialog.SetActive(false);
            }
            else
            {
                Dialog.SetActive(true);
                DialogText.text = Text;
                QuestionOff.Raise();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger)
        {
            PlayerCanInteract = true;
            if (!Dialog.activeInHierarchy)
            {
                QuestionOn.Raise();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger)
        {
            PlayerCanInteract = false;
            Dialog.SetActive(false);
            QuestionOff.Raise();
        }
    }
}
