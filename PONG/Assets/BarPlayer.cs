using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarPlayer : MonoBehaviour
{


    Vector3 barraTras;
    float factorVel;
    public int player;
    // Use this for initialization
    void Start()
    {
        // estado inicial
        barraTras = new Vector3(0.0f, 0.0f, 0.0f);
        //factor de la velocidad en el juego
        factorVel = 12.0f;
    }    // Update is called once per frame
    void Update()
    {
        //iniciar las barras 
        barraTras.x = 0.0f;
        barraTras.y = 0.0f;
        barraTras.z = 0.0f;


        // definir el movimiento de la barra del player 1
        if (player == 1)
        {
            // movimiento en y positiva con la flecha de arriba
            if (Input.GetKey(KeyCode.W))
            {
                barraTras.y = factorVel * Time.deltaTime;
                transform.Translate(barraTras);
            }

            // movimiento en y negativa con la flecha de abajo
            if (Input.GetKey(KeyCode.S))
            {
                barraTras.y = -factorVel * Time.deltaTime;
                transform.Translate(barraTras);
            }


        }
        // Definir el movimiento de la barra del player 2
        if (player == 2)
        {
            // movimiento en y positiva con W
            if (Input.GetKey(KeyCode.UpArrow))
            {
                barraTras.y = factorVel * Time.deltaTime;
                transform.Translate(barraTras);
            }

            // movimiento en y negativa con S
            if (Input.GetKey(KeyCode.DownArrow))
            {
                barraTras.y = -factorVel * Time.deltaTime;
                transform.Translate(barraTras);
            }

        }
    }

   

}
