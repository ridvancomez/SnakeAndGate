using UnityEngine;

public enum GameStates
{
    Menu,
    Play,
    Stop,
    Win,
    Lose
}

public class ChangeStates : MonoBehaviour
{
    public static GameStates Current;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void ChangeState(GameStates newState)
    {
        Current = newState;
    }
}