using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrusterControl : MonoBehaviour
{
    public Animator fire, em;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Play the thruster's animation
        fire.Play("Flame");
        em.Play("EnemyLoop");
    }
}
