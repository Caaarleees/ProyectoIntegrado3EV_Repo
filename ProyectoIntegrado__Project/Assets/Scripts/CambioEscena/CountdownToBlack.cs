using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownToBlack : MonoBehaviour
{
    public float countdownTime = 120f; // duración de la cuenta atrás en segundos
    public TextMeshProUGUI countdownText; // texto para mostrar la cuenta regresiva
    public GameObject blackScreen; // panel que se mostrará al terminar la cuenta

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
        blackScreen.SetActive(false); // asegúrate de que la pantalla negra esté oculta al inicio
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
