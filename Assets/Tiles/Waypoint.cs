using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
   // Start is called before the first frame update
   [SerializeField] bool isPlaceable;
   [SerializeField] GameObject towerPrefab;

   public bool IsPlaceable
   {
      get
      {
         return isPlaceable;
      }

   }
   void OnMouseDown()
   {

      if (isPlaceable)
      {
         Instantiate(towerPrefab, transform.position, Quaternion.identity);
         isPlaceable = false;
      }
   }
}
