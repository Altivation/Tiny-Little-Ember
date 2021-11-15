using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haystack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int cost = 1;
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "fireball")
		{
            fuelManager.Instance.lose(cost);
            StartCoroutine(selfdestruct());
		}
	}
    
    IEnumerator selfdestruct()
	{
        
        anim.SetTrigger("burn");
        while (anim.GetCurrentAnimatorStateInfo(0).IsName("Default")) 
		{   
            yield return null;
		}
        while (anim.GetCurrentAnimatorStateInfo(0).IsName("burn") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1) 
		{   
            yield return null;
		}
        Destroy(gameObject);
	}
    
}
