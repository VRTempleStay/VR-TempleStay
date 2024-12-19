using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class SceneChangeTrigger : MonoBehaviour
{
    [Header("�� ����")]
    [Tooltip("��ȯ�� ���� �̸�")]
    public string targetSceneName;

    [Header("��ȯ ����")]
    [Tooltip("�÷��̾ Ʈ���� ���� �ӹ����� �ϴ� �ð� (��)")]
    public float waitTime = 3f;

    private float timer = 0f;
    private bool isPlayerInside = false;
    private bool hasChangedScene = false;

    private void Reset()
    {
        // Collider�� Trigger�� �����Ǿ� �ִ��� Ȯ��
        Collider collider = GetComponent<Collider>();
        if (collider != null && !collider.isTrigger)
        {
            collider.isTrigger = true;
            Debug.LogWarning("Collider�� Trigger�� �������� �ʾҽ��ϴ�. �ڵ����� Trigger�� �����߽��ϴ�.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("MainCamera�� Ʈ���� ������ �����߽��ϴ�.");
            isPlayerInside = true;
            timer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("MainCamera�� Ʈ���� ������ ������ϴ�.");
            isPlayerInside = false;
            timer = 0f;
        }
    }

    private void Update()
    {
        if (isPlayerInside && !hasChangedScene)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                Debug.Log($"MainCamera�� {waitTime}�� ���� Ʈ���� ���� �־����ϴ�. '{targetSceneName}' ������ ��ȯ�մϴ�.");
                SceneManager.LoadScene(targetSceneName);
                hasChangedScene = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Trigger Collider �ð�ȭ
        Gizmos.color = Color.green;
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            if (collider is BoxCollider box)
            {
                Gizmos.DrawWireCube(box.center, box.size);
            }
            else if (collider is SphereCollider sphere)
            {
                Gizmos.DrawWireSphere(sphere.center, sphere.radius);
            }
            else if (collider is CapsuleCollider capsule)
            {
                Gizmos.DrawWireSphere(capsule.center, capsule.radius);
                // ĸ�� �ݶ��̴��� ��� �߰� �ð�ȭ�� �ʿ��� �� �ֽ��ϴ�.
            }
            // �ٸ� �ݶ��̴� Ÿ�Ե� �ʿ� �� �߰� ����
        }
    }
}
