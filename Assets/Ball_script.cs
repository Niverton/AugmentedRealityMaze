using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_script : MonoBehaviour {

    public GameObject light;
    public Ball_controller controller;

    private int numero = int.MaxValue;
    private bool good = true;


    private void Update()
    {
        light.transform.position = transform.position+new Vector3(0, 2, 0);
        if (good){
            if(light.GetComponent<Light>().spotAngle != 150)
                light.GetComponent<Light>().spotAngle++;
        }
        else {
            if (light.GetComponent<Light>().spotAngle != 70)
                light.GetComponent<Light>().spotAngle--;
        }
    }

    public void good_path() {
        if (!good)
        {
            good = true;
        }
    }
    public void bad_path() {
        if (good)
        {
            good = false;
        }
    }
    public void Set_numero(int numero) {
        if (this.numero < numero)
            bad_path();
        if (this.numero > numero)
            good_path();
        this.numero = numero;
    }
    public void Reset()
    {
        controller.reset();
    }
}
