using UnityEngine;

public class IsDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.transform.parent.GetComponent<EndlessPrefabController>().DeathPrefab();
        }
    }
}
