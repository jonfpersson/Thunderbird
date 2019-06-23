using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Hool : MonoBehaviour {

    public Transform cam;
    public static RaycastHit hit;
    private Rigidbody rb;
    public static bool attached = false;
    public  float momentum;
    public float speed;
    public float step;
    bool hasLockedOnTarget;
    
    public RigidbodyFirstPersonController cc;

    GameObject hook;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        
        if (Input.GetButtonDown("Fire2"))
        {
            if(Physics.Raycast (cam.position, cam.forward, out hit) && hit.distance < 20)
            {
                Debug.Log("hit.distance: " + hit.distance);
                attached = true;
                rb.isKinematic = true;
                hasLockedOnTarget = true;
                hook = Instantiate(Resources.Load("grapplingHook") as GameObject, Hool.hit.point, Quaternion.identity);

            }

        }

        if (Input.GetButtonUp("Fire2") && hasLockedOnTarget)
        {
            attached = false;
            rb.isKinematic = false;
            rb.freezeRotation = true;

            rb.velocity = cam.forward * momentum;
            hasLockedOnTarget = false;
        }

        if (attached)
        {
            momentum += Time.deltaTime * speed / 0.1f;
          //  if (momentum > 25)
          //      momentum = 25;
            if (momentum < 15)
                momentum = 15;

            if (step < 0.5)
                step = momentum * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, hit.point, step);
            //Debug.Log("hit "+hit + " hitpoint: " + hit.point);
        }

        if (!attached && momentum >= 0)
        {
            momentum -= Time.deltaTime * 5;
            step = 0;
        }
        if(cc.Grounded && momentum <= 0)
        {
            momentum = 0;
            step = 0;
        }
	}
}
