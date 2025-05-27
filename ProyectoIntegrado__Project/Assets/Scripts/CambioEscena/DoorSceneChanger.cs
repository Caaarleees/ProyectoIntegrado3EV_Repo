using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneChanger : MonoBehaviour
{
   
    public string targetSceneName = "EscenaLuis"; // Cambiar a la escena deseada

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador ha entrado por la puerta. Cambiando a " + targetSceneName);
            SceneManager.LoadScene(targetSceneName);
        }
    }
}

