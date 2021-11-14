using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{

    [HideInInspector] public static musicManager Instance;

    [SerializeField] AudioSource bg;
    [SerializeField] AudioSource fire;
    [SerializeField] AudioSource shoot;
    [SerializeField] AudioSource cold;
    [SerializeField] AudioSource splat;
    [SerializeField] AudioSource ignite;
    [SerializeField] AudioSource jump;
    private void Awake()
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

    public void playBG()
    {
        bg.Play();
    }
    public void playHearth()
    {
        fire.Play();
    }

    public void stopHearth()
    {
        fire.Pause();
    }

    public void playFrost()
	{
        cold.Play();
	}
    
    public void pauseFrost()
	{
        cold.Pause();
	}

    public void Ignite()
    {
        ignite.Play();
    }


    public void Shoot()
    {
        shoot.Play();
    }

    public void setShoot(float val)
    {
        shoot.volume = val * 0.3f;
    }

    public void Splat()
    {
        splat.Play();
    }

    public void Jump()
    {
        jump.Play();
    }
}