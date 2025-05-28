using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownToBlack : MonoBehaviour
{
    public float countdownTime = 120f; // duraci�n de la cuenta atr�s en segundos
    public TextMeshProUGUI countdownText; // texto para mostrar la cuenta regresiva
    public GameObject blackScreen; // panel que se mostrar� al terminar la cuenta

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
        blackScreen.SetActive(false); // aseg�rate de que la pantalla negra est� oculta al inicio
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = Mathf.Ceil(currentTime).ToString();
        }
        else
        {
            countdownText.text = "";
            blackScreen.SetActive(true);
        }
    }
}
