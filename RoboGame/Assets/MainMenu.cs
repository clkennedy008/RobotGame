using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainMenu singleton;

    public bool MainMenuOpen = false;
    public GameObject pauseMenu;

    public bool pressed = false;
    void Start()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed && Input.GetAxis("CStart") == 0){
            pressed = false;
        }
        if(Input.GetKeyDown(KeyCode.Escape) || (Input.GetAxis("CStart") > 0 && !pressed)){
            pressed = true;
            if(!MainMenuOpen){
                MainMenuOpen = true;
                pauseMenu.SetActive(true);
            }else{
                MainMenuOpen = false;
                pauseMenu.SetActive(false);
            }
            
        }
    }

    public void ToMainMenu(){
        SceneManager.LoadScene("TitleScreen");
    }
}
