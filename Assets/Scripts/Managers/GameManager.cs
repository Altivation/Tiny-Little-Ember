using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public static int numTorches;

    [HideInInspector] public static GameManager Instance;


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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void resetTorches()
	{
        numTorches = 0;
	}

    public static void foundTorch()
	{
        numTorches--;
        Debug.Log(numTorches);
        if (numTorches <= 0)
		{
            sceneChanger.Instance.nextScene();
		}
	}
}
