using Assets.Exploration.Scripts.EntityStats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityPanelScript : MonoBehaviour
{
    private TMP_Text Name;
    private Transform Panel;

    private EntityStats entity;
    public EntityStats Entity { 
        get { return entity; } 
        set { entity = value;
            //UpdateShow();
        } }

    // Start is called before the first frame update
    void Start()
    {
        Name = transform.Find("Name").gameObject.GetComponent<TMP_Text>();
        Panel = transform.Find("PerkPanel");
    }

    public void UpdateShow()
    {
        Name.text = "Name: ";
        Name.text = "Name: "+Entity.name;
        for (int i=0; i<Entity.PerkManager.Perks.Count; i++)
        {
            //Entity.PerkManager.Perks[i];
        }
    }
}
