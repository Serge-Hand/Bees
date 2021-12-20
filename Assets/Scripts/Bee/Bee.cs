using System.Collections;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [Header("Main Properties")]
    [SerializeField]
    private float followSpeed = 1f;
    [SerializeField]
    private int maxNectarAmount = 5;
    [SerializeField]
    private int nectarPerSecond = 1;
    [SerializeField]
    private Transform beeObj;

    [Header("Utility Properties")]
    [SerializeField]
    private float swarmStopRange = 0.3f;
    [SerializeField]
    private float flowerStopRange = 0.3f;
    [SerializeField]
    private float maxDistanceFromSwarm = 2f;

    private Transform swarmAttachPoint;
    private Transform currentFlower;

    private bool isWaiting = false;
    private bool isGivingNectar = false;

    private int curNectarAmount = 0;

    void Start()
    {
        GameEvents.instance.onCollectHoney += GiveNectarAway;
        GameEvents.instance.onStopCollectHoney += StopGiveNectarAway;
        GameEvents.instance.onSpeedUp += SpeedUp;
    }

    private void GiveNectarAway()
    {
        currentFlower = null;
        StartCoroutine(StartGivingNectar());
    }

    private void StopGiveNectarAway()
    {
        isGivingNectar = false;
    }

    IEnumerator StartGivingNectar()
    {
        isGivingNectar = true;
        while (isGivingNectar && curNectarAmount > 0)
        {
            curNectarAmount -= 1;
            beeObj.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            GameEvents.instance.SubstractNectar(1);
            yield return new WaitForSeconds(Random.Range(0.2f, 0.8f));
        }
        isGivingNectar = false;
    }

    private void SpeedUp()
    {
        followSpeed += 1f;
    }

    void Update()
    {
        if (swarmAttachPoint)
        {
            if (!currentFlower || curNectarAmount >= maxNectarAmount)
            {
                MoveToObject(swarmAttachPoint, swarmStopRange);
            }
            else
            {
                if (!MoveToObject(currentFlower.GetChild(0), flowerStopRange))
                {
                    if ((transform.position - swarmAttachPoint.position).magnitude > maxDistanceFromSwarm)
                    {
                        StartCoroutine(FollowWait());
                    }
                    else if (!isWaiting)
                    {
                        currentFlower.GetComponent<Flower>().ConsumeNectar(nectarPerSecond);
                        GameEvents.instance.AddNectar(1);

                        curNectarAmount++;
                        beeObj.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                        Debug.Log(gameObject.name + "'s current nectar: " + curNectarAmount);

                        if (!(curNectarAmount >= maxNectarAmount))
                            StartCoroutine(Wait(Random.Range(0.2f, 0.8f)));
                        else
                            StartCoroutine(FollowWait());
                    }
                }
            }
        }
    }

    private bool MoveToObject (Transform obj, float stopRange)
    {
        if ((transform.position - obj.position).magnitude > stopRange)
        {
            transform.LookAt(obj);
            transform.Translate(0f, 0f, followSpeed * Time.deltaTime);
            return true;
        }
        return false;
    }

    IEnumerator FollowWait()
    {
        currentFlower = null;
        yield return new WaitForSeconds(1.5f);
        //transform.GetChild(0).gameObject.SetActive(true);
    }

    IEnumerator Wait(float seconds)
    {
        isWaiting = true;
        yield return new WaitForSeconds(seconds);
        isWaiting = false;
    }

    public void AttachToSwarm(Transform attachPoint)
    {
        swarmAttachPoint = attachPoint;
        GetComponent<Collider>().enabled = false;

        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ApproachFlower (Transform flower)
    {
        if (curNectarAmount <= maxNectarAmount)
        {
            //transform.GetChild(0).gameObject.SetActive(false);
            currentFlower = flower;
        }
    }
}
