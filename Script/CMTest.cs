using CodeMonkey.Utils;
using System.Collections.Generic;
using UnityEngine;

public class CMTest : MonoBehaviour
{
    [SerializeField] public CharacterPathfindingMovementHandler characterPathfinding;
    private Pathfinding pathfinding;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pathfinding = new Pathfinding(43, 25,10,14);
        for (int i = 7; i <= 10; i++)
        {
            for (int j = 5; j <= 8; j++)
            {
                pathfinding.GetNode(i, j).SetIsWalkable(!pathfinding.GetNode(i, j).isWalkable);
            }
        }
        for (int i = 7; i <= 10; i++)
        {
            for (int j = 15; j <= 17; j++)
            {
                pathfinding.GetNode(i, j).SetIsWalkable(!pathfinding.GetNode(i, j).isWalkable);
            }
        }
        for (int i = 30; i <= 33; i++)
        {
            for (int j = 15; j <= 17; j++)
            {
                pathfinding.GetNode(i, j).SetIsWalkable(!pathfinding.GetNode(i, j).isWalkable);
            }
        }
        for (int i = 30; i <= 33; i++)
        {
            for (int j = 5; j <= 8; j++)
            {
                pathfinding.GetNode(i, j).SetIsWalkable(!pathfinding.GetNode(i, j).isWalkable);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        /*
        
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
                    pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
                    List<PathNode> path = pathfinding.FindPath((int)characterPathfinding.transform.position.x, (int)characterPathfinding.transform.position.y, x, y);
                    if (path != null)
                    {
                        for (int i = 0; i < path.Count - 1; i++)
                        {

                            Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green, 50f);
                            Debug.Log("Ja");
                        }
                    }
                    characterPathfinding.SetTargetPosition(mouseWorldPosition);
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
                    pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
                    pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
                    Debug.Log("Weg");

                }
                */
        pathfinding.GetGrid().GetXY(player.transform.position, out int x, out int y);
        List<PathNode> path = pathfinding.FindPath((int)characterPathfinding.transform.position.x, (int)characterPathfinding.transform.position.y, x, y);
    }
}