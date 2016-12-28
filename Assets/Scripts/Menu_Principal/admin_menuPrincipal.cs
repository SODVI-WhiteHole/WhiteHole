using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class admin_menuPrincipal : MonoBehaviour {

	/*Programado por José.
	 * Este código es el administrador general del menu principal.
	 * Dice en que momento debe aparecer el titulo, el carrusel, el menu de opciones y la pantalla de créditos.
	*/

	public string fase="";


	public Image Cortinilla;

	public GameObject fondo;


	public GameObject seccionInicio;

	public Image Titulo;
	public GameObject PressEnter;
	public Text SODVI;

	Animator animadorMenu;

	// Use this for initialization
	void Start () {
		fase="Abriendo";
		animadorMenu=this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if(fase!="Espera"){

			switch (fase){

				case "Abriendo":
					Abrir();
					break;

				case "Entrando a Menu":
					abrirMenu();
					break;

				default:
					break;
			}

		}
			
	}




	//Esta función trabaja en conjunto con la cortinilla y realiza la apertura del menu principal
	//Aparece el titulo y nos activa el boton de presionar start después de ello.
	void Abrir(){
		if(Cortinilla.color.a<=0.4){
			if(Titulo.color.a<1){
				Titulo.color+=new Color(0.0f,0.0f,0.0f,0.4f)*Time.deltaTime;

			}else if(Titulo.color.a>=0.3f&&SODVI.color.a<1.0f){
				SODVI.color+=new Color(0.0f,0.0f,0.0f,0.6f)*Time.deltaTime;
			}else if(SODVI.color.a>=0.3f){
				PressEnter.GetComponent<presionaEnter>().afectarAlfa=true;
				fase="Espera";
				print("Entramos a Fase de Espera");
			}
		}
	}


	void abrirMenu(){
		Titulo.color-=new Color(0.0f,0.0f,0.0f,0.7f)*Time.deltaTime;
		SODVI.color-=new Color(0.0f,0.0f,0.0f,0.7f)*Time.deltaTime;
		PressEnter.GetComponent<Text>().color-=new Color(0.0f,0.0f,0.0f,0.7f)*Time.deltaTime;

		//fondo.GetComponent<Image>().color-=new Color(0.0f,0.0f,0.0f,0.2f)*Time.deltaTime;

		seccionInicio.GetComponent<RectTransform>().localScale+=new Vector3(0.2f,0.2f,0.2f)*Time.deltaTime;
		print("Estamos abriendo el menu");

		if(Titulo.color.a<=0.0f){
			seccionInicio.SetActive(false);
			fase="Espera";
			animadorMenu.SetTrigger("colocarCarrusel");
		}
	}


}
