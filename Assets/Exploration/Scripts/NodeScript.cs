using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;

    public GameObject[] PosibleNodes;  

    private int type;
    public int Type { 
        get { return type; } 
        set { 
            type = value;
            SpriteRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
            Sprite icon;
            if (value == 1)
            {
                icon = Resources.Load<Sprite>("ExplorationIcons/BattleIcon");
            }
            else
            {
                icon = Resources.Load<Sprite>("ExplorationIcons/Coin");
            }
            
            SpriteRenderer.sprite = icon;
        } 
    }

    public Func<int> action; 

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        GameObject.Find("PlayerSpot").GetComponent<PlayerSpotScript>().MoveToNode(gameObject);
        //Destroy(gameObject);
    }

    
}
