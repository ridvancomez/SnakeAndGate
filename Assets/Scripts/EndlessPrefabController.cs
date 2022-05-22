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
            objectZPos = transform.position.z + 100; //kap� ve toplar�n z pozisyonu
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
            int whichPiece = Random.Range(1, 11); // kap� ve toplar tamamiyle rastgele koyluluyor
            if (whichPiece < 6) // top i�in
            {
                float ballXPos = Random.Range(-2, 3);

                // yolun child � yap�yoruz ��nk� yolu sildikten sonra di�er nesneler de silinsin
                GameObject generateBall = Instantiate(stackBall, transform);
                generateBall.transform.position = new Vector3(ballXPos, -0.7f, objectZPos);
            }
            else // kap� i�in
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
        yield return new WaitForSeconds(22); // waitForSecond(20) de yok oldu�u g�r�l�yor
        Destroy(gameObject);
    }
}
