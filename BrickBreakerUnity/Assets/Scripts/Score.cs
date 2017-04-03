using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour {

	// Instanciar los objetos
	public static Score instance;

	public Text txtScore; // txt de los puntos
	public Text txtVidas; // txt de las vidas
	public static int player; // puntos 
	public static int vidas = 3; //vidas

	// Use this for initialization
	void Start () {
		instance = this;
		txtScore.text = "Score: "+ Score.player; //cambia el texto del score
 		txtVidas.text = "Vidas: "+ Score.vidas; //cambia el texto de las vidas
	}

	// contador de los puntos del jugador
	public void PuntoPlayer()
	{
		// aumenta 10 al score
		player = player + 10;
		txtScore.text = "Score: "+ Score.player; // cambia el texto del score 

	}

	// contador de los puntos del player 2
	public void VidasCount()
	{
		vidas = vidas - 1;
		txtVidas.text = "Vidas: " + Score.vidas; //cambia el texto del player 2
		if (vidas == 0) {
			SceneManager.LoadScene(1);
			Score.vidas = 3; // reinicia las vidas
			Score.player = 0; // reinicia los puntos en 0
			Bola.bloques = 0; // reinicia el conteo de los bloques
		}
	}
}
