using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    public string targetSceneName; // ��ȯ�� ���� �̸�
    public float waitTime = 3f;    // ��� �ð� (��)

    private float timer = 0f;
    private bool isPlayerInside = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);
        if (other.CompareTag("MainCamera")) // �÷��̾ ������ ������
        {
            Debug.Log("Player entered trigger area.");
            isPlayerInside = true;
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // �÷��̾ ������ ������
        {
            Debug.Log("Player exited trigger area.");
            isPlayerInside = false;
            timer = 0f; // Ÿ�̸� ����
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
        // Trigger Collider�� �ð�ȭ
        Gizmos.color = Color.green;
        BoxCollider collider = GetComponent<BoxCollider>();
        if (collider != null)
        {
            Gizmos.DrawWireCube(transform.position + collider.center, collider.size);
        }
    }
}
