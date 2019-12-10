//Switches between Scenes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_Scene : MonoBehaviour
{
    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }

}
