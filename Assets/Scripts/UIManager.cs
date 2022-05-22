using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/savefile.json"))
        {
            ScoreManager.ScoreManagement.SaveScore();
        }
        ScoreManager.ScoreManagement.LoadScore();

        highScoreText.text = "En yüksek skor: " + ScoreManager.ScoreManagement.Score.ToString();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    public void SwitchGame(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 1:
                ChangeStates.ChangeState(GameStates.Play);
                SceneManager.LoadScene(1, LoadSceneMode.Single);
                break;
            case 2:
                ChangeStates.ChangeState(GameStates.Play);
                SceneManager.LoadScene(2, LoadSceneMode.Single);
                break;
            case 3:
                ChangeStates.ChangeState(GameStates.Play);
                SceneManager.LoadScene(3, LoadSceneMode.Single);
                break;
            case 4:
                ChangeStates.ChangeState(GameStates.Play);
                SceneManager.LoadScene(4, LoadSceneMode.Single);
                break;
            case 5:
                ChangeStates.ChangeState(GameStates.Play);
                SceneManager.LoadScene(5, LoadSceneMode.Single);
                break;
            case 6:
                ChangeStates.ChangeState(GameStates.Play);
                SceneManager.LoadScene(6, LoadSceneMode.Single);
                break;
            case 7:
                ChangeStates.ChangeState(GameStates.Play);
                SceneManager.LoadScene(7, LoadSceneMode.Single);
                break;
        }

    }

    public void LeaveGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}

