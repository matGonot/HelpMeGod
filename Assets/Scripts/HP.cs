using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float healthPoint;
    public GameObject smoke;
    public GameObject spark;
    public GameObject spark2;
    float initHp;
    private void Start()
    {
        initHp = healthPoint;
        smoke.SetActive(false);
        spark.SetActive(false);
        spark2.SetActive(false);
    }
    public void getDamaged(float dmg)
    {
        healthPoint -= dmg;
        spark.SetActive(true);
        if (healthPoint <= initHp / 2)
        {
            spark2.SetActive(true);
            Debug.Log(gameObject.name + " 2 step");
        }
        if(healthPoint <= 0)
        {
            smoke.SetActive(true);
            Debug.Log(gameObject.name + " destroyed");
        }
    }
}
