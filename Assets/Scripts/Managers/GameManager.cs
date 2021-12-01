using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public static GameManager Instance;

    [HideInInspector] public static Vector3 respawnPos;

    [HideInInspector] public static bool startStorm;

    [HideInInspector] public static bool endOfStorm;

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
        startStorm = false;
        endOfStorm = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void setSpawn(Vector3 pos)
	{
        respawnPos = pos;
	}

    public static void resetSpawn()
	{
        customPhysics player = FindObjectOfType<customPhysics>();
        Camera cam = FindObjectOfType<Camera>();
        TrailRenderer tr = player.GetComponentInChildren<TrailRenderer>();
        if (cam == null || player == null)
		{
            fuelManager.Instance.maxfuel = 1;
            respawnPos = new Vector2(1.66f, 10.27f);
		} else
		{
            tr.enabled = false;
            player.transform.position = respawnPos;
            cam.transform.position = respawnPos;
            tr.enabled = true;
        }

	}
}
