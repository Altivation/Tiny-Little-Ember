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
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
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
        if (fuel <= 0)
		{
            sceneChanger.Instance.resetScene(); 
        }
    }

    public void findThermo()
	{
        thermo = FindObjectOfType<Thermometer>();
        Reset();
	}
	public void Reset()
	{
        fuel = maxfuel;
        if (thermo != null)
		{
            thermo.changeThermo();
        }
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
        for (int j = 0; j < i; i++)
		{
            if (fuel < maxfuel)
			{
                fuel++;
			} else
			{
                break;
			}
		}
        thermo.changeThermo();
	}

    public void lose(int i)
	{
        fuel -= i;
        if (fuel <= 0)
		{
            fuel = 0;
        }
        thermo.changeThermo();//temp
        FindObjectOfType<playerParticles>().Play("fireSpark");
	}
}
