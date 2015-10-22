using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    public float speed;
    public float gravity;
    public float friction;
    public float maxSpeed;
    public float maxGravity;
    public float airResistance;
    CharacterController controller;
    [SerializeField]
    Vector3 velocity = Vector3.zero;
    Vector3 adjustmentVelocity = Vector3.zero;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
    
	}

    void OnCollisionEnter(Collision c)
    {
        adjustmentVelocity = Vector3.zero;
    }

    public void SetAdjustmentVelocity(Vector3 adjustment)
    {
        adjustmentVelocity = adjustment;
    }
	
    public void RotateVelocity(Vector3 angles)
    {
        velocity = Quaternion.Euler(angles) * velocity;
    }

	// Update is called once per frame
	void Update () {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        float multiplier = 1.0f;
        Vector3 movementSpeed = Vector3.zero;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            multiplier = 4.0f;
        }
        if (controller.isGrounded)
        {
            velocity *= friction;
        } else
        {
            velocity *= airResistance;
            velocity += Vector3.down * gravity;
        }
        velocity += multiplier * speed * transform.forward * verticalAxis + transform.right * speed * horizontalAxis * multiplier + adjustmentVelocity;
        movementSpeed.x = velocity.x;
        movementSpeed.z = velocity.z;
        movementSpeed = Vector3.ClampMagnitude(movementSpeed, maxSpeed);
        movementSpeed.y = Mathf.Clamp(velocity.y, -maxGravity, maxGravity);
        velocity = movementSpeed;
        controller.Move(velocity * Time.deltaTime);
	}
}
