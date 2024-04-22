using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
   // Start is called before the first frame update
   [SerializeField] bool isPlaceable;
   [SerializeField] Tower towerPrefab;

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
         bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
         isPlaceable = !isPlaced;
      }
   }
}
