using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuBehaviour : MonoBehaviour
{
    //changing scenes
    private AsyncOperation async;
    //Select Menu
    [SerializeField] GameObject[] panels = null;
    [SerializeField] private Selectable[] items = null;
    

    public void LoadScene()
    {
        StartCoroutine(LoadNextScene());
    }
    IEnumerator LoadNextScene()
    {
        if(async==null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
            async.allowSceneActivation = true;
        }
        yield return null;
        

    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForFixedUpdate();
        PanelToggle(0);
    }
    public void PanelToggle(int position)
    {
        for(int i=0;i<panels.Length;i++)
        {
            panels[i].SetActive(position == i);
            if(position==i)
            {
                items[i].Select();
            }
        }
    }

    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
