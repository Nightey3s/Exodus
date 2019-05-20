using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectile : MonoBehaviour
{
    public float moveSpeed = 25;
    public Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit");//debug purpose, remove later
        if (collision.gameObject.layer == 10)
        {    //enemy layer is 10
            collision.GetComponent<Enemy1>().Death();
            Destroy(this.gameObject);   //To avoid punch through effect
        }
        if (collision.gameObject.layer == 11)
        {    //enemy layer is 11
            collision.GetComponent<Enemy2>().Death();
            Destroy(this.gameObject);   //To avoid punch through effect
        }
        if (collision.gameObject.layer == 12)
        {    //enemy layer is 12
            collision.GetComponent<Enemy3>().Death();
            Destroy(this.gameObject);   //To avoid punch through effect
        }
        if (collision.gameObject.layer == 13)
        {    //enemy layer is 12
            collision.GetComponent<Boss>().Death();
            Destroy(this.gameObject);   //To avoid punch through effect
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);  //move the player's projectile

        if (!r.isVisible)
            Destroy(this.gameObject);   //destroy once out of frame
    }
}
