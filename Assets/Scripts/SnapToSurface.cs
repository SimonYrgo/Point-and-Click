using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToSurface: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hitInfo = new RaycastHit(); 
           bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 10f);
        if (hit)
        {
            transform.position = hitInfo.collider.transform.position;
            //transform.position -= transform.forward * 0.75f ;
               // (hitInfo.collider.transform.position.x, 
               // hitInfo.collider.transform.position.y,
               // hitInfo.point.z) 
                //+ new Vector3 (0,0,0.001f);
        }
        else
        {
            Debug.Log("No hit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.forward, Color.red,10);
    }
}
