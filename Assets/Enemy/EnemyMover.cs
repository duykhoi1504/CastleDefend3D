using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Waypoint> path= new List<Waypoint>();
    [SerializeField] float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator FollowPath(){
        foreach (Waypoint waypoint in path){
            Vector3 startPosition=this.transform.position;
            Vector3 endPosition=waypoint.transform.position;
            float travelPercent=0f;

            transform.LookAt(endPosition);
            while(travelPercent < 1f ){
                travelPercent+=Time.deltaTime;
                Debug.Log(travelPercent);
                transform.position =Vector3.Lerp(startPosition,endPosition,travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

    }
}
