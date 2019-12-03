using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour

{
    [SerializeField]
    private GameObject _settingsMenu;
    [SerializeField]
    private GameObject _notebook;


    public AK.Wwise.Event journalOC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _settingsMenu.SetActive(!_settingsMenu.activeSelf);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            _notebook.SetActive(!_notebook.activeSelf);
            journalOC.Post(_notebook);
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
