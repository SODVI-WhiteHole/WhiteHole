using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Historia_Intro : MonoBehaviour {

	/*Programado por José
	Este código administra la escena Historia_Introductoria.
	Corrige el texto segun el idioma elegido.
	Manda al menuPrincipal una vez que se le da clic al botón de Skip.
	*/


	// Use this for initialization
	void Start () {
	
	}
	


	public void irAMenuPrincipal(){
		SceneManager.LoadScene("Menu_principal");
	}

	
}
