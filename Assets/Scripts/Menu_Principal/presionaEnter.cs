using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class presionaEnter : MonoBehaviour {

	/*Programado por José
	Este código es para el botón de Presionar Enter ubicado al principio del menú principal.
	Detecta si la tecla Enter o sus equivalentes han sido presionadas para iniciar el juego.
	También realiza el efecto estetico de cambiar de tamaño y transparencia.
	*/


	Text cuerpoTexto;
	//RectTransform cuerpoPosicion;


	public bool afectarAlfa=false;




	float valorAlfa=0.0f;
	bool ascender=true;

	public float velocidad=1.0f;
	public float margen=0.5f;



	public AudioSource SFX_OK;
	public admin_menuPrincipal codigoAdmin;


	void Start () {
		cuerpoTexto=this.gameObject.GetComponent<Text>();
		//cuerpoPosicion=this.gameObject.GetComponent<RectTransform>();
	}


	// Update is called once per frame
	void Update () {

		if(afectarAlfa){
			cambiarAlfa();

			if(Input.GetKeyDown(KeyCode.Return)){
				afectarAlfa=false;
				codigoAdmin.fase="Entrando a Menu";
				SFX_OK.Play();
				cuerpoTexto.color=new Vector4(cuerpoTexto.color.r,cuerpoTexto.color.g,cuerpoTexto.color.b,1.0f);
			}

		}
	}



	//Esta funcion se ejecuta cuando se quiere hacer resplandecer el texto.
	void cambiarAlfa(){

		//Esta parte sirve para modificar el valorAlfa con respecto al tiempo, según una velocidad y margen dados.
		if(ascender){
			valorAlfa+=velocidad*Time.deltaTime;

			if(valorAlfa>1.1f)
				ascender=false;	
		
		} else {
			valorAlfa-=velocidad*Time.deltaTime;

			if(valorAlfa<margen)
				ascender=true;	
		}
			
		//Aplica el valorAlfa al alfa de nuestra imagen, logrando así el efecto deseado.
		cuerpoTexto.color=new Vector4(cuerpoTexto.color.r,cuerpoTexto.color.g,cuerpoTexto.color.b,valorAlfa);	

	}



}
