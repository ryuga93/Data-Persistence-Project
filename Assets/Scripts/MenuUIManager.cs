using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
using TMPro;
#endif

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TextMeshProUGUI BestScoreText;
    //TODO: set data to UI

    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = "Best Score: " + PersistenceManager.Instance.HighScorePlayerName + " - " + PersistenceManager.Instance.HighScore;
        nameInput.text = PersistenceManager.Instance.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        PersistenceManager.Instance.SavePlayerData();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    void SetPlayerName()
    {
        PersistenceManager.Instance.PlayerName = nameInput.text;
    }
}
