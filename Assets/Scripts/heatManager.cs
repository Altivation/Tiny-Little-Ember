using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heatManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public static float maxHeat = 100;
    [SerializeField] public static float currHeat = maxHeat;
    [SerializeField] public float melting_point;
    Thermometer thermo;
    void Start()
    {
        thermo = FindObjectOfType<Thermometer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool hasEnough(float i)
	{
        return currHeat >= i;
	}
    public static void loseHeat(float i)
	{
        currHeat -= i;
        if (currHeat <= 0)
		{
            currHeat = 0;
            atZero();
		}
        changeThermometer();
	}

    public static void gainHeat(float i)
	{
        currHeat += i;
        if (currHeat > maxHeat)
		{
            currHeat = maxHeat;
		}
        changeThermometer();
	}

    public static void gainHeatPlus(float i)
	{
        currHeat += i;
        changeThermometer();
	}

    public static void changeThermometer()
	{
        thermo.changeThermo();
	}

    public static void atZero()
	{
        //call things to trigger at 0
	}

}
