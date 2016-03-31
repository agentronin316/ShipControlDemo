using UnityEngine;
using System.Collections;

public class ShipControls : MonoBehaviour {

    public float strafeSpeed = 3f;
    public float moveSpeed = 5f;
    public float turnSpeed = 2f;

    [HideInInspector]
    public bool orbiting = false;
    [HideInInspector]
    public float inverseRadius;

    OrbitPointTracking planetTracking;
    Transform ship;
	
    
    // Use this for initialization
	void Start ()
    {
        ship = transform.FindChild("Ship");
        planetTracking = GetComponent<OrbitPointTracking>();
        if (planetTracking.enabled)
        {
            planetTracking.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (orbiting)
        {
            Vector3 rotation = Vector3.zero;
            rotation.z = -Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime * inverseRadius * Mathf.Rad2Deg;
            rotation.y = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime * Mathf.Rad2Deg;
            rotation.x = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * inverseRadius * Mathf.Rad2Deg;
            transform.Rotate(rotation);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                planetTracking.enabled = false;
                orbiting = false;
            }
        }
        else
        {
            Vector3 transformation = Vector3.forward * moveSpeed * Time.deltaTime;
            transformation += Vector3.right * Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime;
            transform.Translate(transformation);
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime * Mathf.Rad2Deg, 0));
        }
	}

    
}