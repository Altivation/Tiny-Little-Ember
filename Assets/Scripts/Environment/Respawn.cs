using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D hitbox;
    SpriteRenderer sr;
    Animator anim;
    Camera cam;
    [SerializeField] float regen = 10f;
    [SerializeField] float extraRegen = 5f;
    [HideInInspector] public bool hidden;
    float currTime = 0f;
    float bonTime = 0f;


	private void Awake()
	{
        hitbox = GetComponent<Collider2D>();
        cam = FindObjectOfType<Camera>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        hidden = false;
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hidden)
		{
            if (currTime < regen)
			{
                currTime += Time.deltaTime;
			} else
			{
                if (!onCamera())
				{
                    bonTime += Time.deltaTime;
                    if (bonTime > extraRegen)
					{
                        Show();
					}
				}
			}
		}
    }

	public void Hide()
	{
        hitbox.enabled = false;
        sr.enabled = false;
        hidden = true;
        currTime = 0f;
        bonTime = 0f;
        if (anim != null)
		{
            anim.SetTrigger("reset");
		}
	}

	public void Show()
	{
        hitbox.enabled = true;
        sr.enabled = true;
        hidden = false;
        currTime = 0f;
        bonTime = 0f;
	}

    bool onCamera()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        return !((viewPos.x < -0.1 || viewPos.x > 1.1) || (viewPos.y < -0.1 || viewPos.y > 1.1));
    }
}
