using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameManager manager;

    [SerializeField]
    private Transform playerTransform;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (manager.currentState != GameStates.Win)
            transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset, Time.deltaTime);
    }
}