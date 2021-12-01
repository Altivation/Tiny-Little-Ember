using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool resetWorld;
    bool revealed;
    Respawn respawn;
    Collider2D hitbox;
    void Start()
    {
        if (!resetWorld)
		{
            respawn = GetComponent<Respawn>();
            hitbox = GetComponent<Collider2D>();
            respawn.Hide();
            revealed = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!resetWorld && GameManager.startStorm && !revealed)
		{
            respawn.Show();
            revealed = true;
            GetComponent<Respawn>().revealed = true;

		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (resetWorld && collision.gameObject.tag == "Player" && GameManager.startStorm)
		{
            GameManager.endOfStorm = true;
            ParticleSystem ps = FindObjectOfType<snowGenerator>().GetComponent<ParticleSystem>();
            ps.Stop();
		}
	}
}
