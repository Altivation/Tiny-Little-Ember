using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public static sceneChanger Instance;
    Animator anim;

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

    public static void nextScene()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public static void resetScene()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
