using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    public string targetSceneName; // 전환할 씬의 이름
    public float waitTime = 3f;    // 대기 시간 (초)

    private float timer = 0f;
    private bool isPlayerInside = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);
        if (other.CompareTag("MainCamera")) // 플레이어가 범위에 들어오면
        {
            Debug.Log("Player entered trigger area.");
            isPlayerInside = true;
            timer = 0f; // 타이머 초기화
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // 플레이어가 범위를 나가면
        {
            Debug.Log("Player exited trigger area.");
            isPlayerInside = false;
            timer = 0f; // 타이머 리셋
        }
    }

    void Update()
    {
        if (isPlayerInside)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                Debug.Log("Player has been inside the trigger for " + waitTime + " seconds. Changing scene to " + targetSceneName);
                SceneManager.LoadScene(targetSceneName);
            }
        }
    }

    void OnDrawGizmos()
    {
        // Trigger Collider를 시각화
        Gizmos.color = Color.green;
        BoxCollider collider = GetComponent<BoxCollider>();
        if (collider != null)
        {
            Gizmos.DrawWireCube(transform.position + collider.center, collider.size);
        }
    }
}
