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
            pair.GetComponent<Teleporter>().ReceiveTeleport(other, transform.position);
        }
        receiving = false;
    }

    public void ReceiveTeleport(Collider other, Vector3 origin)
    {
        receiving = true;
        Vector3 newPosition = transform.position - (origin - other.gameObject.transform.position);
        other.gameObject.transform.position = newPosition;
        if (transform.rotation.eulerAngles != Vector3.zero)
        {
            other.gameObject.GetComponent<CameraControl>().RotateMouse(new Vector2(transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.x));
            //            newPosition = Quaternion.AngleAxis(rotation.y, transform.up) * newPosition;
            other.gameObject.transform.RotateAround(transform.position, transform.up, transform.rotation.eulerAngles.y);
        }
        
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
