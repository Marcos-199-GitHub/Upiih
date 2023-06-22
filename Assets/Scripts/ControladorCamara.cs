using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour{
    public Transform zero;

    public float sense_rot       = 1;
    public float sense_mov_wheel = 1;
    public float sense_mov       = 1;

    public Transform[] CamarasEdificios;

    private void Start(){
        reset();
    }

    private void Update(){
        float delta_time = Time.deltaTime * 40;
        if( Input.GetMouseButton( 1 ) ){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible   = false;
            transform.Rotate( new Vector3( 0, sense_rot * Input.GetAxis( "Mouse X" ), 0 )    * delta_time, Space.World );
            transform.Rotate( new Vector3( -sense_rot   * Input.GetAxis( "Mouse Y" ), 0, 0 ) * delta_time, Space.Self );
        }
        else if( Input.GetMouseButton( 2 ) ){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible   = false;
            transform.Translate(
                -new Vector3( sense_mov_wheel * Input.GetAxis( "Mouse X" ), sense_mov_wheel * Input.GetAxis( "Mouse Y" ), 0 ) * delta_time
            );
        }
        else{
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;
        }

        transform.Translate(
            new Vector3( sense_mov * Input.GetAxis( "Horizontal" ), 0, sense_mov * Input.GetAxis( "Vertical" ) ) * delta_time
        );

        
    }

    public void reset(){
        goToCamera( zero );
    }

    public void goToCamera( Transform new_camara_transform ){
        transform.position = new_camara_transform.position;
        transform.rotation = new_camara_transform.rotation;
    }
}