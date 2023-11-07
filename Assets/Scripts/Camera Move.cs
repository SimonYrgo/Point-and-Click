using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float followDistance = 8f;
    public float cameraSpeed = 3f;
    private void LateUpdate() // bra att anv till cameran, motverkar att det hackar  
    {
        // Kan l�sa av Musen 
        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * cameraSpeed;
        // local = bara i f�rh�llande till sig sj�lv, bara rot p� y axeln, dvs rot runt uppsn�ret i Unity, 
        // detta ger oss ett nytt rotationsv�rde f�r y axeln p� objektet. 

        //float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * cameraSpeed;
        // Detta g�r samma sak fast f�r upp ner med musen. Jag kommenterade ut f�r tyckte det var lite r�rigt med upp/ner funktionen. 

        //Vector3 desiredRotation = new Vector3(newRotationY, newRotationX, 0);
        //transform.localEulerAngles = desiredRotation;
        //// ta floaterna oavn och bygg ny vektor array av. Jag kommenterade ut newRotationY nedan f�r tyckte det var lite r�rigt med upp/ner funktionen. 

        Vector3 desiredRotation = new Vector3(0, newRotationX, 0);
        transform.localEulerAngles = desiredRotation;
        









        Vector3 desiredPosition = target.position - transform.forward * followDistance;
        transform.position = desiredPosition; // kameran ska f�lja spelaren 

        



    }
}
