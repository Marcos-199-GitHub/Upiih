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

    private void Start(){
        reset();
    }

    private void Update(){
        float delta_time = Time.deltaTime * 40;
        if( Input.GetMouseButton( 1 ) ){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            float velocity_rot = Input.GetKey( KeyCode.LeftShift ) ? 3 : 1;
            transform.Rotate( new Vector3( 0, sense_rot * Input.GetAxisRaw( "Mouse X" ), 0 ) * ( delta_time * velocity_rot ), Space.World );
            transform.Rotate( new Vector3( -sense_rot * Input.GetAxisRaw( "Mouse Y" ), 0, 0 ) * ( delta_time * velocity_rot ), Space.Self );
        }
        else if( Input.GetMouseButton( 2 ) ){
            Cursor.lockState =  CursorLockMode.Locked;
            Cursor.visible   =  false;
            target_position  -= transform.right * ( sense_mov_wheel * Input.GetAxisRaw( "Mouse X" ) * delta_time );
            target_position  -= transform.up    * ( sense_mov_wheel * Input.GetAxisRaw( "Mouse Y" ) * delta_time );
        }
        else{
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;
        }

        float velocity = Input.GetKey( KeyCode.LeftShift ) ? 3 : 1;

        target_position += transform.right   * ( sense_mov * Input.GetAxisRaw( "Horizontal" ) * delta_time * velocity );
        target_position += transform.forward * ( sense_mov * Input.GetAxisRaw( "Vertical" )   * delta_time * velocity );

        //lerp
        transform.position = Vector3.Lerp( transform.position, target_position, 0.1f );
    }

    public void reset(){
        goToCamera( zero );
    }

    public void goToCamera( Transform new_camara_transform ){
        target_position    = new_camara_transform.position;
        transform.rotation = new_camara_transform.rotation;
    }
}