using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock : MonoBehaviour
{
    float moveSpeed = 7f;
    Rigidbody2D rb;

    Movement target;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Movement>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
        if (col.gameObject.tag.Equals("Ground"))
        {
            Destroy(gameObject);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
