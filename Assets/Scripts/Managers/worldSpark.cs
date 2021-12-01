using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldSpark : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem ps;
    [SerializeField] int woodEmission;
    [SerializeField] int charcoalEmission;
    [SerializeField] Color woodColor;
    [SerializeField] Color charcoalColor;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void woodBurn()
	{
        var emission = ps.emission;
        emission.rate = woodEmission;
        var main = ps.main;
        main.startColor = woodColor;
        ps.Play();
	}

    public void charcoalBurn()
	{
        var emission = ps.emission;
        emission.rate = charcoalEmission;
        var main = ps.main;
        main.startColor = charcoalColor;
        ps.Play();
	}
}
