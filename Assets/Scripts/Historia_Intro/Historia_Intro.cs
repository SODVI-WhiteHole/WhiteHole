using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Historia_Intro : MonoBehaviour {

	/*Programado por José
	Este código administra la escena Historia_Introductoria.
	Corrige el texto segun el idioma elegido.
	Manda al menuPrincipal una vez que se le da clic al botón de Skip.
	*/



	public GameObject cortinilla;
	public AudioSource SFX_Aceptar;


	public Text texto_titulo;
	public Text texto_descripcion;
	public Text texto_siguiente;

	// Use this for initialization
	void Start () {
		asignarIdioma();
	}

	public void irAMenuPrincipal(){
		SFX_Aceptar.Play();
		cortinilla.SetActive(true);
	}


	void asignarIdioma(){
		if(PlayerPrefs.GetString("IDIOMA")=="ESPANIOL"){
			texto_titulo.text="HISTORIA";
			texto_descripcion.text="Próximamente aquí habrá un comic increible que narrará la historia.";
			texto_siguiente.text="SIGUIENTE";
		}

		else if(PlayerPrefs.GetString("IDIOMA")=="ENGLISH"){
			texto_titulo.text="STORY";
			texto_descripcion.text="Here will be an incredibile comic that will tell the story. Coming Soon.";
			texto_siguiente.text="SKIP";
		}
	}

}
