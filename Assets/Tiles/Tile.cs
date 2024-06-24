using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
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
   Pathfinder pathfinder;

      GridManager gridManager;
      Vector2Int coordinates= new Vector2Int();
    void Awake() {
      gridManager=FindObjectOfType<GridManager>();
      pathfinder=FindObjectOfType<Pathfinder>();
   }
   void Start(){
      if(gridManager!=null)
      {
         coordinates=gridManager.GetCoordinatesFromPositive(this.transform.position); 
         if(!isPlaceable){
            gridManager.BlockNode(coordinates);
         }
      }
   }
   void OnMouseDown()
   {

      if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.willBlockPath(coordinates))
      {
         bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
         isPlaceable = !isPlaced;
         gridManager.BlockNode(coordinates);
      }
   }
}
