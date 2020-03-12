using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public Camera fpscam;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit))
        {
            if(hit.transform.tag == "Enemy")
            {
                hit.transform.gameObject.GetComponent<HP>().getDamaged(damage);
                Debug.Log(hit.transform.name + " touched !");
            }
        }
    }

}
