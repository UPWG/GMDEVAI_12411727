using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp = 10;
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        hpSlider.maxValue = maxHp;
        hpSlider.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    public void TakeDamage()
    {
        hp--;
        hpSlider.value = hp;
    }
}
