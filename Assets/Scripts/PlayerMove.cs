using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float walkSpeed; 
    public float maxWalk;
    public float turnSpeed;
    private Vector2 moveInput;
    private Vector2 rotateInput;
    private Rigidbody rigi;
    private IA_PlayerInputs ctrl;


    void Awake()
    {
           rigi = GetComponent<Rigidbody>();
           ctrl = new IA_PlayerInputs();
           ctrl.Enable();
    }

    void OnDisable()
         
    {
        ctrl.Disable();
    }
    
    
      private void FixedUpdate()
      {
         moveInput = ctrl.Player.Move.ReadValue<Vector2>();

         

       if (moveInput.magnitude > 0.1f)
       {
         Vector3 moveForward = moveInput.y * this.transform.forward;
         Vector3 moveRight = moveInput.x * this.transform.right;
         Vector3 moveVector = moveForward + moveRight;
         rigi.AddForce(moveVector * walkSpeed * Time.deltaTime);

         rigi.linearVelocity = Vector3.ClampMagnitude(rigi.linearVelocity, maxWalk);
       }
    }




    

  


}
