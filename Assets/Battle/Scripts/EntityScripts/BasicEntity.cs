using Assets.Scripts.EntityScripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicEntity : MonoBehaviour, IEntity
{
    public Slider HpBar;

    public TMP_Text HpCounter;

    public TMP_Text BlockCounter;
    public TMP_Text ParryCounter;
    public TMP_Text DodgeCounter;

    public bool IsPlayer { get; set; }
    public int MaxHp { get; set; }
    public int Hp { get; set; }
    
    public int Block { get; set; }
    public int ParryPoints { get; set; }
    public int DodgePoints { get; set; }

    public GameObject damageTextPrefab { get; set; }
    

    void Awake()
    {
        HpBar = transform.Find("HpBar").GetComponent<Slider>();
        HpCounter = transform.Find("HpCounter").GetComponent<TMP_Text>();
        damageTextPrefab = Resources.Load<GameObject>("Prefabs/DamageText");
        
    }

    // Update is called once per frame
    void Update()
    {
        HpBar.maxValue = MaxHp;
        HpBar.value = Hp;
        HpCounter.text = Hp + "/" + MaxHp;

    }
    public void ShowDamageNumber(int value)
    {
        GameObject damageText = Instantiate(damageTextPrefab, transform);
        damageText.GetComponent<DamageNumberScript>().text = ""+value;    
    }


}
