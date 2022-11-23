using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    public int selectedGun = 0;


    void Start()
    {
        SelectGun();
    }

 
    void Update()
    {
        int previous = selectedGun;

        //Scroll up
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedGun >= transform.childCount - 1)
                selectedGun = 0;
            else
                selectedGun++;
        }

        //Scroll down
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedGun <= 0)
                selectedGun = transform.childCount - 1;
            else
                selectedGun--;
        }

        if(previous != selectedGun)
            SelectGun();
    }

    void SelectGun()
    {
        int i = 0;

        foreach (Transform gun in transform)
        {
            if(i == selectedGun)
                gun.gameObject.SetActive(true);
            else
                gun.gameObject.SetActive(false);
            i ++;
        }
    }
}
