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

    //private void Start() { endReached = false; }

    void OnCollisionEnter(Collision col)
    {
        int level = SceneManager.GetActiveScene().buildIndex + 1;


        if (col.gameObject.name == "floor")
        {
            Debug.Log("SceneManager.GetActiveScene().buildIndex + 1: " + level);
            if(level != 8)
                fadeToLevel(level);
            else
                fadeToLevel(3);

        }
    }

    public void fadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        anim.SetTrigger("fadeOut");
    }

    public void onFadeComplete()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 != 8)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        else
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            Cursor.visible = true;

        }
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        fadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
