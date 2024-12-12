using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIncense : MonoBehaviour
{
    public float threshold = 4.0f;
    private float currentLightTime = 0;
    [SerializeField]
    private bool IsIncenseOn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Match"))
        {
            if (other.GetComponent<LIghtMatch>().GetLightOn())
            {
                currentLightTime += Time.deltaTime;
                if (currentLightTime > threshold && !IsIncenseOn)
                {
                    IncenseOn();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsIncenseOn)
        {

        }
    }

    private void IncenseOn()
    {
        IsIncenseOn = true;
        Debug.Log("IncenseOn");
    }
}
