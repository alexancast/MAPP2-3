using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject creditsPanel;

	private AudioSource audioSource;
	public AudioClip clickSound;

	public float timer = 0.2f;
	private bool timerActive = false;
	private bool startGame;

    private bool menuIsOpen;
    private bool settingsIsOpen;
    private bool creditsIsOpen;

    void Start(){

		audioSource = GetComponent<AudioSource> ();

        ClosePanels();
        OpenMenu();
	}


	void Update(){

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuIsOpen)
            {
                ExitGame();
            } else if (settingsIsOpen)
            {
                OpenMenu();
            } else if (creditsIsOpen)
            {
                OpenMenu();
            }
        }

		if (timerActive) {
			timer -= Time.deltaTime;
		}

		if (timer <= 0 && startGame) {
			SceneManager.LoadScene ("Main", LoadSceneMode.Single);
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

    public void OpenMenu()
    {
        ClosePanels();
        audioSource.PlayOneShot(clickSound, 1f);
        menuPanel.SetActive(true);
        menuIsOpen = true;
    }

    public void OpenCredits()
    {
        ClosePanels();
        audioSource.PlayOneShot(clickSound, 1f);
        creditsPanel.SetActive(true);
        creditsIsOpen = true;
    }

    private void ClosePanels()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(false);
        menuIsOpen = false;
        settingsIsOpen = false;
        creditsIsOpen = false;
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(clickSound, 1f);
    }





}
