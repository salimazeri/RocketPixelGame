using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class restartScript : MonoBehaviour
{

    public Button b;

    void Start()
    {
        b.onClick.AddListener(TaskOnClick);
    }
    
    void TaskOnClick()
    {
        SceneManager.LoadScene("rocket 2", LoadSceneMode.Single);
    }

}