using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int score;
    public Text scoreText;
    public GameObject spawn;

    public float timeScale;
    public float timeScaleMax;

    private bool isGround;
    public bool isRightSide = true;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        scoreText.text = score.ToString();
       

        spawn = GameObject.FindWithTag("Respawn");
        transform.position = spawn.transform.position;
    }
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = false;
            }
            animator.SetInteger("AnimState", 1);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }

        if (isGround == true)
        {
        
        }
            else
            {
            animator.SetInteger("AnimState", 2);
            }

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

    public void AddCoin(int count)
    {
        score += count;
        scoreText.text = score.ToString();
    }

    private void Jump()
    {

        rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            isGround = true;
        }
    }

}