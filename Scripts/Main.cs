using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Main : MonoBehaviour
{
    private Pfeile pfeile;
    public GameObject pfeileManager;

    // Kamera Einstellungen
    public bool twoD = true;
    private float cam2Size = 50.0f;

    // Hall-Sonde
    //private float hallSondeZPos = 0.0f;
    //private float hallSondeYPos = 0.0f;
    //public float messWert = 0.0f;

    // Objekte
    public GameObject spule1;
    public GameObject spule2;
    public Camera cam2;
    public Camera cam3;
    public GameObject lineale; // alle Lineale
    public GameObject lineal; // Unteres Lineal
    public GameObject lineal1; // Linkes Lineal
    public GameObject lineal2; // Rechtes Lineal
    //public GameObject hallSonde;
    //public Slider hallSondeZSlider; // Horizontal
    //public Slider hallSondeYSlider; // Vertikal
    public Slider cam2ZoomSlider; // Größe 2D Kamera
    public Slider cam2VerticalSlider; // Vetikale Verschiebung
    public Slider cam2HorizontalSlider; // Horizontale Verschiebung
    public Slider cam3RotationSlider; // Rotation 3D Kamera

    void Start()
    {
        // Spule
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(1, 1, 1);

        spule1.transform.position = new Vector3(0, 0, 20.0f);
        spule1.transform.localScale = new Vector3(40, 40, 10);

        spule2.transform.position = new Vector3(0, 0, -20.0f);
        spule2.transform.localScale = new Vector3(40, 40, 10);

        // 2D Kamera
        cam2.transform.position = new Vector3(-100, 0, 0);
        cam2.transform.rotation = Quaternion.Euler(0, 90, 0);
        cam2.orthographicSize = cam2Size;
        cam2.enabled = true;

        // 3D Kamera
        cam3.transform.position = new Vector3(-150, 150, 0);
        cam3.transform.rotation = Quaternion.Euler(45, 90, 0);
        cam3.enabled = false;

        // Lineal
        lineale.transform.position = new Vector3(0, 0, 0);
        lineale.transform.rotation = Quaternion.Euler(0, 0, 0);

        lineal.transform.position = new Vector3(0, -50, 0.5f);
        lineal.transform.rotation = Quaternion.Euler(0, -90, 90);

        lineal1.transform.position = new Vector3(0, -0.5f, 105);
        lineal1.transform.rotation = Quaternion.Euler(0, -90, 0);

        lineal2.transform.position = new Vector3(0, -0.5f, -105);
        lineal2.transform.rotation = Quaternion.Euler(0, -90, 0);

        // Hall-Sonde
        //hallSonde.transform.position = new Vector3(20, 0, 0);
        //hallSonde.transform.rotation = Quaternion.Euler(0, 90, 0);

        pfeile = pfeileManager.GetComponent<Pfeile>();

        // Slider
        //hallSondeZSlider.onValueChanged.AddListener((v) => {
        //    hallSondeZPos = hallYPos[(int)v] * -200;
        //});
        //hallSondeYSlider.onValueChanged.AddListener((v) => {
        //    hallSondeYPos = hallZPos[(int)v] * 200;
        //});

        cam2ZoomSlider.enabled = true;
        cam2VerticalSlider.enabled = true;
        cam2HorizontalSlider.enabled = true;

        cam3RotationSlider.enabled = false;

        foreach (Transform child in cam2ZoomSlider.transform)
        {
           child.gameObject.SetActive(true);
        }
        foreach (Transform child in cam2VerticalSlider.transform)
        {
           child.gameObject.SetActive(true);
        }
        foreach (Transform child in cam2HorizontalSlider.transform)
        {
           child.gameObject.SetActive(true);
        }
        foreach (Transform child in cam3RotationSlider.transform)
        {
            child.gameObject.SetActive(false);
        }

        cam2ZoomSlider.onValueChanged.AddListener((v) => {
            cam2Size = v;
        });    
        cam2VerticalSlider.onValueChanged.AddListener((v) => {
            cam2.transform.position = new Vector3(cam2.transform.position.x, -v, cam2.transform.position.z);
        });
        cam2HorizontalSlider.onValueChanged.AddListener((v) => {
            cam2.transform.position = new Vector3(cam2.transform.position.x, cam2.transform.position.y, -v);
        });
        cam3RotationSlider.onValueChanged.AddListener((v) => {
            RotateCam(v);
        }); 
    }

    void Update()
    {
        //hallSonde.transform.position = new Vector3(20, hallSondeYPos, hallSondeZPos);
        cam2.orthographicSize = cam2Size;
    }

    public void Toggle2d()
    {
        if(twoD == true)
        {
            twoD = false;

            cam2.enabled = false;
            cam3.enabled = true;

            cam2ZoomSlider.enabled = false;
            cam3RotationSlider.enabled = true;

            foreach (Transform child in cam2ZoomSlider.transform)
            {
                child.gameObject.SetActive(false);
            }
            foreach (Transform child in cam2VerticalSlider.transform)
            {
               child.gameObject.SetActive(false);
            }
            foreach (Transform child in cam2HorizontalSlider.transform)
            {
               child.gameObject.SetActive(false);
            }
            foreach (Transform child in cam3RotationSlider.transform)
            {
                child.gameObject.SetActive(true);
            }
        }else if(twoD == false)
        {
            twoD = true;

            cam2.enabled = true;
            cam3.enabled = false;

            cam2ZoomSlider.enabled = true;
            cam3RotationSlider.enabled = false;

            foreach (Transform child in cam2ZoomSlider.transform)
            {
                child.gameObject.SetActive(true);
            }
            foreach (Transform child in cam2VerticalSlider.transform)
            {
               child.gameObject.SetActive(true);
            }
            foreach (Transform child in cam2HorizontalSlider.transform)
            {
               child.gameObject.SetActive(true);
            }
            foreach (Transform child in cam3RotationSlider.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ToggleLineal()
    {
        if(lineal.activeSelf == true)
        {
            lineal.SetActive(false);
            lineal1.SetActive(false);
            lineal2.SetActive(false);
        }
        else if(lineal.activeSelf == false)
        {
            lineal.SetActive(true);
            lineal1.SetActive(true);
            lineal2.SetActive(true);
        }
    }

    //public void ToggleHallSonde()
    //{
    //    if(hallSonde.activeSelf == true)
    //    {
    //        hallSonde.SetActive(false);
    //    }
    //    else if(hallSonde.activeSelf == false)
    //    {
    //        hallSonde.SetActive(true);
    //    }
    //}

    void RotateCam(float sliderValue)
    {
        float radius = 150.0f; // Setze den gewünschten Radius
        float angle = sliderValue * 360.0f; // Wandle Sliderwert in Grad um

        float x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
        float z = radius * Mathf.Sin(Mathf.Deg2Rad * angle);

        Vector3 newPos = new Vector3(x, 150.0f, z); // Y-Position kann entsprechend angepasst werden

        cam3.transform.position = newPos;
        cam3.transform.LookAt(Vector3.zero); // Kamera schaut immer auf den Ursprungspunkt
    }


    //private float[] hallYPos = new float[]
    //{
    //    0f, 0.05f, 0.12f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f, 0.5f
    //};
//
    //private float[] hallZPos = new float[]
    //{
    //    -0.05f, 0f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f
    //};
}