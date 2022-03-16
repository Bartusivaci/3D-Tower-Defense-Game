using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitDuration = 1f;
    [SerializeField] float yOffset = 5f;

    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        Vector3 addOffset = new Vector3(0f, yOffset, 0f);
        foreach (Waypoint waypoint in path)
        {
            //transform.position = waypoint.transform.position + addOffset;
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position + addOffset;
            float travelPercent = 0f;
            
            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
