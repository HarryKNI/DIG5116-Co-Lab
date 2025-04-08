using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;
public class FPSUiManager : MonoBehaviour
{
    [Header("Available Ui")]
    [SerializeField] GameObject pauseMenuUi;
    [SerializeField] GameObject settingUi;
    [SerializeField] GameObject taskUi;

    [Header("Button defaults")]
    [SerializeField] GameObject defaultPauseButton;
    [SerializeField] GameObject defaultSettingsButton;

    [Header("Event system")]
    [SerializeField] EventSystem _EventSystem;

    [Header("Locking/Unlocking Cursor Parametre")]
    [SerializeField] FPSController PlayerController;

    [Header("Game State Checker")]
    [SerializeField] GameManager GameManager;

    [Header("Task Ui Text")]
    [SerializeField] string Task1Text;
    [SerializeField] string Task2Text;
    [SerializeField] string Task3Text;
    [SerializeField] string CompletionText;
    private string Task1Holder;
    private string Task2Holder;
    private string Task3Holder;
    [SerializeField] TMP_Text Task1TextBox;
    [SerializeField] TMP_Text Task2TextBox;
    [SerializeField] TMP_Text Task3TextBox;
    [SerializeField] TMP_Text CompletionTextBox;

    private void Start()
    {
        SetTaskVisability();
        CompletionTextBox.text = "";
    }

    private void Update()
    {
        UpdateTasks();
        UpdateTaskVisibility();
        CheckTaskCompletion();
    }

    /// <summary>
    /// This function updates the task text boxes with the current task status
    /// </summary>
    private void UpdateTasks()
    {
        if (string.IsNullOrEmpty(Task1Text))
        {
            Task1TextBox.text = "";
            Task1Holder = Task1TextBox.text;
        }
        else
        {
            Task1TextBox.text = Task1Text + ": " + GameManager.Task1Incrementer.ToString() + "/" + GameManager.Task1Limit.ToString();
            Task1Holder = Task1TextBox.text;
        }
        if (string.IsNullOrEmpty(Task2Text))
        {
            Task2TextBox.text = "";
            Task2Holder = Task2TextBox.text;
        }
        else
        {
            Task2TextBox.text = Task2Text + ": " + GameManager.Task2Incrementer.ToString() + "/" + GameManager.Task2Limit.ToString();
            Task2Holder = Task2TextBox.text;
        }
        if (string.IsNullOrEmpty(Task3Text))
        {
            Task3TextBox.text = "";
            Task3Holder = Task3TextBox.text;
        }
        else
        {
            Task3TextBox.text = Task3Text + ": " + GameManager.Task3Incrementer.ToString() + "/" + GameManager.Task3Limit.ToString();
            Task3Holder = Task3TextBox.text;
        }

    }

    /// <summary>
    /// This function sets the task text boxes to be invisible at the start of the game
    /// </summary>
    private void SetTaskVisability()
    {
        Task2TextBox.alpha = .0f;
        Task3TextBox.alpha = .0f;
        CompletionTextBox.alpha = .0f;
    }

    /// <summary>
    /// This function updates the task text boxes to be visible if the previous task is completed
    /// </summary>
    private void UpdateTaskVisibility()
    {
        if (GameManager.isTask1Completed)
        {
            StartCoroutine(FadeInText(Task2TextBox, 1f));
        }
        if (GameManager.isTask2Completed)
        {
            StartCoroutine(FadeInText(Task3TextBox, 1f));
        }
    }

    /// <summary>
    /// This function fades in the text box over a given duration
    /// </summary>
    /// <param name="textBox"></param>
    /// <param name="duration"></param>
    private IEnumerator FadeInText(TMP_Text textBox, float duration)
    {
        float elapsedTime = 0f;
        Color color = textBox.color;
        while (elapsedTime < duration)
        {
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / duration);
            textBox.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        color.a = 1f;
        textBox.color = color;
    }



    /// <summary>
    /// This function checks if the tasks are completed 
    /// and updates the UI text style to strike-through
    /// </summary>
    private void CheckTaskCompletion()
    {
        if (GameManager.isTask1Completed)
        {
            Task1TextBox.text = $"<s>{Task1Holder}</s>";
        }
        if (GameManager.isTask2Completed)
        {
            Task2TextBox.text = $"<s>{Task2Holder}</s>";
        }
        if (GameManager.isTask3Completed)
        {
            Task3TextBox.text = $"<s>{Task3Holder}</s>";
        }
        if (GameManager.isTask1Completed && GameManager.isTask2Completed && GameManager.isTask3Completed)
        {
            CompletionTextBox.text = CompletionText;
            StartCoroutine(FadeInText(CompletionTextBox, 1f));
        }

    }

    /// <summary>
    /// This function opens the pause menu and closes the settings menu if it is open
    /// </summary>
    /// Vennce
    public void ActivatePauseMenu()
    {
        pauseMenuUi.SetActive(true);
        SetDefaultButton(defaultPauseButton);
        settingUi.SetActive(false);
        PlayerController.UnlockCursor();
        PlayerController.CanMove = false;
    }

    /// <summary>
    /// This function opens the settings menu and closes the pause menu if it is open
    /// </summary>
    /// Vennce
    public void ActivateSettingsMenu()
    {
        settingUi.SetActive(true);
        SetDefaultButton(defaultSettingsButton);
        pauseMenuUi.SetActive(false);
    }

    /// <summary>
    /// This function opens the task UI
    /// </summary>
    public void ActivateTaskUi()
    {
        taskUi.SetActive(true);
    }

    /// <summary>
    /// This function closes the task UI
    /// </summary>
    public void DeactivateTaskUi()
    {
        taskUi.SetActive(false);
    }

    /// <summary>
    /// This function resumes the game
    /// </summary>
    /// Vennce
    public void ResumeGame()
    {
        pauseMenuUi.SetActive(false);
        settingUi.SetActive(false);
        taskUi.SetActive(true);
        PlayerController.LockCursor();
        PlayerController.CanMove = true;
        GameManager.UnPauseGame();
    }

    /// <summary>
    /// This function goes back to menu
    /// </summary>
    /// Vennce
    public void BackToMenu()
    {
        //Need to add main menu scene here
        Time.timeScale = 1;
        SceneManager.LoadScene("");
    }

    /// <summary>
    /// This function quits the game
    /// </summary>
    /// Vennce
    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    /// <summary>
    /// This function sets the default button hover when switching uis
    /// </summary>
    /// <param name="button"></param>
    /// Vennce
    private void SetDefaultButton(GameObject button)
    {
        _EventSystem.SetSelectedGameObject(null);
        _EventSystem.firstSelectedGameObject = button;
        _EventSystem.SetSelectedGameObject(button);
    }
}
