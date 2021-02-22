using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Animator EndGameScreen;

    public static EndGame Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void ShowEndGameScreen()
    {
        EndGameScreen.gameObject.SetActive(true);
        EndGameScreen.Play("EndScreen_in");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
