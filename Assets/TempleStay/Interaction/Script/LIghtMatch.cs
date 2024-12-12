using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIghtMatch : MonoBehaviour
{
    // Start is called before the first frame update
    public Material lightOffMat;
    public Material lightOnMat;

    [Header("Match")]
    [Tooltip ("성냥 타는시간")]
    public float matchDuration = 20.0f;
    [SerializeField]
    private float duration = 0.0f;

    [Tooltip("성냥에 불이 붙기 위한 최소속력")]
    public float lightThreshold = 0.1f; 

    [Space (10f)]

    [Header("MatchState")]
    [SerializeField]
    private bool IsLightOn = false;

    [Tooltip("성냥에 불이 붙을 확률")]
    public float successRate = 0.7f;
    private float currentSuccessRate;

    private Rigidbody rb;
    private MeshRenderer mr;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        currentSuccessRate = successRate;
        mr.material = lightOffMat;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (IsLightOn)
        {
            matchDuration -=Time.deltaTime;
        }
        if (matchDuration < 0.0f)
        {
            LightOff();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MatchCase"))
        {

            if (rb.velocity.magnitude >= lightThreshold)
            {

                float rate = Random.value;
                if (rate >= 1 - currentSuccessRate)
                {
                    LightOn();
                    currentSuccessRate = successRate;

                }
                else
                {
                    currentSuccessRate += 0.2f;
                }
            }

        }
    }


    private void LightOn()
    {
        IsLightOn = true;
        mr.material = lightOnMat;
        duration = matchDuration;
        Debug.Log("LightOn");
    }

    private void LightOff()
    {
        IsLightOn = false;
        mr.material = lightOffMat;
        duration = 0;
    }
    public bool GetLightOn()
    {
        return IsLightOn;
    }

}
