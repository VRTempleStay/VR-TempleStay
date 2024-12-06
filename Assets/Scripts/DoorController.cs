using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator; // 문에 연결된 Animator
    private bool isOpen = false; // 문이 열렸는지 상태 체크

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // "E" 키를 눌렀을 때 문을 열거나 닫음
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
        doorAnimator.SetTrigger("Open"); // Animator에서 "Open" 트리거 실행
        isOpen = true;
    }

    void CloseDoor()
    {
        doorAnimator.SetTrigger("Close"); // Animator에서 "Close" 트리거 실행
        isOpen = false;
    }
}
