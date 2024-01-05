using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignFormation : MonoBehaviour
{
    List<GameObject> unityGameObjects = new List<GameObject>();
    [SerializeField] GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        unityGameObjects.Add(GameObject.FindWithTag("Player1"));
        unityGameObjects.Add(GameObject.FindWithTag("Player2"));
        unityGameObjects.Add(GameObject.FindWithTag("Player3"));
        unityGameObjects.Add(GameObject.FindWithTag("Player4"));
    }

    // Update is called once per frame
    void Update()
    {
        formation();
    }
    
    private void formation()
    {
        float[] distances = new float[5];
        int[] sortedIndices = new int[5];

        for (int i = 0; i < unityGameObjects.Count; i++)
        {
            distances[i] = Vector3.Distance(unityGameObjects[i].transform.position, target.transform.position);
            sortedIndices[i] = i;
        }

        System.Array.Sort(distances, sortedIndices);

        for (int i = 0; i < 4; i++)
        {
            unityGameObjects[sortedIndices[i + 1]].tag = i == 0 ? "Leader" : i == 1 ? "Wingman" : i == 2 ? "ElementLead" : "ElementWing";
        }
    }
}
