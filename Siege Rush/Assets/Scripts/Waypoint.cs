using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject towerPrefab;
    [SerializeField] float towerOffset = 5f;

    

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Vector3 addOffset = new Vector3(0f, towerOffset, 0f);
            Instantiate(towerPrefab, transform.position + addOffset, Quaternion.identity);
            isPlaceable = false;
        }
        

    }
}
