using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    public float jumpHeight = 2;
    private bool isGrounded = true;
    private Rigidbody2D rigidbody2D;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate() {

       
       if (Input.GetKey(KeyCode.A)){
           
           float horizontalMovement = Input.GetAxisRaw("Horizontal");

            Vector2 Movement = new Vector2 (horizontalMovement, 0);

            rigidbody2D.AddForce(Movement * speed);
       }

       else if(Input.GetKey(KeyCode.D)){
            float horizontalMovement = Input.GetAxisRaw("Horizontal");

            Vector2 Movement = new Vector2 (horizontalMovement, 0);

            rigidbody2D.AddForce(Movement * speed);
       }

       else if (Input.GetKey(KeyCode.Space) && isGrounded == true){
           rigidbody2D.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
       }

        float Horizontal = Input.GetAxisRaw("Horizontal");
        Flip(Horizontal);
       
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isGrounded = true;    
    }

    private void OnCollisionExit2D(Collision2D other) {
        isGrounded = false;
    }

    private void Flip(float Horizontal){
        if(Horizontal > 0 && !facingRight || Horizontal < 0 && facingRight){
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
