using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    public Button infoButton;
    public GameObject infoBackground; 
    bool info = true;

    private void Update()
    {
        if(info == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ToggleInfo();
            }
        }
    }

    public void ToggleInfo()
    {
        if(info == true)
        {
            info = false;
            infoBackground.SetActive(false);
        }else if(info == false)
        {
            info = true;
            infoBackground.SetActive(true);
        }
    }
}
