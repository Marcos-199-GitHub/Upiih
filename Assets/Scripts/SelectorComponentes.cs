using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorComponentes : MonoBehaviour{

    public GameObject[] SelectoresDePiso;
    public GameManager  gameManager;
    public Toggle       toggleSelector;

    private void Update(){
        foreach( GameObject VARIABLE in SelectoresDePiso ){
            VARIABLE.SetActive( false );
        }

        if( gameManager.EdificioActual != null ){
            for( int i = 0; i < gameManager.EdificioActual.Muros.Length; i++ ){
                SelectoresDePiso[i].SetActive( true );
            }
        }
    }

    public void resetToggles(){
        Update();

        foreach( Toggle VARIABLE in GetComponentsInChildren< Toggle >() ){
            VARIABLE.isOn = true;
        }

        toggleSelector.isOn = false;
    }

}