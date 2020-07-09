using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameState singleton;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI restartText;
    public bool GameOver = false;

    public bool Victory = false;

    void Start()
    {
        Restart();
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver && (Input.GetKey(KeyCode.R) || Input.GetAxis("CSubmit") > 0 || (Application.isMobilePlatform && Input.GetMouseButton(0)))){
            Restart();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }else if(Victory && (Input.GetKey(KeyCode.R) || Input.GetAxis("CSubmit") > 0 || (Application.isMobilePlatform && Input.GetMouseButton(0)))){
            SceneManager.LoadScene("TitleScreen");
        }
    }

    public void setGameOver(){
        GameOver = true;
        GameOverText.gameObject.SetActive(true);
        GameOverText.text = "Game Over";
        restartText.gameObject.SetActive(true);
        restartText.text = "Press \"R\" to return to restart"; 
    }

    public void setVictory(){
        Victory = true;
        GameOverText.gameObject.SetActive(true);
        GameOverText.text = "Congradulations!!";
        restartText.gameObject.SetActive(true);
        restartText.text = "Press \"R\" to return to the menu";
    }

    public void Restart(){
        GroundChunk.Chuncks.Clear();
        Flicker.lanterns.Clear();
        ShopOpen.inBossRoom = false;
        ShopOpen.shopOpen = false;
        GameObject loaders = Camera.main.gameObject.transform.parent.gameObject;
        for(int i = 0; i < loaders.transform.childCount; i ++){
            loaders.transform.GetChild(i).gameObject.SetActive(true);
        }
        Flicker.Level = 1;
        LaserGun.LaserSpeedlvl = 1;
        LaserGun.rechargelvl = 1;
        Sword.damageLevel = 1;
        
    }
}
