using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] Cells;
    public Sprite Cell;
    public FloatValue HealthCells;
    public FloatValue PlayerCurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        InitHealthCells();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitHealthCells()
    {
        for (int i = 0; i < HealthCells.InitialValue; i++)
        {
            Cells[i].gameObject.SetActive(true);
            Cells[i].sprite = Cell;
        }
    }

    public void UpdateCells()
    {
        float health = PlayerCurrentHealth.RuntimeValue;
        for (int i = 0; i < HealthCells.RuntimeValue; i++)
        {
            if (i >= health)
            {
                Cells[i].gameObject.SetActive(false);
            }
        }

    }
}
