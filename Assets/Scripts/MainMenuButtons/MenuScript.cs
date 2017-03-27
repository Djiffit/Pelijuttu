using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Button startText;
    public Button exitText;
    public Button selectLevel;

    public Canvas quitMenu;

    public Canvas levelSelection;

    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        levelSelection = levelSelection.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        selectLevel = selectLevel.GetComponent<Button>();

        levelSelection.enabled = false;
        quitMenu.enabled = false;
    }

    public void QuitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        levelSelection.enabled = false;
        selectLevel.enabled = false;

    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        levelSelection.enabled = false;
        selectLevel.enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartLevel(string GameLevel)
    {
        SceneManager.LoadScene(GameLevel);
    }

    public void LevelSelectionPress()
    {
        quitMenu.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
        levelSelection.enabled = true;
        selectLevel.enabled = false;
    }

    public void LevelSelectionBackPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        levelSelection.enabled = false;
        selectLevel.enabled = true;
    }
}
