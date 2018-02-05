using UnityEngine;
using System.Collections;

/* 1. The code here is for the FadePanel that was created.
 2. We are creating the MakeSingleton function so that the SceneFader can be used in
 other program files as well.*/
public class SceneFader : MonoBehaviour {

    public static SceneFader instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnim;

    void Awake()
    {
        MakeSingleton();
    }	

   void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

/* 1. First we are setting the fadePanel active and then playing the animation. 
 2. Later we are loading the appliaction and playing the fadeOut.
 3. and last we are deactivating the fadePanel.*/
    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        fadeAnim.Play("FadeIn");
        
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));

        Application.LoadLevel(level);
        fadeAnim.Play("FadeOut");

        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(0.7f));
        fadePanel.SetActive(false);
    }
}
