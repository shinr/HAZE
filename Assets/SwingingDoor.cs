using UnityEngine;
using System.Collections;

public class SwingingDoor : MonoBehaviour {
    public bool open;
    bool moving = false;
    bool playerInRadius = false;
    public float timeBeforeClosing;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(open) {
            return;
        }
        moving = true;
    }
	
	// Update is called once per frame
	void Update () {
        
	
	}
}
