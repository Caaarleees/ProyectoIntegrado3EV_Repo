using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecargarEscena : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Recarga la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
