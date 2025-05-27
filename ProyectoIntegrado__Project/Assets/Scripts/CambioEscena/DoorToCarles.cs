using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToCarles : MonoBehaviour
{
    [SerializeField] private string targetSceneName = "EscenaCarles";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entrando por la puerta hacia: " + targetSceneName);
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
