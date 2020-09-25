using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScenes : MonoBehaviour
{
    public void Change (string sceneName){
        SceneManager.LoadScene (sceneName);
    }

}
