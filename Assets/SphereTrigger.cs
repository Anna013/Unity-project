using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrigger : MonoBehaviour
{

     public Sphere[] spheres;
    
    public void OnTriggerEnter(){
        Debug.Log("triger is on " );
        foreach(Sphere s in spheres){
            Debug.Log("triger is on" + s.name);
            s.useGravity();
        }
    }

}
    
