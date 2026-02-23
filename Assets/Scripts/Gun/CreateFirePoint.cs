using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFirePoint : MonoBehaviour
{


    [Header("FirePint Configuration")]
    [SerializeField] private Vector3 firePointPosition = new Vector3(0, 0.5f, 1f);
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateFirePointAtPosition()
    {
        Transform existingFirePoint = transform.Find("FirePoint");

        if(existingFirePoint == null)
        {
            GameObject firePoint = new GameObject("FirePoint");
            firePoint.transform.parent = transform;


            firePoint.transform.localPosition = firePointPosition;


            firePoint.transform.localRotation = Quaternion.identity;

            Debug.Log("FirePoint created in: " + firePointPosition);
            Debug.Log("FirePoint created in: " + firePointPosition);

        }
        else
        {
            Debug.Log("FirePoint already exist");
        }

        void OnDrawGizmosSelected()
        {
            Transform firePoint = transform.Find("FirePoint");
            if(firePoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(firePoint.position, 0.1f);
                Gizmos.DrawRay(firePoint.position, firePoint.forward * 2f);

            }
        }
    }
}
