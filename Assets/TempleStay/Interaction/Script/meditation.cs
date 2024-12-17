using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meditation : MonoBehaviour
{

    public float waitTime = 5.0f;
    private float elapsedTime = 0.0f;
    private AsyncOperation asyncLoad;
    [SerializeField]
    private string SceneName ="";
    // Start is called before the first frame update
    void Start()
    {
        MyScreenFade.instance.SetCallback(MeditationOn);
    }

    // Update is called once per frame
    void Update()
    {

        if (elapsedTime >= waitTime)
        {
            elapsedTime = 0.0f;
            MyScreenFade.instance.FadeOut();
            
        }
        
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("HMDHead"))
        {
            if (elapsedTime >= 0.0f && asyncLoad == null)
            {
                asyncLoad = SceneManager.LoadSceneAsync(SceneName);
            }
            elapsedTime += Time.deltaTime;
            
            Debug.Log(elapsedTime);
        }
    }
   
    private void MeditationOn()
    {
        Debug.Log("Start");
        asyncLoad.allowSceneActivation = true;
    }
}
