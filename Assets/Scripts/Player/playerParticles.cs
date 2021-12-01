using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerParticles : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem uiLIGHT;
    [SerializeField] float baseGreen;
    [SerializeField] float GreenMultiplier;
    [SerializeField] float baseAlpha;
    [SerializeField] float AlphaMultiplier;
    TrailRenderer tr;
    customPhysics player;
    int currFuel;
    [Serializable] struct particles
	{
        public ParticleSystem ps;
        public string name;
	}

    [SerializeField] List<particles> efx;
    void Start()
    {
        player = FindObjectOfType<customPhysics>();
        currFuel = 0;
        tr = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currFuel != fuelManager.fuel)
		{
            currFuel = fuelManager.fuel;
            var main = uiLIGHT.main;
            main.startColor = new Color(main.startColor.color.r, baseGreen + (GreenMultiplier * currFuel), main.startColor.color.b, baseAlpha + (AlphaMultiplier * currFuel));
            tr.startColor = main.startColor.color;
            tr.endColor = main.startColor.color;
		}
    }

	public void Play(string name)
	{
        for (int i = 0; i < efx.Count; i++)
		{
            if (efx[i].name == name)
			{
                efx[i].ps.Play();
                break;
			}
		}
	}

    public void Pause(string name)
    {
        for (int i = 0; i < efx.Count; i++)
        {
            if (efx[i].name == name)
            {
                efx[i].ps.Stop();
                break;
            }
        }
    }
}
