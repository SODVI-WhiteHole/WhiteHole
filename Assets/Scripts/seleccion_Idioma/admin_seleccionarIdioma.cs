using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class admin_seleccionarIdioma : MonoBehaviour {

	/*Programado por José
	 Este código es el administrador de la escena seleccionar_Idioma.
	 Detecta cuando se elige una de las dos opciones y cambia los player prefs segun la opción deseada.
 	 En cuanto se selecciona un idioma activa la cortinilla para ir a la siguiente escena, Historia_introducción.
 	 */

	public GameObject cortinilla;
	public GameObject luzEnglish;
	public GameObject LuzEspaniol;

	public GameObject opcionEnglish;
	public GameObject opcionEspaniol;

	public Text titulo;

	public Text English;
	public Text Espaniol;

	public AudioSource SFX_Seleccionar;
	public AudioSource SFX_Aceptar;

	string idiomaActual="English";

	bool activo=true;





	// Update is called once per frame
	void Update () {

		capturarTeclas();
		if(!activo){
			efectoDeAgrandar();
		}		
	}


	void capturarTeclas(){
		if(Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)){
			seleccionarIngles();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow)){
			seleccionarEspaniol();
		}

		if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Return)){
			aceptarIdioma();
		}
	}






	public void seleccionarIngles(){
		if(activo){
			SFX_Seleccionar.Play();
			luzEnglish.SetActive(true);
			LuzEspaniol.SetActive(false);
			Espaniol.fontSize=220;
			idiomaActual="ENGLISH";
			titulo.text="LANGUAGE";
		}
	}
		
	public void seleccionarEspaniol(){
		if(activo){
			SFX_Seleccionar.Play();
			LuzEspaniol.SetActive(true);
			luzEnglish.SetActive(false);
			English.fontSize=220;
			idiomaActual="ESPANIOL";
			titulo.text="IDIOMA";
		}
	}
		
	public void aceptarIdioma(){
		if(activo){
			activo=false;
			SFX_Aceptar.Play();


			if(idiomaActual=="ENGLISH"){
				luzEnglish.GetComponent<resplandecer>().afectarTexto=false;
				English.fontSize=300;
			}
			if(idiomaActual=="ESPANIOL"){
				LuzEspaniol.GetComponent<resplandecer>().afectarTexto=false;
				Espaniol.fontSize=300;
			}

			PlayerPrefs.SetString("IDIOMA",idiomaActual);

			PlayerPrefs.SetFloat("VOLUMEN_MUSICA",1.0f);
			PlayerPrefs.SetFloat("VOLUMEN_SFX",1.0f);

			print("El idioma actual es: "+PlayerPrefs.GetString("IDIOMA"));

			cortinilla.SetActive(true);
			cortinilla.GetComponent<cortinilla>().alfa=0.0f;
		}
	}




	float nuevoAlfa=1.0f;

	void efectoDeAgrandar(){
		nuevoAlfa-=0.8f*Time.deltaTime;

		if(idiomaActual=="ENGLISH"){
			

			opcionEnglish.gameObject.GetComponent<RectTransform>().localScale+=new Vector3(0.5f,0.5f,0.0f)*Time.deltaTime;

			if(opcionEnglish.GetComponent<RectTransform>().localPosition.x<0){
				opcionEnglish.gameObject.GetComponent<RectTransform>().localPosition+=new Vector3(200.0f,0.0f,0.0f)*Time.deltaTime;
			}



			titulo.color=new Vector4(titulo.color.r,titulo.color.g,titulo.color.b,nuevoAlfa);
			Espaniol.color=new Vector4(Espaniol.color.r,Espaniol.color.g,Espaniol.color.b,nuevoAlfa);
		
		}
		else if (idiomaActual=="ESPANIOL"){
			opcionEspaniol.gameObject.GetComponent<RectTransform>().localScale+=new Vector3(0.5f,0.5f,0.0f)*Time.deltaTime;

			if(opcionEspaniol.GetComponent<RectTransform>().localPosition.x>0){
				opcionEspaniol.gameObject.GetComponent<RectTransform>().localPosition-=new Vector3(200.0f,0.0f,0.0f)*Time.deltaTime;
			}



			titulo.color=new Vector4(titulo.color.r,titulo.color.g,titulo.color.b,nuevoAlfa);
			English.color=new Vector4(Espaniol.color.r,Espaniol.color.g,Espaniol.color.b,nuevoAlfa);
		}

	}

}
