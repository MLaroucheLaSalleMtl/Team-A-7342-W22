using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject ButtonRestart;
    public GameObject ButtonExit;
    public GameObject Text;

    private PlayerHPManager Player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindObjectOfType<PlayerHPManager>();
        ButtonRestart.SetActive(false);
        ButtonExit.SetActive(false);
        Text.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOverText()
    {
        ButtonRestart.SetActive(true);
        ButtonExit.SetActive(true);
        Text.SetActive(true);
    }

    public void Death()
    {
        Player.gameObject.SetActive(false);
        GameOverText();
    }
}
