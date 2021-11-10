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

    void playBG()
    {
        bg.Play();
    }
    void playHearth()
    {
        fire.Play();
    }

    void stopHearth()
    {
        fire.Pause();
    }

    void Ignite()
    {
        ignite.Play();
    }


    void Shoot()
    {
        shoot.Play();
    }

    void setShoot(float val)
    {
        shoot.volume = val * 0.3f;
    }

    void Splat()
    {
        splat.Play();
    }

    void setSplat(float val)
    {
        splat.volume = val * 0.8f;
    }

    void Jump()
    {
        jump.Play();
    }
}