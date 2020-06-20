using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float sceneDelayTime = 2.0f;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if ((other as CapsuleCollider2D) && (other.gameObject.tag == "Player"))
        {            
            StartCoroutine(LoadNextScene());
        }
        
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(sceneDelayTime);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
