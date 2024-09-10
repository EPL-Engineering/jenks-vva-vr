using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //creates a variable we can see/edit in the Unity Inspector Window
    public Vector3 startPosition;
    public float value = 0;
    // Start is called before the first frame update
    void Start()
    {
        //grab old position values
        double x = transform.position.x;
        double y = transform.position.y;
        double z = transform.position.z;
        Vector3 old_position = transform.position;

        //assign object new position values (either hardcode or Inspector Field)
        //transform.position = new Vector3(0, 0, 0);
        transform.position = startPosition;

        //this.name = "Player";
        Debug.Log("Hi my name is " + this.name);

    }

    float elapsed = 0f;
    int direction = 1;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.zero+(new Vector3(0,1,0)*(0.5f)*direction*Time.deltaTime); 
        //this happens every second
        elapsed += Time.deltaTime;
        if (elapsed >= 3f)
        {
            elapsed = elapsed % 1f;
            //this is what we do
            direction *= -1;
        }
        
    }

}
