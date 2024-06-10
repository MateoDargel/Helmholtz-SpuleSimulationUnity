using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rechnung : MonoBehaviour
{
    // Werte der Spule
    public float spuleRadius = 0.2f;
    public float wicklung = 154f;
    public float stromstaerke = 4.6f;

    private float spuleAbstand;
    private float spuleDicke;

    // Konstante für das Magnetfeld einer Spule
    private const float mu0 = 4 * Mathf.PI * 1e-7f;

    private float homBFeld(float pSpuleRadius, float pWicklung, float pStromstaerke)
    {
        float bFeld = mu0 * Mathf.Pow(0.8f, 1.5f) * (pWicklung / pSpuleRadius) * pStromstaerke;
        return bFeld;
    }
}
