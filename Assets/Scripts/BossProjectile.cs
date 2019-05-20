using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit");//debug purpose, remove later
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);   //To avoid punch through effect
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

        if (this.gameObject != null && r != null)//destroy when out of frame
        {
            if (!r.isVisible)
                Destroy(this.gameObject);
        }
    }
}
