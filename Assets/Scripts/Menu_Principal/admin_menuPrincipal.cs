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



	public Text texto_presionaStart;

	public Text texto_nuevoJuego;
	public Text texto_nuevoJuegoBrillo;

	public Text texto_continuar;
	public Text texto_continuarBrillo;

	public Text texto_opciones;
	public Text texto_opcionesBrillo;

	public Text texto_creditos;
	public Text texto_creditosBrillo;

	public Text texto_salir;
	public Text texto_salirBrillo;


	public Text texto_tituloOpciones;

	public Text texto_idioma;
	public Text texto_seleccionIdioma;

	public Text texto_musica;
	public Text texto_sonido;
	public Text texto_regresar;


	public Text texto_tituloCreditos;
	public Text texto_arte;

	public Text texto_programacion;
	public Text texto_regresarDeCreditos;



	// Use this for initialization
	void Start () {
		actualizarIdioma();
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



	public void actualizarIdioma(){
		if(PlayerPrefs.GetString("IDIOMA")=="ESPANIOL"){

			texto_presionaStart.text="PRESIONA ENTER";

			texto_nuevoJuego.text="Juego Nuevo";
			texto_nuevoJuegoBrillo.text="Juego Nuevo";

			texto_continuar.text="Continuar";
			texto_continuarBrillo.text="Continuar";

			texto_opciones.text="Opciones";
			texto_opcionesBrillo.text="Opciones";

			texto_creditos.text="Créditos";
			texto_creditosBrillo.text="Créditos";

			texto_salir.text="Salir";
			texto_salirBrillo.text="Salir";

			texto_tituloOpciones.text="OPCIONES";

			texto_idioma.text="Idioma";
			texto_seleccionIdioma.text="ESPAÑOL";

			texto_musica.text="Música";
			texto_sonido.text="Sonido";
			texto_regresar.text="REGRESAR";


			texto_tituloCreditos.text="Creditos";
			texto_arte.text="Arte Visual";

			texto_programacion.text="Programación";
			texto_regresarDeCreditos.text="REGRESAR";


			
		}	
		else if(PlayerPrefs.GetString("IDIOMA")=="ENGLISH"){


			texto_presionaStart.text="PRESS ENTER";

			texto_nuevoJuego.text="New Game";
			texto_nuevoJuegoBrillo.text="New Game";

			texto_continuar.text="Continue";
			texto_continuarBrillo.text="Continue";

			texto_opciones.text="Options";
			texto_opcionesBrillo.text="Options";

			texto_creditos.text="Credits";
			texto_creditosBrillo.text="Credits";

			texto_salir.text="Exit";
			texto_salirBrillo.text="Exit";

			texto_tituloOpciones.text="OPTIONS";

			texto_idioma.text="Language";
			texto_seleccionIdioma.text="ENGLISH";

			texto_musica.text="Music";
			texto_sonido.text="Sound";
			texto_regresar.text="RETURN";


			texto_tituloCreditos.text="CREDITS";
			texto_arte.text="Visual Art";

			texto_programacion.text="Programming";
			texto_regresarDeCreditos.text="RETURN";



		}
	
		
	}



}
