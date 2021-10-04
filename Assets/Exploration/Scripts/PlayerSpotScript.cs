using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSpotScript : MonoBehaviour
{

    private GameObject posNode; 
    public GameObject PosNode {
        get { return posNode; } 
        set { 
            posNode = value;
            transform.position = value.transform.position + new Vector3(0, 0, -2);
        }
    }

    public void MoveToNode(GameObject node)
    {
        if (posNode.GetComponent<NodeScript>().PosibleNodes.Contains(node))
        {
            PosNode = node;  
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
