using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] Vector2Int startCoordinates;
     public Vector2Int StartCoordinates{get{return startCoordinates;}}
    [SerializeField] Vector2Int destinationCoordinates;
public Vector2Int DestinationCoordinates{get{return startCoordinates;}}
    Node startNode;
    Node destinationNode;
      [SerializeField] Node currentSearchNode;
    
    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid=new Dictionary<Vector2Int, Node>();

    void Awake() 
    {
      gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null){

            grid = gridManager.Grid;
            startNode = grid[startCoordinates];
            destinationNode =  grid[destinationCoordinates];
    
        }
   }

    void Start()
    {
       
        GetNewPath();
    }

public List<Node> GetNewPath(){
    gridManager.RestNodes();
        BreadthFirstSearch();
       return BuildPath();
}

    // Update is called once per frame
    void ExploreNeigbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;
            if (grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);
                // grid[neighborCoords].isExplord = true;
                // grid[currentSearchNode.coordinates].isPath = true;
            }

        }
        foreach(Node neighbor in neighbors){
            if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                neighbor.connectedTo=currentSearchNode;
                reached.Add(neighbor.coordinates,neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    void BreadthFirstSearch()
    {
                startNode.isWalkable=true;
            destinationNode.isWalkable=true;

        frontier.Clear();
        reached.Clear();

        bool isRunning=true;
        frontier.Enqueue(startNode);
        reached.Add(startCoordinates,startNode);
        while(frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplord=true;
            ExploreNeigbors();
            if(currentSearchNode.coordinates==destinationCoordinates){
                isRunning = false;
            }
        }
    }

    List<Node> BuildPath()
    {
        List<Node> path= new List<Node>();
        Node currentNode = destinationNode;
        path.Add(currentNode);
        currentNode.isPath=true;
        
        while(currentNode.connectedTo !=null){
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath=true;
        }
        path.Reverse();
        return path;
    }

    public bool willBlockPath(Vector2Int coordiantes)
    {
        if (grid.ContainsKey(coordiantes)){
            bool previousState= grid[coordiantes].isWalkable;
            grid[coordiantes].isWalkable=false;
            List<Node> newPath= GetNewPath();
            grid[coordiantes].isWalkable=previousState;
            
            if(newPath.Count <=1)
            {
                GetNewPath();
                return true;
            }
          
        }
          return false;
    }
}
