using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misiles : MonoBehaviour
{
    public float height;
    private Vector3 origin;
    public GameObject player;
    public float speed;
    bool isPointed = false;
    Vector3 targetPos;
    private void Start()
    {
        origin = transform.position;
    }
    void Launch()
    {
        transform.Translate(new Vector3(origin.x, origin.y + height, origin.z) * speed * Time.deltaTime);
    }
    void Point()
    {
        Vector3 relativePos = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.down);
        transform.rotation = rotation;
        targetPos = player.transform.position;
        isPointed = true;
    }
    void Fire()
    {
        Debug.Log(targetPos);
        transform.Translate(targetPos * Time.deltaTime * 2);
    }
    private void Update()
    {
        if (isPointed)
        {
            Fire();
        }
        else if (transform.position.y > height)
        {
            Point();
        }
        else
        {
            Launch();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new Vector3(origin.x, origin.y + height, origin.z), 2);
    }
}
