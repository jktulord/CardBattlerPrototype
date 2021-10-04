using Assets.Exploration.Scripts.EntityStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationScript : MonoBehaviour
{
    public PlayerSpotScript Player;
    public List<EntityStats> Enemies;
    public List<List<GameObject>> Nodes;

    public EntityPanelScript DebugThing;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerSpot").GetComponent<PlayerSpotScript>();
        
        //GenerateBranch(curRow, 5);
        GenerateFloor();

        Enemies = new List<EntityStats>();
        Enemies.Add(new EntityStats());
        DebugThing.Entity = Enemies[0];
        DebugThing.UpdateShow();
    }


    void GenerateFloor(int Length = 5)
    {
        //Load
        GameObject Node = Resources.Load<GameObject>("Prefabs/Exploration/Node");
        GameObject Line = Resources.Load<GameObject>("Prefabs/Exploration/Line");
        
        //First node
        List<GameObject> curFloor = new List<GameObject>();
        curFloor.Add(Instantiate(Node, transform.position, transform.rotation, transform));
        Player.PosNode = curFloor[0];
        for (int i = 1; i < Length; i++)
        {
            curFloor.Add(Instantiate(Node, transform.position + new Vector3(3 * i,0), transform.rotation, transform));
            
            GameObject line = Instantiate(Line, curFloor[i-1].transform);
            line.GetComponent<LineRenderer>().SetPositions(new Vector3[2] { new Vector3(0, 0, -1), new Vector3(3 * i, 0, -1) });
            NodeScript prevNode = curFloor[i-1].GetComponent<NodeScript>();
            prevNode.PosibleNodes = new GameObject[1] { curFloor[i] };

            NodeScript curNode = curFloor[i].GetComponent<NodeScript>();
            curNode.Type = Random.Range(0, 2);
        }
    }

    /*
    List<GameObject> GenerateBranch(List<GameObject> curRow, int amount = 3)
    {
        List<GameObject> nextRow = new List<GameObject>();
        GameObject Node = Resources.Load<GameObject>("Prefabs/Node");
        GameObject Line = Resources.Load<GameObject>("Prefabs/Line");

        for (int i = 0; i < amount; i++)
        {
            Vector3 DefNodeVector = new Vector3( (float)-((amount-1) * 3) / 2, 3);

            nextRow.Add(Instantiate(Node, transform.position + new Vector3((float)3 * i, 0) + DefNodeVector, transform.rotation, transform));
            GameObject line = Instantiate(Line, curRow[0].transform);
            line.GetComponent<LineRenderer>().SetPositions(new Vector3[2] { new Vector3(0, 0, -1), new Vector3((float)3 * i, 0) + DefNodeVector });
        } 
        

        return nextRow;
    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
