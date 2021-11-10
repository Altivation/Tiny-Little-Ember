using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public static int numTorches;

    [HideInInspector] public static GameManager Instance;

    [HideInInspector] sceneChanger screen;

	private void Awake()
	{
	    if (!Instance)
		{
            Instance = this;
            DontDestroyOnLoad(this);
		} else
		{
            Destroy(gameObject);
		}
	}
	void Start()
    {
        screen = FindObjectOfType<sceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void countTorches()
	{
        var candles = FindObjectsOfType<candle>();
        numTorches = candles.Length;
	}

    public static void foundTorch()
	{
        numTorches--;
	}

    public static void changeScene()
	{

	}
}
