using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	 
	public void IniciarPartida() {
		SceneManager.LoadScene(2); // carga el nivel 1
		Score.vidas = 3; // reinicia las vidas
		Score.player = 0; // reinicia los puntos en 0
		Bola.bloques = 0; // reinicia la cuenta de los bloques destruidos
	}
}
