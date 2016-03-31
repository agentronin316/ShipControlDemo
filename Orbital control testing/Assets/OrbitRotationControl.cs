using UnityEngine;
using System.Collections;

public class OrbitRotationControl : MonoBehaviour {


    [Tooltip("In Earth months")]
    public float orbitalPeriod;

    [Tooltip("In millions of miles")]
    public float orbitalDistance;

    Transform planet;

    float orbitalSpeed;

    void Start()
    {
        planet = transform.GetChild(0);

        if (orbitalDistance <= 0)
        {
            Debug.Log("Please set orbital distance to a positive value for OrbitRotationControl on " + gameObject.name + " at " + transform.position);
            Time.timeScale = 0;
        }

        if (orbitalPeriod <= 0)
        {
            Debug.Log("Please set orbital period to a positive value for OrbitRotationControl on " + gameObject.name + " at " + transform.position);
            Time.timeScale = 0;
        }

        if (planet == null)
        {
            Debug.Log("Please set a planetary child on " + gameObject.name + " at " + transform.position);
            Time.timeScale = 0;
        }

        if(Time.timeScale > 0)
        {
            orbitalSpeed = 360 / orbitalPeriod;
            planet.position = new Vector3(0, 0, orbitalDistance / 10f);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, orbitalSpeed * Time.deltaTime, 0));
	}
}