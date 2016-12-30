using UnityEngine;
using System.Collections;

public class desvanecerMusica : MonoBehaviour {

	//Programado por José
	/*Este código realiza un efecto de desvanecer la música para entradas y salidas de la escena.*/


	public bool desvanecer=false;

	public AudioSource musica;
	public float velocidad=5.0f;

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {

		if(desvanecer){
			apagarMusica();
		}
	
	}



	void apagarMusica(){
		if(musica.volume>0){
			musica.volume-=velocidad*Time.deltaTime;
		}else if (musica.volume<=0){
			desvanecer=false;
		}		
	}


}
