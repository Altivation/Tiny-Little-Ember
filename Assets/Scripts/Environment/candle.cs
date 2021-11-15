using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candle : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    bool lit;

	private void Awake()
	{
        anim = GetComponent<Animator>();
        GameManager.numTorches++;
        lit = false;
	}

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" && !lit)
		{
            litTorch();
            lit = true;
		}
	}

    public void litTorch()
	{
        GameManager.foundTorch();
        anim.SetTrigger("candle");
	}
}