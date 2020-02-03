using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpDistance = 5f;
    public bool isGrounded = false;
    bool facingRight = true;
    public GameObject Player;
    //private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        Jump();
        float movement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(movement));
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * moveSpeed;
        if (movement<0 &&facingRight)
        {
           flip();
        }
        else if(movement>0&& !facingRight)
        {
           flip();
        }

       
        //Flip(movement);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Exit"))
        {

            SceneManager.LoadScene("Level1");


        }
        if (col.gameObject.name.Equals("Exit2"))
        {

            SceneManager.LoadScene("Lvl3");


        }
        if (col.gameObject.name.Equals("Exit3"))
        {

            SceneManager.LoadScene("LevelComp");


        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player.GetComponent<Movement>().isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player.GetComponent<Movement>().isGrounded = false;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")&& isGrounded==true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpDistance), ForceMode2D.Impulse);
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
   /*private Flip(float movement)
    {
        if(movement>0 && !facingRight || movement<0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }*/
}
