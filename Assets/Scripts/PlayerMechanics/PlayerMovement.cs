using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody myrigidbody;
    [SerializeField] float playerSpeed=5.0f;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody=GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMover();

    }

    void OnMove(InputValue value){
        moveInput=value.Get<Vector2>();
    }

    void PlayerMover(){
        //Vector3 playerVelocity = new Vector3(playerSpeed*moveInput.x, 0, playerSpeed*moveInput.y);
        Vector3 playerVelocity = transform.forward*moveInput.y+transform.right*moveInput.x;
        myrigidbody.velocity=playerVelocity.normalized*playerSpeed*Time.fixedDeltaTime;

    }
}
