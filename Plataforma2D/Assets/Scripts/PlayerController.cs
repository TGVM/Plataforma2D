using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour{

    public float jumpForce = 550;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    [SerializeField]
    private float walkSpeed;

    private Rigidbody2D rb;
    private Vector2 newMovement;
    private bool facingRight = true;
    private bool jump;
    private bool grounded;
    private bool doubleJump;

    private PlayerAnimation playerAnimation;
    private bool canControl = true;

    // Awake is called when object is instantiated
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        playerAnimation.SetOnGround(grounded);
        
        if(grounded){
            doubleJump = false;
        }

    }

    // FixedUpdate is called once every fixed timer set on Unity
    private void FixedUpdate(){
        if(!canControl){
            return;
        }

        rb.velocity = newMovement;

        if(jump){
            jump = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            if(!doubleJump && !grounded){
                doubleJump = true;
            }
        }
        playerAnimation.SetVSpeed(rb.velocity.y);
    }

    public void Jump(){
        if(grounded || !doubleJump){
            jump = true;
        }
    }

    //function to update movement vector
    public void Move(float direction){
        float currentSpeed = walkSpeed;
        newMovement = new Vector2(direction * currentSpeed, rb.velocity.y);

        playerAnimation.SetSpeed((int)Mathf.Abs(direction));

        if(facingRight && direction<0){
            Flip();
        }else if(!facingRight && direction>0){
            Flip();
        }

    }

    //aux function to flip player sprite
    void Flip(){
        facingRight = !facingRight;

        transform.Rotate(0,180,0);
    }

    public void DisableControls(){
        canControl = false;
    }

    public void EnableControls(){
        canControl = true;
    }

    public bool GetGrounded(){
        return grounded;
    }

}
