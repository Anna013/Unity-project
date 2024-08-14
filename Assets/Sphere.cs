using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    public Rigidbody rb;
   
    public void useGravity(){
        rb.useGravity = true;
    }
}
