﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOverlayManager : MonoBehaviour
{
    public GameObject MainOverlayTextObject;
    public Text OverlayText;

    public IEnumerator DisplayTextOverlay(string TextName, float timeDisplayed)
    {
        //TODO Make Settings script to manage managers
        MainOverlayTextObject.SetActive(true);
        OverlayText.text = TextName;
        yield return new WaitForSeconds(timeDisplayed);
        MainOverlayTextObject.SetActive(false);
    }
}
