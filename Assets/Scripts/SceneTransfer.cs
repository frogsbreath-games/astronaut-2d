using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour { 
    public string SceneToLoadName;
    public VectorValue PlayerStoredLocation;
    public Vector2 LoadPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            PlayerStoredLocation.InitialValue = LoadPosition;
            SceneManager.LoadScene(SceneToLoadName);
        }
    }
}
