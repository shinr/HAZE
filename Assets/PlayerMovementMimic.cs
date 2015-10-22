using UnityEngine;
using System.Collections;

public class PlayerMovementMimic : MonoBehaviour {
    public GameObject player;
    public Transform portalAxis;
    [SerializeField]
    Vector3 cameraAxis;
	// Use this for initialization
	void Start () {
        cameraAxis = Quaternion.Euler(portalAxis.rotation.eulerAngles - player.transform.rotation.eulerAngles) * (portalAxis.position - player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        Vector3 distanceFromPlayer = portalAxis.position - player.transform.position;
        Vector3 anglesDifference = player.transform.rotation.eulerAngles - transform.rotation.eulerAngles;
        pos = Quaternion.AngleAxis(anglesDifference.x, Vector3.up) * pos;
        pos = Quaternion.AngleAxis(anglesDifference.z, Vector3.left) * pos;
        pos.y = player.transform.position.y;
        transform.position = pos;

	}
}
