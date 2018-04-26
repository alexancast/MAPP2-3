using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {


	private AudioSource audioSource;
	public AudioClip clickSound;

	public float timer = 0.2f;
	private bool timerActive = false;
	private bool startGame;
	private bool loadCredits;
	private bool loadMenu;

	void Start(){

		audioSource = GetComponent<AudioSource> ();

	}


	void Update(){
	
		if (timerActive) {

			timer -= Time.deltaTime;
			
		}


		if (timer <= 0 && startGame) {

			SceneManager.LoadScene ("Main", LoadSceneMode.Single);
		} else if (timer <= 0 && loadCredits) {

			SceneManager.LoadScene("Credits", LoadSceneMode.Single);
		
		}else if(timer <= 0 && loadMenu){

			SceneManager.LoadScene("Menu", LoadSceneMode.Single);

		}
	
	}


    public void StartGame()
    {
		timerActive = true;
		audioSource.PlayOneShot (clickSound, 1f);
		startGame = true;
       
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadCredits()
    {
		timerActive = true;
		audioSource.PlayOneShot (clickSound, 1f);
		loadCredits = true;
        
    }

    public void LoadMenu()
    {
		timerActive = true;
		audioSource.PlayOneShot (clickSound, 1f);
		loadMenu = true;
        
    }






}
