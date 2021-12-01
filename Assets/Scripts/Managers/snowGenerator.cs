using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    bool played;
    ParticleSystem ps;
    void Start()
    {
        played = false;
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.startStorm && !played) {
            ps.Play();
            played = true;
		} else if (GameManager.endOfStorm && played)
		{
            ps.Stop();
		}
    }
}
