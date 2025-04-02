using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused = false;

    [Header("Task Completion Booleans")]
    public bool isTask1Completed = false;
    public bool isTask2Completed = false;
    public bool isTask3Completed = false;

    [Header("Task Incrementers")]
    public int Task1Incrementer = 0;
    public int Task2Incrementer = 0;
    public int Task3Incrementer = 0;

    [Header("Task Limit Ints")]
    [SerializeField] int Task1Limit = 0;
    [SerializeField] int Task2Limit = 0;
    [SerializeField] int Task3Limit = 0;

    private void Update()
    {
        CheckTaskCompletion();
    }

    //
    // These functions are just used to normalise pausing in both PauseManager and FPSUiManager
    //

    /// <summary>
    /// This function pauses the game
    /// </summary>
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// This function unpauses the game
    /// </summary>
    public void UnPauseGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
    }


    /// <summary>
    /// This function increments task 1 number
    /// </summary>
    public void IncrementTask1()
    {
        ++Task1Incrementer;
        if (Task1Incrementer >= Task1Limit)
        {
            Task1Incrementer = Task1Limit;
        }

    }

    /// <summary>
    /// This function increments task 2 number
    /// </summary>
    public void IncrementTask2()
    {
        ++Task2Incrementer;
        if (Task2Incrementer >= Task2Limit)
        {
            Task2Incrementer = Task2Limit;
        }
    }

    /// <summary>
    /// This function increments task 3 number
    /// </summary>
    public void IncrementTask3()
    {
        ++Task3Incrementer;
        if (Task3Incrementer >= Task3Limit)
        {
            Task3Incrementer = Task3Limit;
        }
    }

    /// <summary>
    /// This function checks if the task is completed
    /// </summary>
    private void CheckTaskCompletion()
    {
        if (Task1Incrementer >= Task1Limit)
        {
            isTask1Completed = true;
        }
        if (Task2Incrementer >= Task2Limit)
        {
            isTask2Completed = true;
        }
        if (Task3Incrementer >= Task3Limit)
        {
            isTask3Completed = true;
        }
    }
}
