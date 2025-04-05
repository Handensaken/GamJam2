using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public List<string> RandomSceneNames = new List<string>();
    private string s = "";

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void Load(string s)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(s);
    }
    public void LoadRandom()
    {
        int sceneToLoad = Random.Range(0, RandomSceneNames.Count);
        UnityEngine.SceneManagement.SceneManager.LoadScene(RandomSceneNames[sceneToLoad]);
    }

    public void Exit()
    {
        Debug.Log("fucker");
        Application.Quit();
    }

    public void ToggleElement(GameObject g)
    {
        g.SetActive(!g.active);

        if (g.active)
            s = "Close";
        else
            s = "Credits";
    }

    public void ChangeTextElement(GameObject tmp)
    {
        //Debug.Log(tmp.GetComponent);
        tmp.GetComponent<TextMeshProUGUI>().text = s;
    }
}
