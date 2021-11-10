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
        thermoBar.fillAmount = heatManager.currHeat / heatManager.maxHeat;
        txt.text = Mathf.Floor(heatManager.currHeat).ToString() + "/" + heatManager.maxHeat.ToString();
	}
}
