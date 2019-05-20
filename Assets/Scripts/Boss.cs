using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float health, damage, moveSpeed, mult, fireRate, nextFire;
    public GameObject explosion, projectile;
    public AudioSource sfx;
    public AudioClip deathSFX;
    public bool dead;
    public Vector3 BossPos;

    // Start is called before the first frame update
    void Start()
    {
        health = 5000; damage = 30; moveSpeed = 4f;
        fireRate = 4f; nextFire = 0.0f;
        mult = ScoreManager.s;
        health *= Mathf.Pow((mult / 100),1.5f);//scaling health 
    }
    public void Death()
    {
        //Happens when player's projectile hits enemy
        GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");
        Player playerScript = thePlayer.GetComponent<Player>();
        this.health -= playerScript.damage;
        if (this.health <= 0)
            if (health <= 0)
            {
                Destroy(this.gameObject, 5f);
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(GetComponent<Collider2D>());
                dead = true;
                ScoreManager.tempScore += (int)health;
                GameObject epl = Instantiate(explosion, transform.position, Quaternion.identity);
                sfx.PlayOneShot(deathSFX);
                Destroy(epl, 5f);
            }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            //This is boss, instant death on collision
                Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float rnd = UnityEngine.Random.Range(-5f, 5f);
        BossPos = new Vector3(transform.position.x + rnd, transform.position.y - 1.5f, transform.position.z);
        if (Time.time > nextFire)
        {

            nextFire = Time.time + fireRate;    //determine rate of fire
            //projectile Point of origin
            GameObject projt = Instantiate(projectile, BossPos, Quaternion.identity);
            projt.transform.Rotate(0, 0, -90);
        }
    }
}
