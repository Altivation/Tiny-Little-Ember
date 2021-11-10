using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootFireballs : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] linearBall linearball;
    [SerializeField] lobbedBall lobbedball;
    [SerializeField] float rateOfFire;
    [SerializeField] Vector3 spawnAdjust;
    float currTime;
    void Start()
    {
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime >= rateOfFire)
		{
            currTime = 0;
            if (Input.GetKey("z") || Input.GetKey("j"))
			{
                spawnLinear();
			} else if (Input.GetKey("x") || Input.GetKey("k"))
			{
                spawnLobbed();
			}
		}
    }

    public void spawnLinear()
	{
        Instantiate(linearball, spawnAdjust + transform.position, Quaternion.identity);
	}

    public void spawnLobbed()
	{
        Instantiate(lobbedball, spawnAdjust + transform.position, Quaternion.identity);
	}
}
