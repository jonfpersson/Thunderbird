using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {

    public LineRenderer lineRenderer;
    private float counter;
    private float dist;
    public Transform player;
    public static bool canGrapplingHook;
    public float lineDrawSpeed = 700f;


    // Use this for initialization
    void Start () {
        //lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, player.position);
        lineRenderer.SetWidth(.10f, .10f);

        dist = Vector3.Distance(player.position, Hool.hit.point);
    }
	
	// Update is called once per frame
	void Update () {

        if (Hool.attached)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, player.position);
            
            dist = Vector3.Distance(player.position, Hool.hit.point);

            counter += .4f / lineDrawSpeed;
            float x = Mathf.Lerp(0, dist, counter);
            Vector3 pointA = player.position;
            Vector3 pointB = Hool.hit.point;
            
            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

            lineRenderer.SetPosition(1, pointAlongLine);
        }
        else
        {
            lineRenderer.enabled = false;
        }

    }
}
