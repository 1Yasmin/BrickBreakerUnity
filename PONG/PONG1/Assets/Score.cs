using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public static Score instance;

    public Text txtScore1;
    public Text txtScore2;
    public int player1;
    public int player2;

	// Use this for initialization
	void Start () {
        instance = this;
        player1 = 0;
        player2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PuntoPlayer1()
    {
        player1 += 1;
        txtScore1.text = player1.ToString(); 
        if(player1 > 4)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void PuntoPlayer2()
    {
        player2 += 1;
        txtScore2.text = player2.ToString();
        if (player2 > 4)
        {
            SceneManager.LoadScene(2);

        }
    }
}

