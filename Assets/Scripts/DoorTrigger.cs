using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator; // Animator 연결

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);
        if (other.CompareTag("MainCamera")) // 플레이어가 범위에 들어오면
        {
            Debug.Log("Player entered trigger area.");
            doorAnimator.SetTrigger("Open");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // 플레이어가 범위를 나가면
        {
            Debug.Log("Player exited trigger area.");
            doorAnimator.SetTrigger("Close"); // Close 애니메이션 실행
        }
    }

    void OnDrawGizmos()
    {
        // Trigger Collider를 시각화
        Gizmos.color = Color.green;
        BoxCollider collider = GetComponent<BoxCollider>();
        if (collider != null)
        {
            Gizmos.DrawWireCube(collider.center + transform.position, collider.size);
        }
    }
}
