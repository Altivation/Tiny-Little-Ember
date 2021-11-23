using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowBlock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float dps;
    float currTime;
    float timeToInflict;
    bool inContact;
    void Start()
    {
        timeToInflict = 1f / dps;
        currTime = 0f;
        inContact = false;
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
                currTime = 0f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inContact = false;
            currTime = 0f;
        }
    }
}
