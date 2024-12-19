using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MusicControlTrigger : MonoBehaviour
{
    [Header("음악 설정")]
    [Tooltip("제어할 AudioSource를 할당하세요.")]
    public AudioSource musicAudioSource;

    [Header("볼륨 설정")]
    [Tooltip("트리거 영역 내에 있을 때 음악의 볼륨 (0: 음소거, 1: 원래 볼륨)")]
    [Range(0f, 1f)]
    public float insideVolume = 0f;

    [Tooltip("트리거 영역 밖에 있을 때 음악의 볼륨 (0: 음소거, 1: 원래 볼륨)")]
    [Range(0f, 1f)]
    public float outsideVolume = 1f;

    private bool isPlayerInside = false;

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
            Debug.Log("MainCamera가 트리거 영역에 들어왔습니다.");
            if (musicAudioSource != null)
            {
                musicAudioSource.volume = insideVolume;
                isPlayerInside = true;
            }
            else
            {
                Debug.LogError("Music AudioSource가 할당되지 않았습니다.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("MainCamera가 트리거 영역을 나갔습니다.");
            if (musicAudioSource != null)
            {
                musicAudioSource.volume = outsideVolume;
                isPlayerInside = false;
            }
            else
            {
                Debug.LogError("Music AudioSource가 할당되지 않았습니다.");
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
