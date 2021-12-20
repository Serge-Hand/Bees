using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField]
    private int maxNectarCapacity = 10;
    [SerializeField]
    GameObject explosionPrefab;

    Animator animator;

    private int currentNectarCapacity;

    void Start()
    {
        currentNectarCapacity = maxNectarCapacity;
        animator = transform.GetChild(1).GetComponent<Animator>();
    }

    public void ConsumeNectar(int amount)
    {
        animator.SetTrigger("ConsumeTrigger");
        currentNectarCapacity -= amount;
        if (currentNectarCapacity <= 0)
            Die();
    }

    private void Die()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
