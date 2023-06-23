using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    public ControladorCamara Controlador_camara;
    public GameObject        ToggleSelector;

    public Text TextoEdificioActual;

    public SelectorComponentes Selector_Componentes;
    public Edificio[]          EdificiosDisponibles;

    public Edificio EdificioActual = null;

    private void Start(){
        Controlador_camara.reset();
        refresh();
    }

    private void Update(){
        if( Input.GetKeyDown( KeyCode.R ) ){
            Start();
            EdificioActual = null;
        }

        for( int i = 0; i < 5; i++ ){
            if( Input.GetKeyDown( KeyCode.Keypad1 + i ) || Input.GetKeyDown( KeyCode.Alpha1 + i ) ){
                refresh();
                EdificioActual = EdificiosDisponibles[i];
                Controlador_camara.goToCamera( EdificioActual.camara );
                setActiveEdificios( false );
                EdificioActual.gameObject.SetActive( true );
                EdificioActual.activar();
                ToggleSelector.SetActive( true );
                TextoEdificioActual.text = EdificioActual.gameObject.name;
                Selector_Componentes.resetToggles();
                break;
            }
        }
    }

    private void refresh(){
        if( EdificioActual ){
            EdificioActual.desactivar();
        }

        ToggleSelector.SetActive( false );
        Selector_Componentes.gameObject.SetActive( false );

        setActiveEdificios( true );
        ToggleSelector.SetActive( false );
        TextoEdificioActual.text = "Vista general";
    }

    private void setActiveEdificios( bool estado ){
        foreach( Edificio Edi in EdificiosDisponibles ){
            Edi.gameObject.SetActive( estado );
        }
    }

    public void setActiveAzotea( bool estado ){
        EdificioActual.Azotea.SetActive( estado );
    }

    //Muros
    public void setActiveMurosPlantaBaja( bool estado ){
        EdificioActual.Muros[0].SetActive( estado );
    }

    public void setActiveMurosPiso1( bool estado ){
        EdificioActual.Muros[1].SetActive( estado );
    }

    public void setActiveMurosPiso2( bool estado ){
        EdificioActual.Muros[2].SetActive( estado );
    }

    public void setActiveMurosPiso3( bool estado ){
        EdificioActual.Muros[3].SetActive( estado );
    }

    //Suelos
    public void setActiveSuelosPlantaBaja( bool estado ){
        EdificioActual.Suelos[0].SetActive( estado );
    }

    public void setActiveSuelosPiso1( bool estado ){
        EdificioActual.Suelos[1].SetActive( estado );
    }

    public void setActiveSuelosPiso2( bool estado ){
        EdificioActual.Suelos[2].SetActive( estado );
    }

    public void setActiveSuelosPiso3( bool estado ){
        EdificioActual.Suelos[3].SetActive( estado );
    }

    //Tuberias
    public void setActiveTuberiasPlantaBaja( bool estado ){
        EdificioActual.Tuberias[0].SetActive( estado );
    }

    public void setActiveTuberiasPiso1( bool estado ){
        EdificioActual.Tuberias[1].SetActive( estado );
    }

    public void setActiveTuberiasPiso2( bool estado ){
        EdificioActual.Tuberias[2].SetActive( estado );
    }

    public void setActiveTuberiasPiso3( bool estado ){
        EdificioActual.Tuberias[3].SetActive( estado );
    }

    //Cableado

    public void setActiveCableadoPlantaBaja( bool estado ){
        EdificioActual.Cableado[0].SetActive( estado );
    }

    public void setActiveCableadoPiso1( bool estado ){
        EdificioActual.Cableado[1].SetActive( estado );
    }

    public void setActiveCableadoPiso2( bool estado ){
        EdificioActual.Cableado[2].SetActive( estado );
    }

    public void setActiveCableadoPiso3( bool estado ){
        EdificioActual.Cableado[3].SetActive( estado );
    }
}