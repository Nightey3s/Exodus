using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float health, damage, moveSpeed, destroyed3=0;
    public GameObject explosion;
    public AudioSource sfx;
    public AudioClip deathSFX;
    public bool dead;
    public Renderer r;
    // Start is called before the first frame update
    void Start()
    {
        health = 70; damage = 30; moveSpeed = 4f; destroyed3 = 0;//set enemy stats
        r = GetComponent<Renderer>();
        sfx = GetComponent<AudioSource>();
    }
    public void Death()
    {
        //Happens when player's projectile hits enemy
        GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");
        Player playerScript = thePlayer.GetComponent<Player>();
        this.health -= playerScript.damage;
        if (this.health <= 0)
        {
            Destroy(this.gameObject, 5f);
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<Collider2D>());
            dead = true;
            ScoreManager.tempScore += 20;
            GameObject epl = Instantiate(explosion, transform.position, Quaternion.identity);
            sfx.PlayOneShot(deathSFX);
            Destroy(epl, 2f);
        }

    }
    public float E3_destroy
    {
        get { return this.destroyed3; }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //collision with player
        if (collision.gameObject.layer == 8)
        {
            GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");
            Player playerScript = thePlayer.GetComponent<Player>();
            playerScript.health -= damage;
            if (playerScript.health <= 0)
                Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!dead)
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);

        if (this.gameObject != null && r != null)//destroy when out of frame
        {
            if (!r.isVisible)
                Destroy(this.gameObject);
        }
    }
}
