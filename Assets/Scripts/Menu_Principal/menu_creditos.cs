using UnityEngine;
using System.Collections;

public class menu_creditos : MonoBehaviour {

	public Animator animadorMenu;
	public AudioSource SFX_OK;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			SFX_OK.Play();
			animadorMenu.SetTrigger("quitarCreditos");
		}
	}
}
