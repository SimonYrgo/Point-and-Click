using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 5f;
    

    Rigidbody body; // skapa en variabel som h�mtar 
    float horizontal;
    float vertical;

    public AudioSource jumpSound;
    
    
    private int lastRandomInt = 0;  // Detta lagrar v�rdet av int r i Hamburger-scriptet f�r att j�mf�ra
                                    // s� man inte slumpar samma tal 2 ggr i rad. 

    void Start()
    {
        body = GetComponent<Rigidbody>();
        
    }

   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // kollar A och D tangenter och g�r till -1, 0, 1 v�rden av input -1 v�nster 0 stilla , 1 h�ger
        vertical = Input.GetAxisRaw("Vertical"); // kollar ws tangenter och ger v�rde -1, 0, 1 
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * 500);
            jumpSound.Play();
            
        }
    }

    private void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right; // beh�ver bara ha right f�r att j�mf�ra med p� horizontalaxeln, 
                                               // om vi g�r left s� �r det motsatt right. 

        forward.y = 0; // skippa kamerans rotation p� karakt�ren i dessa riktningar
        right.y = 0;

        Vector3 direction = forward * vertical + right * horizontal; // lagrar dessa siffror i ett array vilket inte var l�t att fatta

        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed; // anv�nder ovan array

        body.MovePosition(movement);

        if ( direction != Vector3.zero) // rotera inte om ingen kanpp tryckt - ingen f�r�ndring p� ngn axis i arrayet    
        {
            transform.rotation = Quaternion.LookRotation(direction); // annars g�r detta: min forward (objektets forward) vill titta i riktiningen som finns direction arrayet
        }

    }

    public int duplicateSoundChecker(int r, int length ) // r = randomvariabeln i hamburgarscriptet, legnth = l�ngd p� hamburgarLjud
        // int kan ocks� anv�ndas som funktion att returnera just en int med
    {

        while (r == lastRandomInt)  // kolla lastTandomInt (definerad h�gst upp).. >
                                    //  > ..om samma som r, slumpa om i s� fall. 
        {
            r = Random.Range(0, length); // vi anv�nder length = hamburgarljud-l�ngd f�r att kunna �ndra storlek p� array flexibelt
            Debug.Log(r);
        }

        lastRandomInt = r; // s�tt till samma som r
        return r; // returnera v�rdet i r till hamburgar scriptet
    } 

}
