using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator; // Animator ����

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);
        if (other.CompareTag("MainCamera")) // �÷��̾ ������ ������
        {
            Debug.Log("Player entered trigger area.");
            doorAnimator.SetTrigger("Open");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // �÷��̾ ������ ������
        {
            Debug.Log("Player exited trigger area.");
            doorAnimator.SetTrigger("Close"); // Close �ִϸ��̼� ����
        }
    }

    void OnDrawGizmos()
    {
        // Trigger Collider�� �ð�ȭ
        Gizmos.color = Color.green;
        BoxCollider collider = GetComponent<BoxCollider>();
        if (collider != null)
        {
            Gizmos.DrawWireCube(collider.center + transform.position, collider.size);
        }
    }
}
