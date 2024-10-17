//Using a YouTube Tutorial playlist link: https://www.youtube.com/watch?v=TcranVQUQ5U&list=PLgOEwFbvGm5o8hayFB6skAfa8Z-mw4dPV 
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //making references and variables here
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator animate;
    // private bool grounded; //this was temporary during the tutorial
    private BoxCollider2D boxCollider; 
    private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake(){
        body = GetComponent<Rigidbody2D>(); //accessing rigidbody2d through GetComponent
        animate = GetComponent<Animator>(); // accessing the animator in unity
        boxCollider = GetComponent<BoxCollider2D>(); //accessing the BoxCollider component
        
    }


    private void Update(){
        //variable for easy use
        //using Input.GetAxis for user input influence on the character movement
        horizontalInput = Input.GetAxis("Horizontal");
        //making the player able to move
        // body.velocity = new Vector2(horizontalInput * moveSpeed, body.velocity.y);

        //if else statements to flip the character sprite to face the direction it is moving towards
        if(horizontalInput > 0.01){ //player moving right
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f){ //player moving left
            transform.localScale = new Vector3(-1,1,1);
        }

        //jumping mechanic using if statement
        // if(Input.GetKey(KeyCode.Space) && isGrounded()){
        //     Jump();
        // }

        //animator parameters
        animate.SetBool("run", horizontalInput != 0); //player is moving
        animate.SetBool("grounded", isGrounded());

        //wall jump mechanic logic
        if (wallJumpCooldown > 0.2f){
            

            body.velocity = new Vector2(horizontalInput * moveSpeed, body.velocity.y);

            //When the player is on the wall, but not on the ground the gravity and velocity will be set to 0 
            if(onWall() && !isGrounded()){
                body.gravityScale = 0.7f;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;
            
            if(Input.GetKey(KeyCode.Space)){
                Jump();
            }
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    //making the Jump method
    private void Jump(){

        if(isGrounded()){
            //now changing velocity on the y-axis
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        animate.SetTrigger("jump");
        // grounded = false; //from tutorial    
        }
        //wall jump mechanic, changing direction the player is facing
        else if(onWall() && !isGrounded()){
            //enable the WallSlide animation
            

            if(horizontalInput == 0){
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x)*4, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                //animate.SetTrigger("WallSlide"); //for wallslide animation (do later)
            }
            else            
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x)*1, 2); //multiply by gravity and force
                //animate.SetTrigger("jump");
            wallJumpCooldown = 0;
            
        }
    }

    //using collision (This was during the tutorial, no longer needed)
    private void OnCollisionEnter2D(Collision2D collision){
        //if the character is on the spikes (unable to figure out how to enable it)
        if(collision.gameObject.tag == "Enemy"){
            
            GetComponent<HealthManager>().Damage(20);
        }
        //from tutorial
        // if(collision.gameObject.tag == "Ground"){
        //     //boolean for the grounded condition is true
        //     grounded = true;
        // }
    }

    //another method for determining whether or not the player is on the ground, using a method/function.
    private bool isGrounded(){

        //raycasthit allows rays to shoot out from the player and collide with objects
        //boxcast like raycast but no virtual ray, using a box instead (same width as the player)
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer); 
        return raycastHit.collider != null;  
    }

    //Wall Jumping Mechanic using a similar method to isGrounded() to detect a wall
    private bool onWall(){

        //similar, only changing the direction and layer mask
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer); 
        return raycastHit.collider != null;  
    }

    // #region Save and Load

    // public void Save(ref PlayerSaveData data){
    //     data.Position = transform.position;
    // }

    // public void Load(PlayerSaveData data){
    //     transform.position = data.Position;
    // }

    // #endregion

}
//https://www.youtube.com/watch?v=1mf730eb5Wo for the save method
// [System.Serializable]
// public struct PlayerSaveData{
//     public Vector3 Position;
// }
