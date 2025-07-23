using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public class MenuController : MonoBehaviour
{
    // ========== MENU BUTTONS ==========
    [Header("Levels to Load")]
    public string _newGameLevel;
    private string _currentLevel;
    [SerializeField] private GameObject noSavedGameDialog = null;

    // ========== GAME CONTROL METHODS ==========
    public void NewGameDialogConfirm()
    {
        SceneManager.LoadScene(_newGameLevel);
    }
    public void LoadGameDialogConfirm()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            _currentLevel = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(_currentLevel);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
