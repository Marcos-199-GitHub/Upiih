using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public ControladorCamara Controlador_camara;
    public Edificio[]        EdificiosDisponibles;

    public Edificio EdificioActual = null;

    private void Update(){
        if( Input.GetKeyDown( KeyCode.R ) ){
            Controlador_camara.reset();
        }

        if( Input.GetKeyDown( KeyCode.Keypad1 ) || Input.GetKeyDown( KeyCode.Alpha1 ) ){
            EdificioActual = EdificiosDisponibles[0];
            Controlador_camara.goToCamera( EdificioActual.camara );
        }
    }
}