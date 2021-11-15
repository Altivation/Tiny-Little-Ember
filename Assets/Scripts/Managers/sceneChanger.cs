using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public static sceneChanger Instance;
    [SerializeField] public float duration = 0.5f;
    static Animator anim;
    static bool loading;

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
        loading = false;
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
        if (!loading)
		{
            StartCoroutine(fadeOut(true));
            loading = true;
        }

	}

    public void resetScene()
	{
        if (!loading)
		{
            StartCoroutine(fadeOut(false));
            loading = true;
        }

	}

    IEnumerator fadeOut(bool different)
	{
        anim.SetTrigger("fadeOut");
        while (anim.GetCurrentAnimatorStateInfo(0).IsName("Default")) 
		{   
            yield return null;
		}
        while (anim.GetCurrentAnimatorStateInfo(0).IsName("fadeOut") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
		{
            yield return null;
		}
       
        if (different)
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        anim.SetTrigger("fadeIn");
        while (anim.GetCurrentAnimatorStateInfo(0).IsName("fadeOut"))
		{
            yield return null;
		}
        while(anim.GetCurrentAnimatorStateInfo(0).IsName("fadeIn") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
		{
            yield return null;
		}
        anim.SetTrigger("return");
        while(anim.GetCurrentAnimatorStateInfo(0).IsName("fadeIn"))
		{
            yield return null;
		}
        loading = false;
    }
}
