using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceContact : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float lossPerRate;
    bool inContact;
    void Start()
    {
        inContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inContact)
		{
            heatManager.loseHeat(lossPerRate * Time.deltaTime);
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
            inContact = true;
			musicManager.Instance.playFrost();
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			inContact = false;
			musicManager.Instance.pauseFrost();
		}
	}
}
