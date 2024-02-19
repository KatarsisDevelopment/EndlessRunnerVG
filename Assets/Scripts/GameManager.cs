using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI StartText;
    void Awake()
    {
        Time.timeScale = 0;
        StartText.gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            StartText.gameObject.SetActive(false);
        }
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public static void GameOver()
    {
        Time.timeScale = 0;
    }
}
