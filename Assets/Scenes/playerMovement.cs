using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float radiusOfSatisfaction;
    private float moveDistance = 1.0f;
    private Vector3 variation = new Vector3();
    [SerializeField] private Transform myTransform;
    [SerializeField] float moveSpeed;
    [SerializeField] private Transform targetTransform;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        radiusOfSatisfaction = 1.25f;
    }

    //void fixedUpdate(){
      //  rb.AddForce(moveSpeed);
    //}
    // Update is called once per frame
    void Update()
    {
        RunKinematicArrive();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameObject obstacleObject = GameObject.FindGameObjectWithTag("Obstacle");
            if (obstacleObject != null)
            {
                AvoidObstacles(obstacleObject);
            }
        }
    }
        void AvoidObstacles(GameObject obstacle)
    {
        // Get the obstacle's position and dimensions
        Vector3 obstaclePosition = obstacle.transform.position;
        float obstacleSize = 2f;

        // Get the player's current position
        Vector3 playerPosition = transform.position;

        // Determine the direction to move the player based on the obstacle's position
        Vector3 moveDirection = (playerPosition - obstaclePosition).normalized;

        // Move the player to a new position
        transform.position += moveDirection * moveDistance;
    }

    // If target is above current pos, x goes neg
    // If target is below current pos, x goes pos

    private void RunKinematicArrive() {
        Vector3 towardsTarget = targetTransform.position - myTransform.position + changeAxis(formationVariation());// adds difference in transform to maintain finger four

        if (towardsTarget.magnitude <= radiusOfSatisfaction) {
            return;
        }

        towardsTarget = towardsTarget.normalized;

        Quaternion targetRotation = Quaternion.LookRotation(towardsTarget);
        myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRotation, 0.1f);

        Vector3 newPosition = myTransform.position;
        newPosition += myTransform.forward * moveSpeed * Time.deltaTime;


        myTransform.position = newPosition;
    }

    private Vector3 formationVariation() {
        if (gameObject.tag == "Leader") {
            variation = Vector3.zero;
        }
        else if (gameObject.tag == "Wingman"){
            variation = new Vector3(-1.5f, 0f, -1f);
        }
        else if (gameObject.tag == "ElementLead"){
            variation = new Vector3(1.5f, 0f, -1f);
        }
        else if (gameObject.tag == "ElementWing"){
            variation = new Vector3(3f, 0f, -2f);
        }
        else {
            variation = Vector3.zero;
        }
        return variation;
    }

    private Vector3 changeAxis(Vector3 formVar){
        if (targetTransform.position.z < myTransform.position.z) {
            variation = new Vector3(formVar.x * -1, formVar.y, formVar.z);
        }
        return formVar;
    }
}
