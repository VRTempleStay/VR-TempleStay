using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator; // Animator ����
    public AudioSource audioSource; // AudioSource ������Ʈ
    public AudioClip doorSlideOpen; // �� ���� ����
    public AudioClip doorSlideClose; // �� ���� ����

    void Start()
    {
        // AudioSource�� ����� ����Ǿ����� Ȯ��
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
            doorAnimator.SetTrigger("Open"); // �� ����
            PlaySound(doorSlideOpen); // �� ���� ���� ����
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // �÷��̾ ������ ������
        {
            Debug.Log("Player exited trigger area.");
            doorAnimator.SetTrigger("Close"); // �� �ݱ�
            PlaySound(doorSlideClose); // �� ���� ���� ����
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // �� ���� ���
        }
    }
}
