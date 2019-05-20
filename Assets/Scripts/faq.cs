using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class faq : MonoBehaviour
{
    public Button close;
    //for the FAQ page
    void Start()
    {
        close.interactable = true;
    }
    public void onClose()
    {
        SceneManager.LoadScene(0);
    }
}
