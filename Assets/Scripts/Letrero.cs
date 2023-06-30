using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letrero : MonoBehaviour{
    public string texto = "Salón ";
    public int numero_salon;

    private void Start(){
        GetComponentInChildren< Text >().text = texto + numero_salon;
    }
}