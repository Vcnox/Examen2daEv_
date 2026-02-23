using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    private bool isMoving;

    [Header("Bullet Configuration")]
    [SerializeField] private float maxLifeTime = 3f;
    [SerializeField] private int damage = 10;

    private float currentLifeTime;
    private ObjectPool pool;



    private void OnEnable()
    {
        currentLifeTime = 0f;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving) return;

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        currentLifeTime += Time.deltaTime;

        if(currentLifeTime >= maxLifeTime)
        {
            ReturnToPool();
        }
    }
    public void Shoot(Vector3 force)
    {
        direction = force.normalized;
        speed = force.magnitude;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

            Debug.Log($"¡Impacto! Damage: {damage}");

            ReturnToPool();


        }

        else if (other.CompareTag("Wall"))
        {
            ReturnToPool();
        }

        void ReturnToPool()
        {
            isMoving = false;

            GunController gun = FindObjectOfType<GunController>();
            gameObject.SetActive(false);
        }

    }
}
