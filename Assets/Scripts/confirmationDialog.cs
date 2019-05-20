using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class confirmationDialog : MonoBehaviour
{
    // 200x300 px window will apear in the center of the screen.
    private Rect quitGame = new Rect((Screen.width - 720) / 2, (Screen.height - 1280) / 2, 720, 1280);
    private Rect infoScreen = new Rect((Screen.width - 720) / 2, (Screen.height - 1280) / 2, 720, 1280); 
    // Only showQuitDiag it if needed
    private bool showQuitDiag = false, showinfoScreen = false;
    public Button info, quit, start, fb, tw, faq;
    public Toggle music, sound;
    private Light Light;
    public Text Record;
    highscoreManager HSM;
    GUIStyle FS = new GUIStyle();
    GUIStyle Title = new GUIStyle();

    void Start()
    {
        Record.text = highscoreManager.getHighScore().ToString();   //display high score
    }
    void OnGUI()
    {   //GUI for exit app and info    
        FS.fontSize = 32;
        FS.alignment = TextAnchor.UpperCenter;
        FS.normal.textColor = Color.white;
        Title.fontSize = 50;
        Title.alignment = TextAnchor.UpperCenter;
        Title.normal.textColor = Color.red;

        if (showQuitDiag)
            quitGame = GUI.Window(0, quitGame, quitDialog, "", Title);

        if(showinfoScreen)
            infoScreen = GUI.Window(1, infoScreen, infoDialog, "", FS);
    }

    void infoDialog(int windowID)//information gui
    {
        float y = 20;
        GUI.Box(new Rect(10, 10 * y, infoScreen.width - 20, 1080), "Exodus" + "\n\nAll Rights Reserved®\nNightey3s\n\nExodus is a sci-fi top down shooter game\r\n" +
            "This game was developed for a\r\nschool assignment,\r\nno copyright infringements of \r\nassets are intended." +
            "\n\nGame assets were \r\ntaken from: https://itch.io/game-assets" +
            "\nMusic:\n https://www.bensound.com/royalty-free-music" +
            "\n\nYou can check out my website: \nhttps://nightey3s.github.io", FS);
        if (GUI.Button(new Rect(5, 50 * y, infoScreen.width - 10, 100), "Close",FS))
        {
            this.showinfoScreen = false;
            enableButtons();
        }
    }


    void quitDialog(int windowID)//quit app gui
    {
        float y = 20;
        GUI.Label(new Rect(10, 3 * y, quitGame.width, 50), "Are you sure you want to quit?", Title);

        if (GUI.Button(new Rect(5, 20 * y, quitGame.width - 10, 150),"Yes",FS))
        {
            Application.Quit();
            this.showQuitDiag = false;
            enableButtons();
        }

        if (GUI.Button(new Rect(5, 40 * y, quitGame.width - 10, 150), "Cancel", FS))
        {
            this.showQuitDiag = false;
            enableButtons();
        }
    }

    // To open the dialogue from outside of the script.
    public void quitOpen()
    {
        disableButtons();
        this.showQuitDiag = true;
    }
    public void infoOpen()
    {
        disableButtons();
        this.showinfoScreen = true;
    }
    private void disableButtons()
    {
        info.interactable = false; quit.interactable = false; start.interactable = false; fb.interactable = false; tw.interactable = false; faq.interactable = false;
        music.interactable = false; sound.interactable = false;
    }
    private void enableButtons()
    {
        info.interactable = true; quit.interactable = true; start.interactable = true; fb.interactable = true; tw.interactable = true; faq.interactable = true;
        music.interactable = true; sound.interactable = true;
    }
}
