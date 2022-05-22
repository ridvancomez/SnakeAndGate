using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonControl : MonoBehaviour
{
  private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void StopAndPlay()
    {
        if(gameManager.currentState == GameStates.Play)
        {
            ChangeStates.ChangeState(GameStates.Stop);
        }
        else if(gameManager.currentState == GameStates.Stop)
        {
            ChangeStates.ChangeState(GameStates.Play);

        }
    }

    public void RestartButton()
    {
        ChangeStates.ChangeState(GameStates.Play);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        ChangeStates.ChangeState(GameStates.Menu);
        SceneManager.LoadScene(0);
    }
}
