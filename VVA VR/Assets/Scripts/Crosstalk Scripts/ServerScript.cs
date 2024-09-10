
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ServerScript : MonoBehaviour
{
    public PlayerScript attachedPlayerScript;
    
    //instantiating GameObject "go" to find later by name 
    GameObject go;
    //ditto for flame
    GameObject flame;
    void Start()
    {
        go = GameObject.Find("Player");
        Debug.Log("I found " + go.name);

        float value = attachedPlayerScript.value;
        Debug.Log("The value of the Player is " + value);

        //finding flame object
        flame = this.transform.GetChild(0).gameObject;
        Debug.Log("The value of the Flame is " + flame.name);
        Debug.Log("The scale of the Flame is " + flame.transform.localScale);

    }

    void Update()
    {
        flame.transform.localScale = Vector3.one*go.transform.position.magnitude*1.5f;

    }
}