using Assets.Scripts;
using Assets.Scripts.CardScripts;
using Assets.Scripts.CardScripts.CardEffect;
using Assets.Scripts.CardScripts.CardEffect.CardAction;
using Assets.Scripts.EntityScripts;
using Assets.Scripts.EntityScripts.EnemyScripts;
using Assets.Scripts.Extensions;
using Assets.Scripts.PlayerScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandPlaceScript : MonoBehaviour, IDropHandler
{
    public PlayerEntity player;
    public IEnemy enemy;

    public DeckSpaceScript DrawSpace;
    public DeckSpaceScript DropSpace;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEntity>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Goblin>();
        DrawSpace = GameObject.Find("Draw Space").GetComponent<DeckSpaceScript>();
        DropSpace = GameObject.Find("Drop Space").GetComponent<DeckSpaceScript>();

        GameObject prefab = Resources.Load<GameObject>("Prefabs/Card");
        DrawSpace.cards = GetMockDeck();
        List<CardStats> Hand = DrawSpace.GetRandomList(4);
        InstansiateHand(Hand);
    }

    public void OnDrop(PointerEventData eventData)
    {
        CardDropScript card = eventData.pointerDrag.GetComponent<CardDropScript>();

        if (card)
            card.DefaultParent = transform;
    }

    public void NextTurn()
    {
        enemy.NextTurn();
        player.NextTurn();
        

        List<Transform> children = gameObject.transform.GetAllChildren();
        for (int i = 0; i < children.Count; i++)
        {
            DropSpace.Add(children[i].GetComponent<CardDropScript>().Stats);
            Destroy(children[i].gameObject);
        }
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Card");
        List<CardStats> Hand;
        int DrawCount = DrawSpace.cards.Count;
        if (DrawCount < 4) 
        {
            Hand = DrawSpace.GetRandomList(DrawCount);
            DrawSpace.Add(DropSpace.GetRandomAll());
            Hand.AddRange(DrawSpace.GetRandomList(4 - DrawCount));
        }
        else
        {
            Hand = DrawSpace.GetRandomList(4);
        }
        InstansiateHand(Hand);
    }
    
   
    public List<CardStats> GetMockDeck()
    {

        

        CardStats Throw = new CardStats("Throw",
            "Does 5 damage",
            new BasicCardCost(2),
            new CustomEffect(
                new List<Func<IEntity, List<IEntity>, List<int>, bool>>{
                    SimpleActions.Damage
                }, 
                new List<List<int>> { 
                    new List<int>
                    {
                        5
                    }
                }));
        CardStats PowerPunch = new CardStats("PowerPunch",
            "Does 7 damage",
            new BasicCardCost(2),
            new CustomEffect(
                new List<Func<IEntity, List<IEntity>, List<int>, bool>>{
                    SimpleActions.Damage
                },
                new List<List<int>> {
                    new List<int>
                    {
                        7
                    }
                }));
        CardStats PerciseHit = new CardStats("Throw",
            "Does 20 damage",
            new BasicCardCost(7),
            new CustomEffect(
                new List<Func<IEntity, List<IEntity>, List<int>, bool>>{
                    SimpleActions.Damage
                },
                new List<List<int>> {
                    new List<int>
                    {
                        20
                    }
                }));


        List<CardStats> MockDeck = new List<CardStats>
        {
            Throw,
            Throw,
            PowerPunch,
            PowerPunch,
            PerciseHit,
            PerciseHit,
        };

        return MockDeck;
    }

    public void InstansiateHand(List<CardStats> MockDeck)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Card");
        for (int i = 0; i < MockDeck.Count; i++)
        {
            GameObject gameObject = Instantiate(prefab);
            gameObject.GetComponent<CardDropScript>().Stats = MockDeck[i];
            gameObject.transform.SetParent(transform, false);
        }
    }
}
