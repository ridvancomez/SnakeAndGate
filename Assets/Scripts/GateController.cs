using UnityEngine;
using TMPro;

public class GateController : MonoBehaviour
{
    enum GateType
    {
        PositiveGate,
        NegativeGate
    }

    [SerializeField]
    private TextMeshPro gateNumberText;

    [SerializeField]
    GateType gateType;

    private int gateNumber;

    // Start is called before the first frame update
    void Start()
    {
        switch (gateType)
        {
            case GateType.PositiveGate:
                gateNumber = Random.Range(1, 10);
                break;
            case GateType.NegativeGate:
                gateNumber = Random.Range(-10, 0);
                break;
        }
        gateNumberText.text = gateNumber.ToString();
    }

    internal int GetGateNumber()
    {
        return gateNumber;
    }
}
