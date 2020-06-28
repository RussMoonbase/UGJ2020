using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public static SceneLoader instance;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   public void LoadNextScene()
   {
      int sceneNum = SceneManager.GetActiveScene().buildIndex;
      sceneNum++;
      SceneManager.LoadScene(sceneNum);
   }

   public void LoadMainMenu()
   {
      SceneManager.LoadScene(0);
   }
}
