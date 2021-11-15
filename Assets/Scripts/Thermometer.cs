using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image thermoBar;
    [SerializeField] Text txt;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeThermo()
	{
        thermoBar.fillAmount = (float) fuelManager.fuel / fuelManager.Instance.maxfuel;
        txt.text = fuelManager.fuel.ToString();
	}
}
