using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health, moveSpeed, damage, fireRate, nextFire, deltaX, deltaY;
    public GameObject projectile, projectile2;
    public AudioSource projectileSFX;
    public Vector3 playerPos, playerPos2;
    public Text HP;

    // reference to Rigidbody2D component
    Rigidbody2D rb;
    // reference to CircleCollider2D component
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        health = 1000; moveSpeed = 10; damage = 40; fireRate = 0.15f; nextFire = 0.0f;  //instantiate the stats
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the position of "guns" on the player
        playerPos = new Vector3(transform.position.x - 0.15f, transform.position.y + 0.5f, transform.position.z);
        playerPos2 = new Vector3(transform.position.x + 0.15f, transform.position.y + 0.5f, transform.position.z);
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;    //determine rate of fire
            //projectile Point of origin
            GameObject projt = Instantiate(projectile, playerPos, Quaternion.identity);
            GameObject projt2 = Instantiate(projectile2, playerPos2, Quaternion.identity);
            //Rotate the projectile(original image is horizontal
            projt.transform.Rotate(0, 0, 90);
            projt2.transform.Rotate(0, 0, 90);
            //Destroy projectile after 1 second to avoid having too many entities in the game
            Destroy(projt, 1f);
            Destroy(projt2, 1f);
        }

        // Initiating touch event
        // if touch event takes place
        if (Input.touchCount > 0)
        {
            // get touch to take a deal with
            Touch touch = Input.GetTouch(0);

            // obtain touch position
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            // processing touch phases
            switch (touch.phase)
            {
                // if you touches the screen
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;

                // if you move your finger
                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;

            }
        }//end of touchInput
        HP.text = health.ToString();
    }
}
