using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    IEnumerator Pausa()
    {

        yield return new WaitForSecondsRealtime(5);
    }

    // Use this for initialization
    void Start()
    {

        //Direccion de la velocidad en x
        int x = Random.Range(0, 2);
        //Direccion de la velocidad en y
        int y = Random.Range(0, 3);
        rb = GetComponent<Rigidbody>();

        //Vector que define la velocidad
        Vector3 direcVelocity = new Vector3();

        //Definir direccion en x
        if (x == 0)
        {
            direcVelocity.x = -8.0f;
        }
        if (x == 1)
        {
            direcVelocity.x = 8.0f;
        }

        //Definir direccion en y
        if (y == 0)
        {
            direcVelocity.y = -8.0f;
        }
        if (y == 1)
        {
            direcVelocity.y = 8.0f;
        }
        if (y == 3)
        {
            direcVelocity.y = 0.0f;
        }

        // velocidad de la bola
        rb.velocity = direcVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        //Sale del area de juego
       if(transform.position.x > 9.2f)
        {
            Score.instance.PuntoPlayer1();
            StartCoroutine(Pausa());
            rb.transform.position = new Vector3(0, 0, 0);
           
          
        }
        //Sale del area de juego
        if (transform.position.x < -9.2f)
        {
            Score.instance.PuntoPlayer2();
            StartCoroutine(Pausa());
            rb.transform.position = new Vector3(0, 0, 0);
         
        }

    }

  

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        //Direccion de la bola al topar con los extremos
        if (col.gameObject.name == "Pared1")
        {
            float xDirec = 0f;

            if (rb.velocity.x > 0.0f)
                xDirec = 8.0f;
            if (rb.velocity.x < 0.0f)
                xDirec = -8.0f;

            rb.velocity = new Vector3(xDirec, -8.0f , 0.0f);
            }
        if (col.gameObject.name == "Pared2")
        {
            float xDirec = 0f;

            if (rb.velocity.x > 0.0f)
                xDirec = 8.0f;
            if (rb.velocity.x < 0.0f)
                xDirec = -8.0f;

            rb.velocity = new Vector3(xDirec, 8.0f, 0.0f);
        }

        //Direccion de la bola al colisionar con la barra del player 1
        if (col.gameObject.name == "Player1")
        {
			//Colisio en el area central
            rb.velocity = new Vector3(8.0f, 0.0f, 0.0f);

			//Colisión en la parte inferior
            if (transform.position.y - col.gameObject.transform.position.y < -0.15f)
                rb.velocity = new Vector3(8.0f, 8.0f, 0.0f);

			//Colisión en la parte superior
            if (transform.position.y - col.gameObject.transform.position.y > 0.15f)
                rb.velocity = new Vector3(8.0f, -8.0f, 0.0f);
        }

		
        //Direccion de la bola al colisionar con la barra del player 2
        if (col.gameObject.name == "Player2")
        {
			//Colisio en el area central
            rb.velocity = new Vector3(-8.0f, 0.0f, 0.0f);
			
			
			//Colisión en la parte inferior
            if (transform.position.y - col.gameObject.transform.position.y < -0.15f)
                rb.velocity = new Vector3(8.0f, 8.0f, 0.0f);

			//Colisión en la parte superior
            if (transform.position.y - col.gameObject.transform.position.y > 0.15f)
                rb.velocity = new Vector3(8.0f, -8.0f, 0.0f);

        }

    }

    }


