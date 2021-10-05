using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speedMove;

    private Vector3 moveVector;

    CharacterController characterController;

    MobileController mobCont;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mobCont = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
    }

    void CharacterMovement()
    {
        moveVector = Vector3.zero;
        moveVector.z = mobCont.Horizontal() * speedMove;
        moveVector.x = mobCont.Vertical() * speedMove;

        if (Vector3.Angle(Vector3.forward,moveVector) > 1f || Vector3.Angle(Vector3.forward,moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        characterController.Move(moveVector * Time.deltaTime);
    }
   
}
