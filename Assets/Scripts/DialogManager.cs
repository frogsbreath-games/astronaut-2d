using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject PlayerDialog;
    // Start is called before the first frame update
    public void Enable()
    {
        PlayerDialog.SetActive(true);
    }

    // Update is called once per frame
    public void Disable()
    {
        PlayerDialog.SetActive(false);
    }
}
