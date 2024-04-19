using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool isPlaceable;
    void OnMouseOver() {
       
       if (isPlaceable) {
         Debug.Log(this.transform.name);
       }
    }
}
