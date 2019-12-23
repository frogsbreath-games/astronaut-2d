using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    private Transform Bar;

    private void Start()
    {
        Bar = transform.Find("Bar");
    }

    public void SetHealthBarSize(float health)
    {
        Bar.localScale = new Vector3(health, 1f);
    }

    public void SetHealthBarColor(Color color)
    {
        Bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
