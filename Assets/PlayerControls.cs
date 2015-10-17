using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    public float speed;
    CharacterController controller;
    
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
    
	}
	
	// Update is called once per frame
	void Update () {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        float multiplier = 1.0f;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            multiplier = 4.0f;
        }
        controller.SimpleMove(multiplier * speed * transform.forward * verticalAxis + transform.right * speed * horizontalAxis* multiplier);
	}
}
