using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTarget : MonoBehaviour
{
    Vector3 offset = new Vector3(0f, 0.5f, 0f);
    void Update()
    {
        move_target();
    }
    private void move_target(){
        if (Input.GetMouseButton(0)){
            Ray dir = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(dir, out raycastHit, Mathf.Infinity)){
                if (Vector3.Distance(transform.position, raycastHit.point) > 0.1f){
                    Vector3 offset = new Vector3(raycastHit.point.x, 0.5f, raycastHit.point.z);
                    transform.position = offset;
                }
			}
        }
    }
}