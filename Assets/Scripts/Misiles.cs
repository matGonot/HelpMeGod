using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misiles : MonoBehaviour
{
    public float height;
    public GameObject player;
    public float speed;
    public float offsetSign;
    private Vector3 origin;
    bool isPointed = false;
    Vector3 targetPos;
    public GameObject pointLight;
    public float explosionRadius;
    public LayerMask playerLayer;
    private void Start()
    {
        origin = transform.position;
        pointLight.SetActive(false);
    }
    void Launch()
    {
        transform.Translate(new Vector3(origin.x, origin.y + height, origin.z) * speed * Time.deltaTime);
        targetPos = player.transform.position;
        pointLight.SetActive(true);
        pointLight.transform.position = new Vector3(targetPos.x, targetPos.y + offsetSign, targetPos.z);
    }
    void Point()
    {
        Vector3 relativePos = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.down);
        transform.rotation = rotation;
        isPointed = true;

    }
    void Fire()
    {
        Debug.Log(targetPos);
        transform.Translate(targetPos * Time.deltaTime * speed);
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
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Ground")
        {
            RaycastHit hit;
            Physics.SphereCast(transform.position, explosionRadius, Vector3.zero, out hit, playerLayer.value);
            Debug.Log(hit.transform.name);
            Destroy(pointLight);
            Destroy(gameObject);
        }
    }
}
