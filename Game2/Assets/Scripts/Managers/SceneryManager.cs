using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneryManager : Singleton<SceneryManager>
{
    [SerializeField] UnityEngine.UI.Image screenImage;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public IEnumerator AsyncLoad(int index)
    {
       
        screenImage.gameObject.SetActive(true);

        // <asyncOperation.allowSceneAtivation>
        // 장면이 준비된 즉시 장면이 활성화되는 것을 허용하는 변수입니다.

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        color.a = 0f;

        // <asyncOperation.isDone>
        // 해당 동작이 완료되었는지 나타내는 변수입니다.
        
        while (asyncOperation.isDone==false)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            // <asyncOperation.progress>
            // 작업의 진행 상태를 나타내는 변수입니다.

            if(asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);

                screenImage.color = color;
                if(color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation= true;

                    yield break;
                }
            }
        
          yield return null;
        
        }


    }

    void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
