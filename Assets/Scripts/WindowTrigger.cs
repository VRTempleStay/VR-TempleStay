using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public Animator doorAnimator;        // â�� Animator ����
    public GameObject windFxPrefab;     // WindFx Prefab ����
    public AudioSource audioSource;     // AudioSource ������Ʈ
    public AudioClip openSound;         // â�� ���� �Ҹ�
    public AudioClip closeSound;        // â�� ���� �Ҹ�

    private GameObject windFxInstance;  // WindFx �ν��Ͻ�

    void Start()
    {
        // WindFx �ν��Ͻ� ���� (ó���� ��Ȱ��ȭ)
        if (windFxPrefab != null)
        {
            windFxInstance = Instantiate(windFxPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            windFxInstance.SetActive(false); // �ʱ� ���� ��Ȱ��ȭ
        }

        // AudioSource Ȯ��
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);
        if (other.CompareTag("MainCamera")) // �÷��̾ ������ ������
        {
            Debug.Log("Player entered trigger area.");
            doorAnimator.SetTrigger("Open"); // â�� ����
            PlaySound(openSound);           // ���� �Ҹ� ���
            ShowWindFx();                   // WindFx ����
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // �÷��̾ ������ ������
        {
            Debug.Log("Player exited trigger area.");
            doorAnimator.SetTrigger("Close"); // â�� �ݱ�
            PlaySound(closeSound);           // ���� �Ҹ� ���
            HideWindFx();                    // WindFx ��Ȱ��ȭ
        }
    }

    private void ShowWindFx()
    {
        if (windFxInstance != null)
        {
            windFxInstance.SetActive(true); // WindFx Ȱ��ȭ
            Animator flowerAnimator = windFxInstance.GetComponent<Animator>();
            if (flowerAnimator != null)
            {
                flowerAnimator.Play("Take 001"); // WindFx �ִϸ��̼� ���
            }
        }
    }

    private void HideWindFx()
    {
        if (windFxInstance != null)
        {
            Animator flowerAnimator = windFxInstance.GetComponent<Animator>();
            if (flowerAnimator != null)
            {
                flowerAnimator.StopPlayback(); // WindFx �ִϸ��̼� ����
            }
            windFxInstance.SetActive(false); // WindFx ��Ȱ��ȭ
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // �Ҹ��� �� �� ���
        }
    }
}
