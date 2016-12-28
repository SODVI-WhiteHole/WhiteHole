using UnityEngine;
using System.Collections;

public class menu_Opciones : MonoBehaviour {


	public Animator animadorMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		capturarTeclas();

	}


	void capturarTeclas(){
		if(Input.GetKeyDown(KeyCode.Return)){
			animadorMenu.SetTrigger("quitarOpciones");
		}
	}
}
