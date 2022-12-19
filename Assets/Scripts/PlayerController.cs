using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Text scoreText;
    public float score;
    public float speed;
    public float jumpForce;


    private GameObject spawn;
    private Rigidbody2D rigidbody2d;
    private bool isGround;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spawn = GameObject.FindWithTag("Respawn");
        transform.position = spawn.transform.position;
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }


        Vector3 position = transform.position;

        position.x += Input.GetAxis("Horizontal") * speed;

        transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            Jump();
        }
    }
    private void Jump()
    {
        rigidbody2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            isGround = true;
        }
    }

}