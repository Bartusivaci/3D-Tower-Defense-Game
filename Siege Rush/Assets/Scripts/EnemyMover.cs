using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float yOffset = 5f;
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

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

            float rotationDegrees = degreesToRotate(this.transform.forward, startPosition, endPosition);



            while(travelPercent < 1f)
            {
                if (travelPercent < 0.25f)
                {
                    float rotationAngle = 4 * rotationDegrees * Time.deltaTime * speed;
                    this.transform.Rotate(new Vector3(0, rotationAngle, 0));
                }
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }


    float degreesToRotate(Vector3 currentDir, Vector3 currentPosition, Vector3 endPosition)
    {
        Vector3 targetDir = endPosition - currentPosition;
        return Vector3.SignedAngle(currentDir, targetDir, Vector3.up);
    }
}
