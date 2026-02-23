using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTarget : MonoBehaviour
{

    public int health = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            health--;
            Destroy(this.gameObject);
        }
    }

}
