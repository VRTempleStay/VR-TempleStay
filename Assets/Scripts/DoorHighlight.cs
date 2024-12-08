using UnityEngine;

public class DoorHighlight : MonoBehaviour
{
    public Material highlightMaterial; // ���̶���Ʈ�� Material
    public Material defaultMaterial;   // �⺻ Material
    private Renderer doorRenderer;

    void Start()
    {
        doorRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) // �÷��̾ ���� ������� ��
        {
            Debug.Log("Player entered highlight trigger area.");
            doorRenderer.material = highlightMaterial;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // �÷��̾ ������ �־��� ��
        {
            Debug.Log("Player exited highlight trigger area.");
            doorRenderer.material = defaultMaterial;
        }
    }
}
