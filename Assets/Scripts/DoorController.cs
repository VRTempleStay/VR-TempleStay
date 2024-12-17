using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator; // ���� ����� Animator
    private bool isOpen = false; // ���� ���ȴ��� ���� üũ

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // "E" Ű�� ������ �� ���� ���ų� ����
        {
            if (isOpen)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        doorAnimator.SetTrigger("Open"); // Animator���� "Open" Ʈ���� ����
        isOpen = true;
    }

    void CloseDoor()
    {
        doorAnimator.SetTrigger("Close"); // Animator���� "Close" Ʈ���� ����
        isOpen = false;
    }
}
