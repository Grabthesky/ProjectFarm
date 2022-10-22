using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTransformer : MonoBehaviour
{
    
    public bool rotate = false;

    public Vector3 rotationSpeed;

    private void Update() {
        if(rotate){
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationSpeed);
        }
    }
    
}
