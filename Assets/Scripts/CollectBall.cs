using UnityEngine;

public class CollectBall : MonoBehaviour
{
    public int ballIndex;
    private PlayerControl playerControl;
    private Transform formerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.FindObjectOfType<PlayerControl>();
        formerTransform = playerControl.balls[ballIndex - 1].transform;

        //taoplanan toplarý farklý bir nesbeye atýyoruz çünkü toplar platform  nesnesinin child i platformu sildiðimizde toplar da siliniyor
        transform.SetParent(GameObject.FindWithTag("BallsStock").transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(formerTransform.position.x,
                                                                            formerTransform.position.y,
                                                                         formerTransform.position.z - 1f), 0.1f);
    }
}