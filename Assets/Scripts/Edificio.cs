using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edificio : MonoBehaviour{
    public Transform    camara;
    public GameObject[] Invisibles;
    public GameObject   Azotea;
    public GameObject   Escritorios;
    public GameObject   Racks;
    public GameObject[] Muros;
    public GameObject[] Puertas;
    public GameObject[] Suelos;
    public GameObject[] Tuberias;
    public GameObject[] Cableado;

    private void Start(){
        desactivar();
    }

    public void activar(){
        foreach( GameObject obj in Invisibles ){
            obj.SetActive( true );
        }
    }

    public void desactivar(){
        Azotea.SetActive( true );

        foreach( GameObject obj in Muros ){
            obj.SetActive( true );
        }

        foreach( GameObject obj in Puertas ){
            obj.SetActive( true );
        }

        foreach( GameObject obj in Suelos ){
            obj.SetActive( true );
        }

        foreach( GameObject obj in Tuberias ){
            obj.SetActive( true );
        }

        foreach( GameObject obj in Cableado ){
            obj.SetActive( true );
        }

        if( Escritorios != null ){
            Escritorios.SetActive( true );
        }

        if( Racks != null ){
            Racks.SetActive( true );
        }

        foreach( GameObject obj in Invisibles ){
            obj.SetActive( false );
        }
    }

}