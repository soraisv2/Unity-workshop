using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    private Gun gunScript;

    private Rigidbody rb;
    private BoxCollider coll;
    public Transform player, gunContainer;
    
    private Transform cam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        gunScript = GetComponent<Gun>();
        cam = gunScript.playerCam.transform;
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<BoxCollider>();

        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        if (equipped && Input.GetKeyDown(KeyCode.A)) Drop();
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        transform.SetParent(gunContainer);
        // transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, 10f * Time.deltaTime);
        transform.localPosition = Vector3.zero;
        // transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, 10f * Time.deltaTime);
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
        rb.isKinematic = true;
        coll.isTrigger = true;

        GetComponent<Gun>().enabled = true;
        transform.GetChild(0).GetComponent<AnimDelay>().enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);

        float random = Random.Range(-5f, 5f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        GetComponent<Gun>().enabled = false;
        transform.GetChild(0).GetComponent<AnimDelay>().enabled = false;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickUpRange);
    }
}
