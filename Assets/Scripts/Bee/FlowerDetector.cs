using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flower")
        {
            Debug.Log("Flower detected");
            transform.parent.GetComponent<Bee>().ApproachFlower(other.transform);
        }
    }
}
