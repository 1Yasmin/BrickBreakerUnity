using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barPlayer : MonoBehaviour {
	
	Vector3 barraTras;
    float factorVel;


	// Use this for initialization
	void Start () {
		// estado inicial
        barraTras = new Vector3(0.0f, 0.0f, 0.0f);
        //factor de la velocidad en el juego
        factorVel = 12.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
        //iniciar la barra
        barraTras.x = 0.0f;
        barraTras.y = 0.0f;
        barraTras.z = 0.0f;
			
		// movimiento en x positiva con la flecha derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            barraTras.x = factorVel * Time.deltaTime;
            transform.Translate(barraTras);
        }
        // movimiento en x negativa con la flecha izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            barraTras.x = -factorVel * Time.deltaTime;
            transform.Translate(barraTras);
        }
				
		
	}
		
}
