using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public Animator doorAnimator;        // 창문 Animator 연결
    public GameObject windFxPrefab;     // WindFx Prefab 연결
    public AudioSource audioSource;     // AudioSource 컴포넌트
    public AudioClip openSound;         // 창문 열림 소리
    public AudioClip closeSound;        // 창문 닫힘 소리

    private GameObject windFxInstance;  // WindFx 인스턴스

    void Start()
    {
        // WindFx 인스턴스 생성 (처음엔 비활성화)
        if (windFxPrefab != null)
        {
            windFxInstance = Instantiate(windFxPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            windFxInstance.SetActive(false); // 초기 상태 비활성화
        }

        // AudioSource 확인
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
            doorAnimator.SetTrigger("Open"); // 창문 열기
            PlaySound(openSound);           // 열림 소리 재생
            ShowWindFx();                   // WindFx 실행
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // 플레이어가 범위를 나가면
        {
            Debug.Log("Player exited trigger area.");
            doorAnimator.SetTrigger("Close"); // 창문 닫기
            PlaySound(closeSound);           // 닫힘 소리 재생
            HideWindFx();                    // WindFx 비활성화
        }
    }

    private void ShowWindFx()
    {
        if (windFxInstance != null)
        {
            windFxInstance.SetActive(true); // WindFx 활성화
            Animator flowerAnimator = windFxInstance.GetComponent<Animator>();
            if (flowerAnimator != null)
            {
                flowerAnimator.Play("Take 001"); // WindFx 애니메이션 재생
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
                flowerAnimator.StopPlayback(); // WindFx 애니메이션 정지
            }
            windFxInstance.SetActive(false); // WindFx 비활성화
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // 소리를 한 번 재생
        }
    }
}
