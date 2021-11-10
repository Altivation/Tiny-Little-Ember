using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootFireballs : MonoBehaviour
{
    // Start is called before the first frame update
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    [SerializeField] linearBall linearball;
    [SerializeField] lobbedBall lobbedball;
    [SerializeField] float rateOfFire;
    [SerializeField] Vector3 spawnAdjust;
    float currTime;
    void Start()
    {
        currTime = 0;
=======
    [SerializeField] lobBall lobball;
    [SerializeField] linearBall linearball;
    [SerializeField] float timePerShot;
    [SerializeField] Vector3 spawningAdjust;

    float currTime;
    void Start()
    {
        currTime = 0;   
>>>>>>> Stashed changes
=======
    [SerializeField] lobBall lobball;
    [SerializeField] linearBall linearball;
    [SerializeField] float timePerShot;
    [SerializeField] Vector3 spawningAdjust;

    float currTime;
    void Start()
    {
        currTime = 0;   
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;

<<<<<<< Updated upstream
<<<<<<< Updated upstream
        if (currTime >= rateOfFire)
=======
        if (currTime >= timePerShot)
>>>>>>> Stashed changes
=======
        if (currTime >= timePerShot)
>>>>>>> Stashed changes
		{
            currTime = 0;
            if (Input.GetKey("z") || Input.GetKey("j"))
			{
                spawnLinear();
			} else if (Input.GetKey("x") || Input.GetKey("k"))
			{
                spawnLobbed();
			}
<<<<<<< Updated upstream
<<<<<<< Updated upstream
		}
=======
		} 
>>>>>>> Stashed changes
=======
		} 
>>>>>>> Stashed changes
    }

    public void spawnLinear()
	{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        Instantiate(linearball, spawnAdjust + transform.position, Quaternion.identity);
=======
        Instantiate(linearball, transform.position - spawningAdjust, Quaternion.identity);
>>>>>>> Stashed changes
=======
        Instantiate(linearball, transform.position - spawningAdjust, Quaternion.identity);
>>>>>>> Stashed changes
	}

    public void spawnLobbed()
	{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        Instantiate(lobbedball, spawnAdjust + transform.position, Quaternion.identity);
=======
        Instantiate(lobball, transform.position - spawningAdjust, Quaternion.identity);
>>>>>>> Stashed changes
=======
        Instantiate(lobball, transform.position - spawningAdjust, Quaternion.identity);
>>>>>>> Stashed changes
	}
}
