using Assets.Scripts.DropScripts;
using Assets.Scripts.EntityScripts;
using Assets.Scripts.EntityScripts.EnemyScripts;
using Assets.Scripts.PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyPlayPlaceScript : MonoBehaviour, IDropHandler
{
    public IEnemy enemy;
    
    public PlayerEntity player;
    public DeckSpaceScript DropSpace;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
        DropSpace = GameObject.Find("Drop Space").GetComponent<DeckSpaceScript>();
        enemy = GetComponent<Goblin>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        CardDropScript card = eventData.pointerDrag.GetComponent<CardDropScript>();

        if (card)
        {
            if (player.PlayCard(card, player, enemy))
            {
                DropSpace.Add(card.Stats);
            }
        }
    }
}
