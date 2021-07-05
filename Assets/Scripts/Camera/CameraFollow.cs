using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Refresh();
    }

    
    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }

        var pos = transform.position;
        transform.position = new Vector3(pos.x, 40, pos.z);
    }

    //public Transform target;

    //public float smoothSpeed = 10.5f;
    //public Vector3 offset;
    //private Vector3 velocity = Vector3.zero;

    //void LateUpdate()
    //{
    //	Vector3 desiredPosition = target.position + offset;
    //	////Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
    //	//Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
    //	//transform.position = smoothedPosition;		
    //	//transform.LookAt(target, transform.rotation);

    //	//transform.position.x = target.position.x;
    //	//transform.position.z = target.position.z;


    //	//transform.rotation
    //	//transform.rotation = Quaternion.Angle(Vector3(60, 0, 0));
    //}
}
