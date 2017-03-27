using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Canvas quitMenu;
    public Button playButton;
    public Button quitButton;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();

        quitMenu.enabled = false;
	}
	
	public void QuitPress()
    {
        quitMenu.enabled = true;
        playButton.enabled = false;
        quitButton.enabled = false;
    }

    public void QuitNoPress()
    {
        quitMenu.enabled = false;
        playButton.enabled = true;
        quitButton.enabled = true;
    }

    public void QuitYesPress()
    {
        Application.Quit();
    }

    public void PlayPress()
    {
        SceneManager.LoadScene(1);
    }
}
