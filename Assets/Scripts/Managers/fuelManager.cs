using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int maxfuel;
    public static int fuel;
    public static fuelManager Instance;

    Thermometer thermo; //temp
	public void Awake()
	{
        Instance = this;
	}
	void Start()
    {
        fuel = maxfuel;
        thermo = FindObjectOfType<Thermometer>(); //temp
        thermo.changeThermo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool hasEnough(int i)
	{
        if (fuel > i)
		{
            return true;
		} else
		{
            return false;
		}
	}
    public void gain(int i)
	{
        fuel += i;
        thermo.changeThermo();//temp
	}

    public void capGain(int i)
	{
        fuel += i;
        if (fuel > maxfuel)
		{
            fuel = maxfuel;
		}
        thermo.changeThermo();
	}

    public void lose(int i)
	{
        fuel -= i;
        if (fuel <= 0)
		{
            fuel = 0;
            sceneChanger.Instance.resetScene();
        }
        thermo.changeThermo();//temp
	}
}
