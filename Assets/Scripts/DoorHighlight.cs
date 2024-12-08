using UnityEngine;

public class DoorHighlight : MonoBehaviour
{
    public Material highlightMaterial; // 하이라이트용 Material
    public Material defaultMaterial;   // 기본 Material
    private Renderer doorRenderer;

    void Start()
    {
        doorRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) // 플레이어가 문에 가까워질 때
        {
            Debug.Log("Player entered highlight trigger area.");
            doorRenderer.material = highlightMaterial;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera")) // 플레이어가 문에서 멀어질 때
        {
            Debug.Log("Player exited highlight trigger area.");
            doorRenderer.material = defaultMaterial;
        }
    }
}
