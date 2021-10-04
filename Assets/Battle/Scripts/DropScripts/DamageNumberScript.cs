using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumberScript : MonoBehaviour
{
    private TMP_Text Number;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        Number = GetComponent<TMP_Text>();
        Number.text = text;
    }

    // Update is called once per frame
    void Update()
    {
        Number.alpha -= 1 * Time.deltaTime;
        transform.position += new Vector3(0,1) * Time.deltaTime;
        if (Number.alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
