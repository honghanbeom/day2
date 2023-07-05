using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject GameOverUI = default;
    public Text TimeText;
    public Text RecordScoreText;

    private float surviveTime;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            TimeText.text = "Timer :" + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        GameOverUI.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("Best Time");

        if (surviveTime > bestTime) 
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("Best Time", bestTime);
        }

        RecordScoreText.text = string.Format("Best Time : {0}", (int)bestTime);
    }
}
