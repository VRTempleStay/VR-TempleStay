using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator; // Animator 연결
    public AudioSource audioSource; // AudioSource 컴포넌트
    public AudioClip doorSlideOpen; // 문 열림 사운드
    public AudioClip doorSlideClose; // 문 닫힘 사운드

    void Start()
    {
        // AudioSource가 제대로 연결되었는지 확인
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);
        if (other.CompareTag("MainCamera")) // 플레이어가 범위에 들어오면
        {
            Debug.Log("Player entered trigger area.");
            doorAnimator.SetTrigger("Open"); // 문 열기
            PlaySound(doorSlideOpen); // 문 열림 사운드 실행
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // 플레이어가 범위를 나가면
        {
            Debug.Log("Player exited trigger area.");
            doorAnimator.SetTrigger("Close"); // 문 닫기
            PlaySound(doorSlideClose); // 문 닫힘 사운드 실행
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // 한 번만 재생
        }
    }
}
