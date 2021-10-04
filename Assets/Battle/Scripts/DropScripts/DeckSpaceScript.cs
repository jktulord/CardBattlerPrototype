using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckSpaceScript : MonoBehaviour
{
    private TMP_Text Counter;

    public List<CardStats> cards;
    void Start()
    {
        Counter = transform.Find("Counter").gameObject.GetComponent<TMP_Text>();
        cards = new List<CardStats>();
    }

    // Update is called once per frame
    public void Add(List<CardStats> newCards)
    {
        cards.AddRange(newCards);
        UpdateCounter();
    }
    public void Add(CardStats newCard)
    {
        cards.Add(newCard);
        UpdateCounter();
    }

    public CardStats GetRandom()
    {
        int number = Random.Range(0, cards.Count);
        CardStats returnCard = cards[number];
        cards.RemoveAt(number);
        UpdateCounter();
        return returnCard;
    }

    public List<CardStats> GetRandomList(int amount)
    {
        List<CardStats> returnCards = new List<CardStats>();
        for (int i = 0; i < amount; i++)
        {
            returnCards.Add(GetRandom());
        }
        return returnCards;
    }
    public List<CardStats> GetRandomAll()
    {
        List<CardStats> returnCards = new List<CardStats>();
        int count = cards.Count;
        for (int i = 0; i < count; i++)
        {
            returnCards.Add(GetRandom());
        }
        return returnCards;
    }

    public void UpdateCounter()
    {
        Counter = transform.Find("Counter").gameObject.GetComponent<TMP_Text>();
        Counter.text = "" + cards.Count;
    }
}
