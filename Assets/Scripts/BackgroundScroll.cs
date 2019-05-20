using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private MeshRenderer MR;
    void Start()
    {
        MR = GetComponent<MeshRenderer>();  //get the MeshRender on start
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * scrollSpeed);   //store the scrolling
        MR.sharedMaterial.SetTextureOffset("_MainTex", offset);     //scrolls the texture
    }
}
