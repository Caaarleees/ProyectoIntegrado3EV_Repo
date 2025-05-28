using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float tiempoTotal = 120f; // 2 minutos en segundos
    public TextMeshProUGUI textoTemporizador;

    private float tiempoRestante;
    private bool temporizadorActivo = false;

    void Start()
    {
        tiempoRestante = tiempoTotal;
        temporizadorActivo = true;
    }

    void Update()
    {
        if (temporizadorActivo)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime;
                MostrarTiempo(tiempoRestante);
            }
            else
            {
                Debug.Log("¡El tiempo ha terminado!");
                tiempoRestante = 0;
                temporizadorActivo = false;
                MostrarTiempo(tiempoRestante);
            }
        }
    }

    void MostrarTiempo(float tiempoAMostrar)
    {
        tiempoAMostrar += 1;

        float minutos = Mathf.FloorToInt(tiempoAMostrar / 60);
        float segundos = Mathf.FloorToInt(tiempoAMostrar % 60);

        textoTemporizador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
