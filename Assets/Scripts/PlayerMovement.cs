using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [Header("Character Base Stats")]
    //how fast you want the character to move by default
    private float BASE_PLAYER_SPEED=1.0f;

    //for optional player speed upgrades should those exist
    public float speed;

    public Vector2 moveInput;
    public Rigidbody2D rb;
   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //reffernces move and process input every frame
    void Update()
    {
        ProcessInputs();
        PlayerMove();
    }

    //Gets input from arrow keys and applies speed to them
    void ProcessInputs()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput.Normalize();
    }

    //Adds base speed and any additional speed to input
    void PlayerMove()
    {
        rb.velocity=( moveInput *BASE_PLAYER_SPEED *speed);
    }

    //Killing Player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals ("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

}
