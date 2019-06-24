using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelChanger : MonoBehaviour
{
    public Animator anim;

    public void fadeToLevel(int levelIndex)
    {
        anim.SetTrigger("fadeOut");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
