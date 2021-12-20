using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hive : MonoBehaviour
{
    [SerializeField]
    private int maxNectarLevel = 20;
    [SerializeField]
    TextMeshPro nectarText;
    [SerializeField]
    Transform hiveObj;
    [SerializeField]
    GameObject explosionPrefab;

    private int curNectarLevel;
    private Vector3 initialScale;

    private void Start()
    {
        GameEvents.instance.onSubstractNectar += SubstractNectar;

        curNectarLevel = maxNectarLevel;
        nectarText.SetText(curNectarLevel.ToString());

        initialScale = hiveObj.localScale;
    }

    private void SubstractNectar(int amount)
    {
        curNectarLevel -= amount;
        Debug.Log($"Hive nectar level: {curNectarLevel}");

        if (curNectarLevel <= 0)
        {
            GameEvents.instance.LevelUp();

            curNectarLevel = maxNectarLevel;
            hiveObj.localScale = initialScale;

            Instantiate(explosionPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
        }
        else
            hiveObj.localScale += new Vector3(1, 1, 1);

        nectarText.SetText(curNectarLevel.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Start collecting honey");
            GameEvents.instance.CollectHoney();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Stop collecting honey");
            GameEvents.instance.StopCollectHoney();
        }
    }
}
