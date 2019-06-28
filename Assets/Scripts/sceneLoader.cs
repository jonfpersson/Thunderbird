using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    int levelToLoad;
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) || gameObject.transform.position.y < -55) { reloadScene(); }
    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == "floor")
        {
            Debug.Log("lol");
            fadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void fadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;

        anim.SetTrigger("fadeOut");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        fadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
