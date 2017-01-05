using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu_Opciones : MonoBehaviour {

	//Programado por José
	/*Este código realiza las acciones necesarias para el menu de opciones
	  Cambia el idioma general y avisa al administrador de la escena.
	  Cambia el sonido y actualiza al objeto Audio.
	  Cambia la música y actualiza al objeto Audio.
	  Regresa al carrusel del menú principal.
	*/

	public int estado=1;

	public admin_menuPrincipal codigoAdministrador;
	public audio_MenuPrincipal codigoAudio;

	public Animator animadorMenu;
	public AudioSource SFX_navegacion;
	public AudioSource SFX_OK;
	public AudioSource SFX_Tap;

	public GameObject idioma;
	public GameObject musica;	
	public GameObject sonido;
	public GameObject seleccion;
	public GameObject corchetes;
	public GameObject regresar;


	public Image fondoBarraMusica;
	public Image rellenoBarraMusica;

	public Image fondoBarraSonido;
	public Image rellenoBarraSonido;


	public Sprite fondoBarraBlanco;
	public Sprite rellenoBarraBlanco;

	public Sprite fondoBarraVerde;
	public Sprite rellenoBarraVerde;

	public string idiomaActual;


	public GameObject barraMusica;
	public GameObject barraSonido;


	[Range(0.0f,1.0f)]
	public float valorMusica=1;

	[Range(0.0f,1.0f)]
	public float valorSonido=1;



	// Use this for initialization
	void Start () {
		colocarEstado();
		inicializarOpciones();
	}
		


	// Update is called once per frame
	void Update () {
		capturarTeclas();

	}



	void capturarTeclas(){

		if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)){
			SFX_navegacion.Play();
			estado--;
			if (estado<=0){
				estado=4;
			}
			colocarEstado();
		}

		if(Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow)){
			SFX_navegacion.Play();
			estado++;
			if (estado>=5){
				estado=1;
			}
			colocarEstado();
		}







		if(estado==1){
			if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.Return)){
				SFX_Tap.Play();
				if(idiomaActual=="ESPANIOL"){
					idiomaActual="ENGLISH";
					PlayerPrefs.SetString("IDIOMA","ENGLISH");
					codigoAdministrador.actualizarIdioma();

				}else if(idiomaActual=="ENGLISH"){
					idiomaActual="ESPANIOL";
					PlayerPrefs.SetString("IDIOMA","ESPANIOL");
					codigoAdministrador.actualizarIdioma();
				}else 
					print("Algo salio terriblemente mal. El idioma actual es: "+PlayerPrefs.GetString("IDIOMA"));
			}
		}

		else{
			if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)){
				switch(estado){
				case 2:
					if(valorMusica>0){
						valorMusica-=0.5f*Time.deltaTime;
						if(valorMusica<=0)
							valorMusica=0.0f;
						barraMusica.GetComponent<RectTransform>().localScale=new Vector3(valorMusica,1.0f,1.0f);
						PlayerPrefs.SetFloat("VOLUMEN_MUSICA",valorMusica);
						codigoAudio.ajustarVolumenMusica();
					}

					break;

				case 3:
					if(valorSonido>0){
						valorSonido-=0.5f*Time.deltaTime;
						if(valorSonido<=0)
							valorSonido=0.0f;
						barraSonido.GetComponent<RectTransform>().localScale=new Vector3(valorSonido,1.0f,1.0f);
						PlayerPrefs.SetFloat("VOLUMEN_SFX",valorSonido);
						codigoAudio.ajustarVolumenSonido();
						SFX_Tap.Play();
					}
					break;

				default:
					break;
				}	
			}


			if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)){
				switch(estado){
				case 2:
					if(valorMusica<1){
						valorMusica+=0.5f*Time.deltaTime;
						if(valorMusica>=1)
							valorMusica=1.0f;
						barraMusica.GetComponent<RectTransform>().localScale=new Vector3(valorMusica,1.0f,1.0f);
						PlayerPrefs.SetFloat("VOLUMEN_MUSICA",valorMusica);
						codigoAudio.ajustarVolumenMusica();
					}

					break;

				case 3:
					if(valorSonido<1){
						valorSonido+=0.5f*Time.deltaTime;
						if(valorSonido>=1)
							valorSonido=1.0f;
						barraSonido.GetComponent<RectTransform>().localScale=new Vector3(valorSonido,1.0f,1.0f);
						PlayerPrefs.SetFloat("VOLUMEN_SFX",valorSonido);
						codigoAudio.ajustarVolumenSonido();
						SFX_Tap.Play();
					}
					break;

				default:
					break;
				}	
			}
		}
			






		if(Input.GetKeyDown(KeyCode.Return)){
			if(estado==4){
				animadorMenu.SetTrigger("quitarOpciones");
				SFX_OK.Play();
			}		
		}


	}



	public void colocarEstado(){

		switch(estado){

		case 1:
			estado_Idioma();
			break;

		case 2:
			estado_Musica();
			break;

		case 3:
			estado_Sonido();
			break;


		case 4:
			estado_Regresar();
			break;

		default:
			print("Algo salio terriblemente mal. Estado = "+estado);
			break;
		}

	}



	void estado_Idioma(){
		idioma.GetComponent<Outline>().enabled=true;
		corchetes.GetComponent<Outline>().enabled=true;
		seleccion.GetComponent<Outline>().enabled=true;

		regresar.GetComponent<Outline>().enabled=false;
		musica.GetComponent<Outline>().enabled=false;

		fondoBarraMusica.sprite=fondoBarraVerde;
		rellenoBarraMusica.sprite=rellenoBarraVerde;

	}

	void estado_Musica(){
		musica.GetComponent<Outline>().enabled=true;

		idioma.GetComponent<Outline>().enabled=false;
		corchetes.GetComponent<Outline>().enabled=false;
		seleccion.GetComponent<Outline>().enabled=false;
		sonido.GetComponent<Outline>().enabled=false;


		fondoBarraMusica.sprite=fondoBarraBlanco;
		rellenoBarraMusica.sprite=rellenoBarraBlanco;


		fondoBarraSonido.sprite=fondoBarraVerde;
		rellenoBarraSonido.sprite=rellenoBarraVerde;



	}

	void estado_Sonido(){

		sonido.GetComponent<Outline>().enabled=true;

		musica.GetComponent<Outline>().enabled=false;
		regresar.GetComponent<Outline>().enabled=false;


		fondoBarraSonido.sprite=fondoBarraBlanco;
		rellenoBarraSonido.sprite=rellenoBarraBlanco;


		fondoBarraMusica.sprite=fondoBarraVerde;
		rellenoBarraMusica.sprite=rellenoBarraVerde;

	}

	void estado_Regresar(){

		regresar.GetComponent<Outline>().enabled=true;

		idioma.GetComponent<Outline>().enabled=false;
		corchetes.GetComponent<Outline>().enabled=false;
		seleccion.GetComponent<Outline>().enabled=false;
		sonido.GetComponent<Outline>().enabled=false;

		fondoBarraSonido.sprite=fondoBarraVerde;
		rellenoBarraSonido.sprite=rellenoBarraVerde;

	}




	void inicializarOpciones(){
		idiomaActual=PlayerPrefs.GetString("IDIOMA");

		valorMusica=PlayerPrefs.GetFloat("VOLUMEN_MUSICA");
		valorSonido=PlayerPrefs.GetFloat("VOLUMEN_SFX");

		barraMusica.GetComponent<RectTransform>().localScale=new Vector3(valorMusica,1.0f,1.0f);
		codigoAudio.ajustarVolumenMusica();

		barraSonido.GetComponent<RectTransform>().localScale=new Vector3(valorSonido,1.0f,1.0f);
		codigoAudio.ajustarVolumenSonido();
	}



}


