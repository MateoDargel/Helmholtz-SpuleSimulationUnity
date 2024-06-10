using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pfeile : MonoBehaviour
{
    public GameObject arrowPrefab;
    private GameObject arrows;
    //public Slider modusSlider;
    public Gradient colorGradient;
    
    public int numArrows = 81;
    public float factor = 200.0f;
    public List<GameObject> arrowList = new List<GameObject>();

    bool extraArrows = false;
    int mode = 2;

    void Start()
    {
        SwitchMode();
    }

    public void SwitchMode()
    {
        if(mode == 1)
        {
            DeleteArrows();
            mode = 2;
            Mode2();
        }else if(mode == 2)
        {
            DeleteArrows();
            mode = 1;
            Mode1();
        }
    }

    void Mode1()
    {
        for(int i = 0; i < numArrows; i++)
        {
            Vector3 pos = new Vector3(xPos[i] * factor, zPos[i] * factor, -yPos[i] * factor);
            Vector3 value = new Vector3(xMagFlux[i] * factor, zMagFlux[i] * factor, -yMagFlux[i] * factor);
            Quaternion rot = Quaternion.LookRotation(value, Vector3.up);

            arrows = Instantiate(arrowPrefab, pos, rot);

            float len = Mathf.Sqrt(Mathf.Pow(xMagFlux[i] * factor, 2) + Mathf.Pow(yMagFlux[i] * factor, 2) + Mathf.Pow(zMagFlux[i] * factor, 2));
            arrows.transform.localScale = new Vector3(200f, 200f, len);

            arrowList.Add(arrows);

            if(extraArrows == true)
            {
                // Pfeil um vertikale Achse duplizieren
                if(arrows.transform.position.y != 0)
                {
                    Vector3 posHorizontal = new Vector3(xPos[i] * factor, -zPos[i] * factor, -yPos[i] * factor);
                    Vector3 valueHorizontal = new Vector3(xMagFlux[i] * factor, -zMagFlux[i] * factor, -yMagFlux[i] * factor);
                    Quaternion rotHorizontal = Quaternion.LookRotation(valueHorizontal, Vector3.up);

                    arrows = Instantiate(arrowPrefab, posHorizontal, rotHorizontal);
                    arrows.transform.localScale = new Vector3(200f, 200f, len);
                    arrowList.Add(arrows);
                }

                // Pfeil um horizontale Achse duplizieren
                if(arrows.transform.position.z != 0)
                {
                    Vector3 posVertical = new Vector3(xPos[i] * factor, zPos[i] * factor, yPos[i] * factor);
                    Vector3 valueVertical = new Vector3(xMagFlux[i] * factor, -zMagFlux[i] * factor, -yMagFlux[i] * factor);
                    Quaternion rotVertical = Quaternion.LookRotation(valueVertical, Vector3.up);

                    arrows = Instantiate(arrowPrefab, posVertical, rotVertical);
                    arrows.transform.localScale = new Vector3(200f, 200f, len);
                    arrowList.Add(arrows);
                }

                // Pfeil um Ursprung duplizieren
                if(arrows.transform.position.y != 0 && arrows.transform.position.z != 0)
                {
                    Vector3 posOriginb = new Vector3(xPos[i] * factor, -zPos[i] * factor, yPos[i] * factor);
                    Vector3 valueOriginb = new Vector3(xMagFlux[i] * factor, zMagFlux[i] * factor, -yMagFlux[i] * factor);
                    Quaternion rotOriginb = Quaternion.LookRotation(valueOriginb, Vector3.up);

                    arrows = Instantiate(arrowPrefab, posOriginb, rotOriginb);
                    arrows.transform.localScale = new Vector3(200f, 200f, len);
                    arrowList.Add(arrows);
                }
            }
        }
    }

    void Mode2()
    {
        for(int i = 0; i < numArrows; i++)
        {
            Vector3 pos = new Vector3(xPos[i] * factor, zPos[i] * factor, -yPos[i] * factor);
            Vector3 value = new Vector3(xMagFlux[i] * factor, zMagFlux[i] * factor, -yMagFlux[i] * factor);
            Quaternion rot = Quaternion.LookRotation(value, Vector3.up);

            arrows = Instantiate(arrowPrefab, pos, rot);

            float len = factor;
            arrows.transform.localScale = new Vector3(200f, 200f, len);

            float sumMagFlux = Mathf.Abs(xMagFlux[i]) + Mathf.Abs(yMagFlux[i]) + Mathf.Abs(zMagFlux[i]);
            Color arrowColor = colorGradient.Evaluate(Mathf.InverseLerp(0f, 2f, sumMagFlux));

            arrows.GetComponent<Renderer>().material.color = arrowColor;

            arrowList.Add(arrows);

            if(extraArrows == true)
            {
                // Pfeil um vertikale Achse duplizieren
                if(arrows.transform.position.y != 0)
                {
                    Vector3 posHorizontal = new Vector3(xPos[i] * factor, -zPos[i] * factor, -yPos[i] * factor);
                    Vector3 valueHorizontal = new Vector3(xMagFlux[i] * factor, -zMagFlux[i] * factor, -yMagFlux[i] * factor);
                    Quaternion rotHorizontal = Quaternion.LookRotation(valueHorizontal, Vector3.up);

                    arrows = Instantiate(arrowPrefab, posHorizontal, rotHorizontal);
                    arrows.transform.localScale = new Vector3(200f, 200f, len);
                    arrows.GetComponent<Renderer>().material.color = arrowColor;
                    arrowList.Add(arrows);
                }

                // Pfeil um horizontale Achse duplizieren
                if(arrows.transform.position.z != 0)
                {
                    Vector3 posVertical = new Vector3(xPos[i] * factor, zPos[i] * factor, yPos[i] * factor);
                    Vector3 valueVertical = new Vector3(xMagFlux[i] * factor, -zMagFlux[i] * factor, -yMagFlux[i] * factor);
                    Quaternion rotVertical = Quaternion.LookRotation(valueVertical, Vector3.up);

                    arrows = Instantiate(arrowPrefab, posVertical, rotVertical);
                    arrows.transform.localScale = new Vector3(200f, 200f, len);
                    arrows.GetComponent<Renderer>().material.color = arrowColor;
                    arrowList.Add(arrows);
                }

                // Pfeil um Ursprung duplizieren
                if(arrows.transform.position.y != 0 && arrows.transform.position.z != 0)
                {
                    Vector3 posOriginb = new Vector3(xPos[i] * factor, -zPos[i] * factor, yPos[i] * factor);
                    Vector3 valueOriginb = new Vector3(xMagFlux[i] * factor, zMagFlux[i] * factor, -yMagFlux[i] * factor);
                    Quaternion rotOriginb = Quaternion.LookRotation(valueOriginb, Vector3.up);

                    arrows = Instantiate(arrowPrefab, posOriginb, rotOriginb);
                    arrows.transform.localScale = new Vector3(200f, 200f, len);
                    arrows.GetComponent<Renderer>().material.color = arrowColor;
                    arrowList.Add(arrows);
                }
            }
        }
    }

    void DeleteArrows()
    {
        foreach(var arrow in arrowList)
        {
            Destroy(arrow);
        }

        arrowList.Clear();
    }

    public void ToggleExtraPfeile()
    {
        DeleteArrows();
        if(extraArrows == true)
        {
            extraArrows = false;
        }else if(extraArrows == false)
        {
            extraArrows = true;
        }
        if(mode == 1)
        {
            Mode1();
        }else if(mode == 2)
        {
            Mode2();
        }
    }

    //* Unity = Wert: X = 100X; Y = 100Z; Z = -100Y *//

    public float[] xPos = new float[]
    {
        0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
        0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
        0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
        0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
        0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
        0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
        0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
        0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
        0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
    };

    public float[] yPos = new float[]
    {
        0f, 0.05f, 0.125f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f,
        0f, 0.05f, 0.125f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f,
        0f, 0.05f, 0.125f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f,
        0f, 0.05f, 0.125f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f,
        0f, 0.05f, 0.125f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f,
        0f, 0.05f, 0.125f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f,
        0f, 0.05f, 0.125f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f,
        0f, 0.05f, 0.125f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f,
        0f, 0.05f, 0.125f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f,
    };


    public float[] zPos = new float[]
    {
        0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
        0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f,
        0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f,
        0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f,
        0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f,
        0.25f, 0.25f, 0.25f, 0.25f, 0.25f, 0.25f, 0.25f, 0.25f, 0.25f,
        0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f, 0.3f,
        0.35f, 0.35f, 0.35f, 0.35f, 0.35f, 0.35f, 0.35f, 0.35f, 0.35f,
        0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f,
    };

    public float[] xMagFlux = new float[]
    {
        0.026f, 0.035f, 0.049f, 0.015f, 0.028f, -0.011f, 0.015f, 0.007f, -0.003f,
        -0.013f, 0f, 0.022f, 0.02f, 0.01f, 0.006f, 0.01f, 0.01f, 0.004f,
        0.003f, -0.004f, 0.042f, 0.034f, 0.009f, 0.007f, 0.003f, 0f, 0f,
        0.01f, 0.009f, 0.028f, 0.03f, 0.009f, 0.003f, 0.006f, 0.007f, 0.001f,
        0.019f, 0.019f, -0.077f, 0.002f, 0.01f, 0.005f, 0.006f, 0.001f, 0f,
        -0.001f, -0.001f, -0.035f, -0.011f, -0.001f, -0.001f, 0f, 0.002f, 0f,
        -0.004f, -0.006f, -0.008f, -0.006f, -0.004f, -0.001f, 0f, -0.001f, -0.001f,
        -0.006f, -0.005f, -0.005f, -0.003f, -0.002f, -0.002f, -0.001f, 0f, 0f,
        -0.003f, -0.004f, -0.003f, -0.003f, -0.001f, 0.001f, 0.001f, 0f, 0.001f,
    };

    public float[] yMagFlux = new float[]
    {
        1.52f, 1.521f, 1.367f, 1.292f, 0.916f, 0.712f, 0.478f, 0.332f, 0.233f,
        1.572f, 1.589f, 1.406f, 1.299f, 0.979f, 0.697f, 0.473f, 0.332f, 0.231f,
        1.504f, 1.642f, 1.503f, 1.341f, 0.903f, 0.597f, 0.406f, 0.287f, 0.2f,
        1.195f, 1.563f, 1.867f, 1.439f, 0.772f, 0.481f, 0.33f, 0.239f, 0.174f,
        0.556f, 0.582f, 1.141f, 0.648f, 0.422f, 0.308f, 0.237f, 0.179f, 0.141f,
        -0.008f, -0.214f, -0.688f, -0.239f, 0.084f, 0.142f, 0.139f, 0.12f, 0.104f,
        -0.147f, -0.2f, -0.248f, -0.182f, -0.052f, 0.027f, 0.057f, 0.065f, 0.063f,
        -0.141f, -0.151f, -0.133f, -0.107f, -0.052f, -0.005f, 0.023f, 0.034f, 0.039f,
        -0.109f, -0.109f, -0.09f, -0.078f, -0.047f, -0.019f, 0.003f, 0.016f, 0.023f,
    };

    public float[] zMagFlux = new float[]
    {
        -0.295f, -0.212f, -0.128f, -0.02f, -0.015f, -0.002f, -0.005f, -0.006f, 0f,
        0.037f, 0.038f, 0.038f, 0.076f, 0.121f, 0.103f, 0.071f, 0.043f, 0.053f,
        0.032f, -0.052f, 0.454f, 0.521f, 0.488f, 0.353f, 0.232f, 0.157f, 0.109f,
        0.032f, -0.549f, 0.921f, 1.02f, 0.724f, 0.453f, 0.286f, 0.19f, 0.129f,
        0.013f, -1.178f, 3.935f, 1.856f, 0.85f, 0.492f, 0.316f, 0.199f, 0.139f,
        -0.008f, -0.323f, 0.814f, 0.957f, 0.663f, 0.428f, 0.286f, 0.197f, 0.14f,
        -0.006f, -0.003f, 0.243f, 0.338f, 0.361f, 0.296f, 0.226f, 0.172f, 0.129f,
        -0.001f,    0.043f, 0.164f,  0.193f,   0.216f,    0.2f,   0.168f,    0.136f, 0.108f,
        0.001f,  0.041f,  0.103f,  0.122f,  0.139f,  0.136f,  0.126f,  0.106f,  0.092f,
    };
}