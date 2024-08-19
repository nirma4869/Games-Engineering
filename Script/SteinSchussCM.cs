using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteinSchussCM : MonoBehaviour
{
    [SerializeField] public SteinSchuss steinSchuss;
    private Pathfinding pathfinding;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pathfinding = new Pathfinding(43, 25, 1, 1);
        steinSchuss = GetComponent<SteinSchuss>();
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
        pathfinding.GetGrid().GetXY(player.transform.position, out int x, out int y);
        List<PathNode> path = pathfinding.FindPath((int)steinSchuss.transform.position.x, (int)steinSchuss.transform.position.y, x, y);
    }
}
