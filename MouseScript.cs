using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class MouseScript : MonoBehaviour
{
    //De variabele voor de movement speed
    public float PlayerMovementSpeed = 10;

    //De variabelen voor de boundary
    public float zMin;
    public float zMax;
    public float yMin;
    public float yMax;
	
	// Update is called once per frame
	void Update ()
	{
        //Hier wordt ervoor gezorgd dat de muis kan bewegen als de linker stick op de controller wordt bewogen
        transform.Translate(Input.GetAxis("Vertical") * Time.deltaTime * -PlayerMovementSpeed, 0, 0);
        transform.Translate(0, Input.GetAxis("Horizontal") * Time.deltaTime * -PlayerMovementSpeed, 0);

	    BoundaryCheck();        //Roep de methode BoundaryCheck() aan
	}

    void BoundaryCheck()
    {
        //Hier wordt (elke frame) gecontroleerd of de muis nog binnen de boundary zit
        //Zo niet, dan wordt hij teruggezet naar de laatste positie waar hij er nog
        //wel in zat
        if (transform.position.z > zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin);
        }
        if (transform.position.z < zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        }
        if (transform.position.y < yMin)
        {
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
        }
        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
        }
    }
}
