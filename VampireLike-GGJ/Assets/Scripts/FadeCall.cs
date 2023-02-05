using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class FadeCall : MonoBehaviour
{
   public Image blackfade;
   public Animator animFade;
   private string lvlName;
   
   public void Fade(string scene)
   {
      lvlName = scene;
      StartCoroutine(GoToNextLevel());
   }
   
   IEnumerator GoToNextLevel()
   {
      animFade.SetBool("fade", true);
      yield return new WaitUntil(() => blackfade.color.a == 1);
      UnityEngine.SceneManagement.SceneManager.LoadScene(lvlName);
   }
    
    
}
