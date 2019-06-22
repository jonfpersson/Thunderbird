using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
    public static string sphereObject = "Sphere";
    public int speed = 40;
    GameObject prefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        prefab = Resources.Load(sphereObject) as GameObject;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject ball = Instantiate(prefab) as GameObject;
            ball.transform.position = transform.position + Camera.main.transform.forward * 1.3f;
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * speed;
        }
    }
}
