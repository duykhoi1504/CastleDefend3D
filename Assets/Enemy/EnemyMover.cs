using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0f, 1f)] float speed = 1f;
    // Start is called before the first frame update
    Enemy enemy;
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
     void Start() {
        enemy = GetComponent<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    void FindPath()
    {
        path.Clear();
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = this.transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                // Debug.Log(travelPercent);
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        // Destroy(gameObject);
        enemy.StealGold();
        gameObject.SetActive(false);
        

    }
}
