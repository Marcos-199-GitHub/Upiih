using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour{
    public Transform zero;

    public float       sense_rot       = 1;
    public float       sense_mov_wheel = 1;
    public float       sense_mov       = 1;
    public Transform[] CamarasEdificios;

    private Vector3 target_position;
    private Vector3 target_angle;
    private Vector3 angle_actual;

    private void Start(){
        reset();
    }

    private void Update(){
        if( Input.GetMouseButton( 1 ) ){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible   = false;
            float velocity_rot = Input.GetKey( KeyCode.LeftShift ) ? 3 : 1;
            target_angle += new Vector3( -Input.GetAxisRaw( "Mouse Y" ), Input.GetAxisRaw( "Mouse X" ), 0 ) *
                ( sense_rot * velocity_rot );
        }
        else if( Input.GetMouseButton( 2 ) ){
            Cursor.lockState =  CursorLockMode.Locked;
            Cursor.visible   =  false;
            target_position  -= transform.right * ( sense_mov_wheel * Input.GetAxisRaw( "Mouse X" ) * Time.deltaTime );
            target_position  -= transform.up    * ( sense_mov_wheel * Input.GetAxisRaw( "Mouse Y" ) * Time.deltaTime );
        }
        else{
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;
        }

        float velocity = Input.GetKey( KeyCode.LeftShift ) ? 3 : 1;

        target_position += transform.right   * ( sense_mov * Input.GetAxisRaw( "Horizontal" ) * Time.deltaTime * velocity );
        target_position += transform.forward * ( sense_mov * Input.GetAxisRaw( "Vertical" )   * Time.deltaTime * velocity );

        transform.position = target_position;
        angle_actual       = target_angle;
        transform.rotation = Quaternion.Euler( angle_actual );
    }

    public void reset(){
        goToCamera( zero );
    }

    public void goToCamera( Transform new_camara_transform ){
        target_position = new_camara_transform.position;
        target_angle    = new_camara_transform.eulerAngles;
    }
}