using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraTargetSwitcher : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 3.5f;
    public Vector3 cameraOffset = new Vector3(0, 10, -10);

    public static CameraTargetSwitcher Instance;

    private GameObject lastTarget;

    private void OnValidate() {
        if(target != null){
            transform.position = target.transform.position + cameraOffset;
            transform.LookAt(target.transform);
        }
    }

    private void Update() {
        if(target != null){
            transform.position = Vector3.Lerp(transform.position, target.transform.position + cameraOffset, moveSpeed * Time.deltaTime);
        }
    }
}
