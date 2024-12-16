using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public Animator doorAnimator;        // 창문 Animator 연결
    public GameObject windFxPrefab;    // FlowerFx Prefab 연결
    private GameObject windFxInstance; // FlowerFx 인스턴스

    void Start()
    {
        // FlowerFx 인스턴스 생성 (처음엔 비활성화)
        if (windFxPrefab != null)
        {
            windFxInstance = Instantiate(windFxPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            windFxInstance.SetActive(false); // 초기 상태 비활성화
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);
        if (other.CompareTag("MainCamera")) // 플레이어가 범위에 들어오면
        {
            Debug.Log("Player entered trigger area.");
            doorAnimator.SetTrigger("Open"); // 창문 열기
            ShowWindFx();                  // FlowerFx 실행
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // 플레이어가 범위를 나가면
        {
            Debug.Log("Player exited trigger area.");
            doorAnimator.SetTrigger("Close"); // 창문 닫기
            HideFlowerFx();                   // FlowerFx 비활성화
        }
    }

    private void ShowWindFx()
    {
        if (windFxInstance != null)
        {
            windFxInstance.SetActive(true); // FlowerFx 활성화
            Animator flowerAnimator = windFxInstance.GetComponent<Animator>();
            if (flowerAnimator != null)
            {
                flowerAnimator.Play("Take 001"); // FlowerFx 애니메이션 재생
            }
        }
    }

    private void HideFlowerFx()
    {
        if (windFxInstance != null)
        {
            Animator flowerAnimator = windFxInstance.GetComponent<Animator>();
            if (flowerAnimator != null)
            {
                flowerAnimator.StopPlayback(); // FlowerFx 애니메이션 정지
            }
            windFxInstance.SetActive(false); // FlowerFx 비활성화
        }
    }
}
