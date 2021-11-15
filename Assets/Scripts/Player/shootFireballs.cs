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
    [SerializeField] int linearCost;
    [SerializeField] int lobbedCost;

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
            if (fuelManager.Instance.hasEnough(linearCost) && (Input.GetKey("z") || Input.GetKey("j") || Input.GetMouseButtonDown(0)))
			{
                Instantiate(linearball, transform.position + adjust, Quaternion.identity);
                fuelManager.Instance.lose(linearCost);
                currTime = 0;
			} else if (fuelManager.Instance.hasEnough(lobbedCost) && (Input.GetKey("x") || Input.GetKey("k") || Input.GetMouseButtonDown(1)))
			{
                Instantiate(lobbedball, transform.position + adjust, Quaternion.identity);
                fuelManager.Instance.lose(lobbedCost);
                currTime = 0;
            }
		}
    }
}
