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

    void Start()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver && Input.GetKey(KeyCode.R)){
            GroundChunk.Chuncks.Clear();
            Flicker.lanterns.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }else if(Input.GetKey(KeyCode.R)){
           // GroundChunk.Chuncks.Clear();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void setGameOver(){
        GameOver = true;
        GameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
    }
}
