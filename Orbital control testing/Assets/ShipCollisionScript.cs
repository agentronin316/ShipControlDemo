using UnityEngine;
using System.Collections;

public class ShipCollisionScript : MonoBehaviour {

    ShipControls shipControls;
    OrbitPointTracking planetTracking;
    Transform ship;

    void Start()
    {
        ship = transform.parent;
        shipControls = ship.parent.gameObject.GetComponent<ShipControls>();
        planetTracking = ship.parent.gameObject.GetComponent<OrbitPointTracking>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit a planet");
        if (other.tag == "Planet" && !shipControls.orbiting)
        {
            planetTracking.enabled = true;
            planetTracking.parent = other.transform;
            ship.localPosition = new Vector3(0, Mathf.Max(other.transform.lossyScale.x, other.transform.lossyScale.y, other.transform.lossyScale.z) * .5f + .2f, 0);
            shipControls.inverseRadius = 1 / ship.localPosition.y;
            shipControls.orbiting = true;
            Debug.Log("starting orbit");
        }
    }
}
