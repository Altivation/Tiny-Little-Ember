using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public static int fuel;
    public static fuelManager Instance;
	public void Awake()
	{
        Instance = this;
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool hasEnough(int i)
	{
        if (fuel >= i)
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
	}

    public void lose(int i)
	{
        fuel -= i;
	}
}
