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
    void Start()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
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
