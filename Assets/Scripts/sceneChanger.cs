using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public static sceneChanger Instance;
    public static float duration = 0.5f;
    static Animator anim;

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
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextScene()
	{
        StartCoroutine(fadeOut(true));
	}

    public void resetScene()
	{
        StartCoroutine(fadeOut(false));
	}

    IEnumerator fadeOut(bool different)
	{
        anim.SetTrigger("fadeOut");
        float elapsed = 0f;
        while (elapsed <= duration)
		{
            yield return null;
		}
        if (different)
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        anim.SetTrigger("fadeIn");
	}
}
