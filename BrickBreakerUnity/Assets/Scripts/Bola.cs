using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bola : MonoBehaviour {

	// Instanciar los objetos
	private Rigidbody2D rb2D; // Rigid body de la bola
	public static int bloques = 0; //Contador de los bloques
	Vector2 posInicial; // Poscision inicial de la bola
	Vector2 direcVel; // Velocidad de la bola
	Vector2 barPos; //posicion inicial de la barra
	Vector2 stop; // sin velocidad en la bola
	public GameObject bar; // la barra del jugador
	int cont; // Evita que al inicio se le de velocidad a la bola

	// Use this for initialization
	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
		posInicial = new Vector2(0.06f,-2.91f);
		direcVel= new Vector2(0.0f, 6.0f);
		barPos = new Vector2 (0.0f, -3.3f);
		stop =  new Vector2 (0.0f, 0.0f);
		cont = 0;

	}
	
	// Update is called once per frame
	void Update () {

		// El jugador debe presionar la barra espaciadora para iniciar a jugar
		if (Input.GetKeyUp(KeyCode.Space)){
			rb2D.velocity = direcVel; // le da la velocidad a la bola
			transform.parent = null; // la bola ya no es hijo de la barra
			rb2D.isKinematic = false; // la bola no depende de la barra
		}
			
		// Al perder una vida
		if (transform.position.y < -6.0f)
		{
			Score.instance.VidasCount(); // resta una vida
			bar.transform.position = barPos; // regresar la barra a la posicion inicial
			transform.position = posInicial; // regresar la bola a la posicion inicial
 			rb2D.velocity = stop; // quitarle la velocidad a la bola
			transform.parent = bar.transform; // la bola es hijo de la barra
			rb2D.isKinematic = true; // la bola depende de la barra
			cont = 0; 
			if (Input.GetKeyUp(KeyCode.Space)){
				rb2D.velocity = direcVel; // le da la velocidad a la bola 
				transform.parent = null;// la bola ya no es hijo de la barra
				rb2D.isKinematic = false;// la bola no depende de la barra
			}
		}

		
	}

	// Define la direccion de la bola segun golpee la barra
	float hitfactor(Vector2 ballPos, Vector2 playerPos, float height){
		return (ballPos.x - playerPos.x) / height;
	}

	void OnCollisionEnter2D(Collision2D col)
    {
		// Destruir los bloques
		if (col.gameObject.name.Contains("bloque"))
        {
            Destroy(col.gameObject); // destruye los bolques
			Score.instance.PuntoPlayer(); // aumenta los puntos
            bloques++; // conteo de los bloques destruidos
			if (bloques == 28) { //nivel 1 completado
				SceneManager.LoadScene(3); //carga nivel 2
			}
			if (bloques == 44) { // nivel 2 completado
				SceneManager.LoadScene(4); // cargar nivel 3
			}
			if (bloques == 57) { // nivel 3 completado
				SceneManager.LoadScene(5); // carga escena de juego ganado
			}
        }

	
		//Direccion de la bola al colisionar con la barra del player 
		if (col.gameObject.name == "player")
		{
			cont+= 1; // permite dar velocidad a la bola

			if (cont > 1) {
				Debug.Log(col.gameObject.name);
				float x = hitfactor (transform.position, col.transform.position,col.collider.bounds.size.x); // direccion segun la posicion
				Vector2 dire = new Vector2 (x, 1).normalized; // nueva velocidad
				rb2D.velocity = dire * 6.0f; // cambio de la velocidad
			}
		}
}
}