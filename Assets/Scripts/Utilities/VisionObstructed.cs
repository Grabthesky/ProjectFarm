using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionObstructed : MonoBehaviour
{

    public float sphereSize = 3f;
    public float growSpeed = 3f;
    public LayerMask layerMask;

    private bool isSphere = false;
    private bool changeSize = true;
    
    private void Update() {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.gameObject.transform.position, (transform.position - Camera.main.gameObject.transform.position).normalized, out hit, Mathf.Infinity, layerMask)){
            if(hit.collider.gameObject.tag == "Spheremask"){
                //Debug.Log("Sphere");
                if(!isSphere){
                    isSphere = true;
                    changeSize = true;
                }
            }else{
                //Debug.Log("Wall");
                if(isSphere){
                    isSphere = false;
                    changeSize = true;
                }
            }
        }

        if(changeSize){
            if(isSphere){
                if(transform.localScale != Vector3.zero){
                    transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, growSpeed * Time.deltaTime);
                }else{
                    changeSize = false;
                }
            }else{
                if(transform.localScale != Vector3.one * sphereSize){
                    transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * sphereSize, growSpeed * Time.deltaTime);
                }else{
                    changeSize = false;
                }
            }
        }
    }
    
}
