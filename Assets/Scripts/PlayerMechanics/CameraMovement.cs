using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    public float mouseSens;
    float mouseX;
    float mouseY;
    float xRotation;
    float yRotation;
    PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        pauseMenu=FindObjectOfType<PauseMenu>();
        mouseSens=1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
        mouseX=Input.GetAxis("Mouse X")*mouseSens;
        mouseY=Input.GetAxis("Mouse Y")*mouseSens;
        mouseSens=PlayerPrefs.GetFloat("Sensitivity");

        yRotation+=mouseX;
        xRotation-=mouseY;
        xRotation=Mathf.Clamp(xRotation, -90f, 90f);
        CameraFreeze();

        // RaycastHit hit;
        // int layerMask=1<<8;
        // layerMask = ~layerMask;
        //  if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        // {
        //     Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //     Debug.Log("Did Hit");
        // }
    }

    void PauseCheck(){
        if(pauseMenu.isPaused==true){
            Cursor.lockState=CursorLockMode.None;
            Cursor.visible=true;
            
        }

        else{
            Cursor.lockState=CursorLockMode.Locked;
            Cursor.visible=false;
        }
    }

    void CameraFreeze(){
        if(pauseMenu.isPaused==true){
            mainCamera.transform.rotation=Quaternion.Euler(0,0,0); //freeze camera
            transform.rotation=Quaternion.Euler(0,0,0);
        }
        else{
            mainCamera.transform.rotation=Quaternion.Euler(xRotation,yRotation,0);
            transform.rotation=Quaternion.Euler(0,yRotation,0);
        }
    }

}
