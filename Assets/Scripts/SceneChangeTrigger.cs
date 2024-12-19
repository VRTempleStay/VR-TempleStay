using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChangeTrigger : MonoBehaviour
{
    public string targetSceneName;
    public float waitTime = 3f;

    private bool isPlayerInside = false;
    private Coroutine waitCoroutine;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Player entered 방석 area.");
            isPlayerInside = true;
            if (waitCoroutine == null)
            {
                waitCoroutine = StartCoroutine(WaitAndLoadScene());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Player exited 방석 area.");
            isPlayerInside = false;
            if (waitCoroutine != null)
            {
                StopCoroutine(waitCoroutine);
                waitCoroutine = null;
            }
        }
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(waitTime);
        if (isPlayerInside) // 마지막으로 확인
        {
            Debug.Log("Changing scene to " + targetSceneName);
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
