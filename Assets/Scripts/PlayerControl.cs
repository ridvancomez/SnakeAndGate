using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    private EndlessGameManager endlessManager;

    public List<GameObject> balls;

    [SerializeField]
    private TextMeshPro ballCount;

    [SerializeField]
    private GameObject stackBall;

    private GameManager managerScript;

    private float horizontal;
    private float horizontalSpeed;
    private float limitX;

    private float moveSpeed;
    private int gateNumber;

    [SerializeField]
    TextMeshProUGUI gameOverText;



    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false;
        endlessManager = GameObject.FindObjectOfType<EndlessGameManager>();
        managerScript = GameObject.FindObjectOfType<GameManager>();

        moveSpeed = 5;
        horizontalSpeed = 5;
        limitX = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float xPos;
        if (Input.GetMouseButton(0))
        {
            horizontal = Input.GetAxisRaw("Mouse X");
        }
        else
        {
            horizontal = 0;
        }

        xPos = transform.position.x + horizontalSpeed * horizontal * Time.deltaTime;

        xPos = Mathf.Clamp(xPos, -limitX, limitX);

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void BallStackForRequired(GameObject other)
    {
        other.GetComponent<Renderer>().material.color = Color.white;
        other.transform.position = new Vector3(transform.position.x,
                                                transform.position.y,
                                                balls[balls.Count - 1].transform.position.z - 1);

        other.GetComponent<SphereCollider>().isTrigger = false;
        balls.Add(other.gameObject);
        other.GetComponent<CollectBall>().enabled = true;
        other.GetComponent<CollectBall>().ballIndex = balls.Count - 1;
    }


    private void GateForRequired(GameObject other)
    {
        gateNumber = other.GetComponent<GateController>().GetGateNumber();

        if (gateNumber > 0)
        {
            for (int i = 0; i < gateNumber; i++)
            {
                GameObject newStackBall = Instantiate(stackBall);

                BallStackForRequired(newStackBall);
            }
        }
        else if (gateNumber < 0)
        {
            for (int i = 0; i < gateNumber * -1; i++)
            {
                if (balls.Count != 1)
                {
                    Destroy(balls[balls.Count - 1]);
                    balls.RemoveAt(balls.Count - 1);
                }
                else
                {
                    ChangeStates.ChangeState(GameStates.Lose);
                    gameOverText.enabled = true;
                }
            }
        }
    }

    private void FinishLineForRequired()
    {
        if (PlayerPrefs.GetInt("levelReached") == 0 || PlayerPrefs.GetInt("levelReached") == SceneManager.GetActiveScene().buildIndex)
        {
            managerScript.EndGame(SceneManager.GetActiveScene().buildIndex);
        }

        ChangeStates.ChangeState(GameStates.Win);
        StartCoroutine(TransitionToMenu());
    }

    private IEnumerator TransitionToMenu()
    {
        yield return new WaitForSeconds(1);
        ChangeStates.ChangeState(GameStates.Menu);
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "StackBall":
                BallStackForRequired(other.gameObject);
                break;

            case "Gate":
                GateForRequired(other.gameObject);
                break;

            case "FinishLine":
                FinishLineForRequired();
                break;

            case "GenerateGround":
                endlessManager.GenerateEndlessPrefab();
                break;
        }

        if (ScoreManager.ScoreManagement.Score < balls.Count)
        {
            ScoreManager.ScoreManagement.Score = balls.Count;
        }
        ballCount.text = balls.Count.ToString();
        ScoreManager.ScoreManagement.SaveScore();
    }
}
