using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowBlock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float dps;
    [SerializeField] float snowSpeed;
    [SerializeField] float origSpeed;
    float currTime;
    float timeToInflict;
    bool inContact;
    move player;
    playerParticles pPS;
    void Start()
    {
        timeToInflict = 1f / dps;
        currTime = 0f;
        inContact = false;
        pPS = FindObjectOfType<playerParticles>();
        player = FindObjectOfType<move>();
        origSpeed = player.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (inContact)
        {
            currTime += Time.deltaTime;
            if (currTime > timeToInflict)
            {
                fuelManager.Instance.lose(1);
                currTime = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<customPhysics>().OnTopOf() == gameObject)
			{
                inContact = true;
                player.speed = snowSpeed;
                currTime = 0f;
                pPS.Play("snowStep");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inContact = false;
            player.speed = origSpeed;
            currTime = 0f;
            pPS.Pause("snowStep");
        }
    }
}
