using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayTask : MonoBehaviour, Interactable
{
    public void action()
    {
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadScene(1);
    }
}
