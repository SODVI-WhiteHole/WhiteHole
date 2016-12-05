using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class resplandecer : MonoBehaviour {

	/*Programado por José
	 Este código hace resplandecer una imagen, realiza este truco modificando su  estado alfa con respecto al tiempo.
	 Este en especifico lo hice para resaltar cuando una opción es seleccionada en la pantalla de selección de idioma.
	 Planeo utilizarlo para resaltar las opciones en los demás menus.
	 También afecta el tamaño del texto si se desea.
	*/


	Image cuerpoImagen;

	float valorAlfa=1.0f;
	bool ascender=false;

	public float velocidad=1.0f;
	public float margen=0.5f;



	public bool afectarTexto=false;
	public Text cuerpoTexto;
	public float velocidadTexto=1.0f;
	public float tamañoMaximoTexto=300.0f; 




	void Start () {
		cuerpoImagen=this.gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

		if(afectarTexto)
			resplandeciendoConTexto();
		else
			resplandeciendo();
	}



	//Esta funcion se ejecuta cuando solo se quiere hacer resplandecer el texto.
	void resplandeciendo(){

		//Esta parte sirve para modificar el valorAlfa con respecto al tiempo, según una velocidad y margen dados.
		if(ascender){
			valorAlfa+=velocidad*Time.deltaTime;

			if(valorAlfa>1.05f)
				ascender=false;	
		} else {
			valorAlfa-=velocidad*Time.deltaTime;
			if(valorAlfa<margen)
				ascender=true;	
		}
			
		//Aplica el valorAlfa al alfa de nuestra imagen, logrando así el efecto deseado.
		cuerpoImagen.color=new Vector4(cuerpoImagen.color.r,cuerpoImagen.color.g,cuerpoImagen.color.b,valorAlfa);	

	}








	//Esta funcion se ejecuta si se quiere hacer resplandecer el texto y al mismo tiempo modificar su tamaño.
	void resplandeciendoConTexto(){

		//Esta parte sirve para modificar el valorAlfa de la luz y el tamaño de la fuente con respecto al tiempo, según las velocidades y el margen dados.
		if(ascender){
			valorAlfa+=velocidad*Time.deltaTime;
			tamañoMaximoTexto+=velocidadTexto*Time.deltaTime;
			cuerpoTexto.fontSize= (int) tamañoMaximoTexto;

			if(valorAlfa>1.05f)
				ascender=false;	
		} else {
			valorAlfa-=velocidad*Time.deltaTime;
			tamañoMaximoTexto-=velocidadTexto*Time.deltaTime;
			cuerpoTexto.fontSize= (int) tamañoMaximoTexto;

			if(valorAlfa<margen)
				ascender=true;	
		}

		//Aplica el valorAlfa al alfa de nuestra imagen, logrando así el efecto deseado.
		cuerpoImagen.color=new Vector4(cuerpoImagen.color.r,cuerpoImagen.color.g,cuerpoImagen.color.b,valorAlfa);	

	}





}