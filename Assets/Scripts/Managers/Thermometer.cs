using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text txt;
    [SerializeField] Animator anim;
    [SerializeField] Color bonusColor;
    Color origColor;
	private void Awake()
	{
        
	}
	void Start()
    {
        origColor = txt.color;
        fuelManager.Instance.findThermo();
    }

    // Update is called once per frame
    void Update()
    {
        if (fuelManager.fuel > fuelManager.Instance.maxfuel)
        {
            if (txt.color != bonusColor)
            {
                anim.enabled = false;
                txt.color = bonusColor;
            }

        }
        else if (txt.color == bonusColor)
        {
            txt.color = origColor;
            anim.enabled = true;
        }

         
        if (fuelManager.Instance.maxfuel > 1 || fuelManager.fuel == 0)
        {
            if (fuelManager.fuel == 1 || fuelManager.fuel == 0)
			{
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Default"))
				{
                    anim.SetTrigger("flash");
				}
			} else
			{
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("tempTextAnim"))
				{
                    anim.SetTrigger("reset");
				}
			}
        }

        
    }

    public void changeThermo()
	{
        txt.text = fuelManager.fuel.ToString();
	}

}
