using System.Collections;
using UnityEngine;

public class EndlessPrefabController : MonoBehaviour
{
    private float objectZPos;

    [SerializeField]
    private GameObject stackBall;

    [SerializeField]
    private GameObject[] gates;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.z > 0)
        {
            objectZPos = transform.position.z + 100; //kapý ve toplarýn z pozisyonu
            StartCoroutine(PutPiece());
        }
    }

    internal void DeathPrefab()
    {
        StartCoroutine(DeathTime());
    }

    IEnumerator PutPiece()
    {
        while (objectZPos < transform.position.z + 200) //burada ground un sonuna geldik mi diye kontrol ediyoruz
        {
            yield return null;
            int whichPiece = Random.Range(1, 11); // kapý ve toplar tamamiyle rastgele koyluluyor
            if (whichPiece < 6) // top için
            {
                float ballXPos = Random.Range(-2, 3);

                // yolun child ý yapýyoruz çünkü yolu sildikten sonra diðer nesneler de silinsin
                GameObject generateBall = Instantiate(stackBall, transform);
                generateBall.transform.position = new Vector3(ballXPos, -0.7f, objectZPos);
            }
            else // kapý için
            {
                int gateIndex = Random.Range(0, gates.Length);

                GameObject generateBall = Instantiate(gates[gateIndex], transform);
                generateBall.transform.position = new Vector3(0, 1.55f, objectZPos);
            }
            objectZPos += 5;

        }
    }

    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(22); // waitForSecond(20) de yok olduðu görülüyor
        Destroy(gameObject);
    }
}
