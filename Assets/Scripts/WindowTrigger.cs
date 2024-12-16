using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public Animator doorAnimator;        // â�� Animator ����
    public GameObject windFxPrefab;    // FlowerFx Prefab ����
    private GameObject windFxInstance; // FlowerFx �ν��Ͻ�

    void Start()
    {
        // FlowerFx �ν��Ͻ� ���� (ó���� ��Ȱ��ȭ)
        if (windFxPrefab != null)
        {
            windFxInstance = Instantiate(windFxPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            windFxInstance.SetActive(false); // �ʱ� ���� ��Ȱ��ȭ
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);
        if (other.CompareTag("MainCamera")) // �÷��̾ ������ ������
        {
            Debug.Log("Player entered trigger area.");
            doorAnimator.SetTrigger("Open"); // â�� ����
            ShowWindFx();                  // FlowerFx ����
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // �÷��̾ ������ ������
        {
            Debug.Log("Player exited trigger area.");
            doorAnimator.SetTrigger("Close"); // â�� �ݱ�
            HideFlowerFx();                   // FlowerFx ��Ȱ��ȭ
        }
    }

    private void ShowWindFx()
    {
        if (windFxInstance != null)
        {
            windFxInstance.SetActive(true); // FlowerFx Ȱ��ȭ
            Animator flowerAnimator = windFxInstance.GetComponent<Animator>();
            if (flowerAnimator != null)
            {
                flowerAnimator.Play("Take 001"); // FlowerFx �ִϸ��̼� ���
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
                flowerAnimator.StopPlayback(); // FlowerFx �ִϸ��̼� ����
            }
            windFxInstance.SetActive(false); // FlowerFx ��Ȱ��ȭ
        }
    }
}
