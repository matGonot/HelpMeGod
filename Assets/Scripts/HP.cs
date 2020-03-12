using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float healthPoint;
    public GameObject smoke;
    private void Start()
    {
        smoke.SetActive(false);
    }
    public void getDamaged(float dmg)
    {
        healthPoint -= dmg;
        if(healthPoint <= 0)
        {
            smoke.SetActive(true);
            Debug.Log(gameObject.name + " destroyed");
        }
    }
}
