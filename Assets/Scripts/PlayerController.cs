using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D playerRigidBody;
    private Vector2 movement;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        SoundManager.Instance.PlayMusic(Sounds.Music);
    }

    private void Update()
    {
        //Handling input in update 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Calculating movement direction based on the input.
        movement = new Vector2(horizontalInput, verticalInput).normalized;

        //To flip the player
        if(horizontalInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1);
        }
    }

    private void FixedUpdate()
    {
        CharacterMovement(movement);
    }

    private void CharacterMovement(Vector2 direction)
    {
        //Applying movement to rigidbody in FixedUpdate.
        playerRigidBody.MovePosition(playerRigidBody.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
