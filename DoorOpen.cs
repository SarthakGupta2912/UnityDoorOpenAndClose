using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float rotateSpeed = 50;
    [SerializeField] Vector3 endRotationPoint;

    private Vector3 startRotationPoint;
 
    // Start is called before the first frame update
    void Start()
    {
        startRotationPoint = this.transform.localEulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) <= 2f)
        {
            this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, Quaternion.Euler(endRotationPoint), rotateSpeed * Time.deltaTime);
            player.GetComponent<CapsuleCollider>().isTrigger = true;
        }

        else
        {
            this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, Quaternion.Euler(startRotationPoint), rotateSpeed * Time.deltaTime);
            player.GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }
}
