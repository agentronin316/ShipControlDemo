using UnityEngine;
using System.Collections;

public class OrbitPointTracking : MonoBehaviour {


    public Transform parent;
	
	// Update is called once per frame
	void Update ()
    {
	    if (parent == null)
        {
            Debug.Log("parent unassigned for OrbitPoint at (" + transform.position.x + ", " + transform.position.y + ", " + transform.position.z + "), please correct.");
            Time.timeScale = 0;
        }
        else
        {
            transform.position = parent.position;
        }
	}
}