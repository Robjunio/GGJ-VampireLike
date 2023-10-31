using System;
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

   private void Start()
   {
      blackfade.enabled = false;
   }

   public void Fade(string scene)
   {
      lvlName = scene;
      StartCoroutine(GoToNextLevel());
   }
   
   IEnumerator GoToNextLevel()
   {
      blackfade.enabled = true;
      animFade.SetBool("fade", true);
      yield return new WaitUntil(() => blackfade.color.a == 1);
      SceneManager.LoadScene(lvlName);
   }
    
    
}
