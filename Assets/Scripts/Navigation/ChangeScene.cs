using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    public void ChangeSceneOnButton(int sceneID)
    {
        StartCoroutine(LoadScene(sceneID));
    }

    IEnumerator LoadScene(int levelIndex) {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


}