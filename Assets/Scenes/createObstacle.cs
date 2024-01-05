using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_obstacle : MonoBehaviour
{
	public GameObject prefab;
	Vector3 vectorOffset = new Vector3(0, 2f, 0);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // creates ray to mouse button click
			RaycastHit raycastHit;

			if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity)){

				Instantiate(prefab, raycastHit.point + vectorOffset, Quaternion.identity); // Instantiate method initiation to create already made object

			}
		}
    }
}