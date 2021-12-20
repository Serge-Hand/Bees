using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBehaviour : MonoBehaviour
{
    [Header("Main Properties")]
    [SerializeField]
    private int minBeeAttachPoints = 5;
    [SerializeField]
    private GameObject attachPointPrefab;

    [Header("Utility Properties")]
    [SerializeField]
    private float randSpreadX = 1f;
    //[SerializeField]
    //private float randSpreadY = 0f;
    [SerializeField]
    private float randSpreadZ = 1f;

    private List<GameObject> attachPoints;
    private int currentAttachPoint = 0;
    private int attachPointsAmount = 0;

    private int overallNectarAmount = 0;

    void Start()
    {
        GameEvents.instance.onAddNectar += AddNectar;
        GameEvents.instance.onSubstractNectar += SubstractNectar;
        GameEvents.instance.onAddBee += AddAttachPoint;

        attachPoints = new List<GameObject>();
        GenerateAttachPoints(minBeeAttachPoints);
    }

    private void AddNectar(int amount)
    {
        overallNectarAmount += amount;
    }

    private void SubstractNectar(int amount)
    {
        if (overallNectarAmount > 0)
            overallNectarAmount -= amount;
    }

    private void AddAttachPoint()
    {
        GenerateAttachPoints(1);
    }

    private void GenerateAttachPoints(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            attachPoints.Add(Instantiate(attachPointPrefab, GeneratePosition(transform.position), transform.rotation, transform));
            attachPointsAmount++;
        }
    }

    private Vector3 GeneratePosition(Vector3 centerPosition)
    {
        return centerPosition + new Vector3(
            Random.Range(-randSpreadX, randSpreadX), 
            0.5f, 
            Random.Range(-randSpreadZ, randSpreadZ));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bee")
        {
            if (currentAttachPoint < attachPointsAmount)
            {
                other.GetComponent<Bee>().AttachToSwarm(attachPoints[currentAttachPoint].transform);
                currentAttachPoint++;
            }
        }
    }
}
