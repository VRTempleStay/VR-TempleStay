using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MusicControlTrigger : MonoBehaviour
{
    [Header("���� ����")]
    [Tooltip("������ AudioSource�� �Ҵ��ϼ���.")]
    public AudioSource musicAudioSource;

    [Header("���� ����")]
    [Tooltip("Ʈ���� ���� ���� ���� �� ������ ���� (0: ���Ұ�, 1: ���� ����)")]
    [Range(0f, 1f)]
    public float insideVolume = 0f;

    [Tooltip("Ʈ���� ���� �ۿ� ���� �� ������ ���� (0: ���Ұ�, 1: ���� ����)")]
    [Range(0f, 1f)]
    public float outsideVolume = 1f;

    private bool isPlayerInside = false;

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
            Debug.Log("MainCamera�� Ʈ���� ������ ���Խ��ϴ�.");
            if (musicAudioSource != null)
            {
                musicAudioSource.volume = insideVolume;
                isPlayerInside = true;
            }
            else
            {
                Debug.LogError("Music AudioSource�� �Ҵ���� �ʾҽ��ϴ�.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("MainCamera�� Ʈ���� ������ �������ϴ�.");
            if (musicAudioSource != null)
            {
                musicAudioSource.volume = outsideVolume;
                isPlayerInside = false;
            }
            else
            {
                Debug.LogError("Music AudioSource�� �Ҵ���� �ʾҽ��ϴ�.");
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
