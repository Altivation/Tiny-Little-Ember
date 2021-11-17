using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class musicManager : MonoBehaviour
{
    [Serializable] struct songpairs
	{
        public string name;
        public AudioSource sound;
	}

    [HideInInspector] public static musicManager Instance;

    [SerializeField] List<songpairs> source;
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

    public void playSource(string song)
	{
        for (int i = 0; i < source.Count; i++)
		{
            if (source[i].name == song)
			{
                source[i].sound.Play();
                break;
			}
		}
	}

    public void pauseSource(string song)
	{
        for (int i = 0; i < source.Count; i++)
        {
            if (source[i].name == song)
            {
                source[i].sound.Pause();
                break;
            }
        }
    }
}