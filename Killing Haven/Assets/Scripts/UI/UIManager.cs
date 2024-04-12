using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, GameReset
{
    public static GameState gameState = GameState.Play;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject playScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        playScreen.SetActive(true);
        LockMouse(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameState.Play)
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                gameState = GameState.Pause;
                Reset();
                pauseScreen.SetActive(true);
                LockMouse(false);
            }
        }
        else if(gameState == GameState.Pause)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                gameState = GameState.Play;
                Reset();
                playScreen.SetActive(true);
                LockMouse(true);
            }
        }
        else if(gameState == GameState.Victory)
        {
            if (!winScreen.activeSelf)
            {
                Reset();
                winScreen.SetActive(true);
                LockMouse(false);
            }
        }
        else if(gameState == GameState.GameOver)
        {
            if (!gameOverScreen.activeSelf)
            {
                Reset();
                gameOverScreen.SetActive(true);
                LockMouse(false);
            }
        }
    }

    private void Reset()
    {
        pauseScreen.SetActive(false);
        playScreen.SetActive(false);
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    private void LockMouse(bool locked)
    {
        Cursor.visible = !locked;
        if(locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ResetGame()
    {
        gameState = GameState.Play;
        Reset();
        playScreen.SetActive(true);
        LockMouse(true);
    }
}

public enum GameState
{
    Play,
    Pause,
    Victory,
    GameOver
}