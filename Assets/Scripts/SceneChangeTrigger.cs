using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class SceneChangeTrigger : MonoBehaviour
{
    [Header("씬 설정")]
    [Tooltip("전환할 씬의 이름")]
    public string targetSceneName;

    [Header("전환 설정")]
    [Tooltip("플레이어가 트리거 내에 머물러야 하는 시간 (초)")]
    public float waitTime = 3f;

    private float timer = 0f;
    private bool isPlayerInside = false;
    private bool hasChangedScene = false;

    private void Reset()
    {
        // Collider가 Trigger로 설정되어 있는지 확인
        Collider collider = GetComponent<Collider>();
        if (collider != null && !collider.isTrigger)
        {
            collider.isTrigger = true;
            Debug.LogWarning("Collider가 Trigger로 설정되지 않았습니다. 자동으로 Trigger로 변경했습니다.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("MainCamera가 트리거 영역에 진입했습니다.");
            isPlayerInside = true;
            timer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("MainCamera가 트리거 영역을 벗어났습니다.");
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
                Debug.Log($"MainCamera가 {waitTime}초 동안 트리거 내에 있었습니다. '{targetSceneName}' 씬으로 전환합니다.");
                SceneManager.LoadScene(targetSceneName);
                hasChangedScene = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Trigger Collider 시각화
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
                // 캡슐 콜라이더의 경우 추가 시각화가 필요할 수 있습니다.
            }
            // 다른 콜라이더 타입도 필요 시 추가 가능
        }
    }
}
