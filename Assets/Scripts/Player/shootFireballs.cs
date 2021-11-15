using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootFireballs : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] linearBall linearball;
    [SerializeField] lobbedBall lobbedball;
    [SerializeField] float shotPerSecond;
    [SerializeField] Vector3 adjust;
    [SerializeField] float linearLoss;
    [SerializeField] float lobbedLoss;

    float currTime;
    void Start()
    {
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime >= shotPerSecond)
		{
            if (heatManager.hasEnough(linearLoss) && (Input.GetKey("z") || Input.GetKey("j")))
			{
                Instantiate(linearball, transform.position + adjust, Quaternion.identity);
                heatManager.loseHeat(linearLoss);
                currTime = 0;
			} else if (heatManager.hasEnough(lobbedLoss) && (Input.GetKey("x") || Input.GetKey("k")))
			{
                Instantiate(lobbedball, transform.position + adjust, Quaternion.identity);
                heatManager.gainHeat(lobbedLoss);
                currTime = 0;
            }
		}
    }
}
