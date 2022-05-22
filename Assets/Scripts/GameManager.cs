using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    internal GameStates currentState;

    private void Update()
    {
        currentState = ChangeStates.Current;
        switch (currentState)
        {
            case GameStates.Menu:
                break;
            case GameStates.Play:
                Time.timeScale = 1;
                break;
            case GameStates.Stop:
                Time.timeScale = 0;
                break;
            case GameStates.Win:
                break;
            case GameStates.Lose:
                Time.timeScale = 0;
                break;
        }
    }

    public void EndGame(int levelLength)
    {
        PlayerPrefs.SetInt("levelReached", levelLength + 1);
    }
}
