using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
    public GameObject pair;
    public bool receiveOnly;
    bool receiving = false;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (!receiving && !receiveOnly)
        {
            Quaternion rotation = Quaternion.FromToRotation(transform.forward, pair.transform.forward);
            pair.GetComponent<Teleporter>().ReceiveTeleport(other, transform.position, rotation);
        }
        receiving = false;
    }

    public void ReceiveTeleport(Collider other, Vector3 origin, Quaternion rotation)
    {
        receiving = true;
        Vector3 newPosition = transform.position - (origin - other.gameObject.transform.position);
        other.gameObject.transform.position = newPosition;
        Vector3 angles = rotation * other.gameObject.transform.forward;
        if (angles != Vector3.zero)
        {
            other.gameObject.GetComponent<CameraControl>().RotateMouse(new Vector2(angles.x, angles.y));
            other.gameObject.transform.RotateAround(transform.position, transform.up, angles.y);  // this is probably not right
            PlayerControls controls = other.gameObject.GetComponent<PlayerControls>();
            CharacterController controller = other.gameObject.GetComponent<CharacterController>();
            if(controls && controller)
            {
                controls.RotateVelocity(angles);
            }
        }
        
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
