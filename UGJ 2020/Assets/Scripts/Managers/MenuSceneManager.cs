using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneManager : MonoBehaviour
{
   public string p1StartButton;
   public string p2StartButton;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown(p1StartButton) || Input.GetButtonDown(p2StartButton))
      {
         SceneLoader.instance.LoadNextScene();
      }
   }
}
