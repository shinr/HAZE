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
            Vector3 angles = pair.transform.rotation.eulerAngles - transform.rotation.eulerAngles;
            float angle = Quaternion.Angle(transform.rotation, pair.transform.rotation);
            pair.GetComponent<Teleporter>().ReceiveTeleport(other, transform.position, angles);
        }
        receiving = false;
    }

    public void ReceiveTeleport(Collider other, Vector3 origin, Vector3 angles)
    {
        receiving = true;
        Vector3 newPosition = transform.position - (origin - other.gameObject.transform.position);
        other.gameObject.transform.position = newPosition;
        if (angles != Vector3.zero)
        {
            other.gameObject.GetComponent<CameraControl>().RotateMouse(new Vector2(angles.y, angles.x));
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
