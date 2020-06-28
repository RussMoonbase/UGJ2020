using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   public static MusicManager instance;
   public AudioSource audioSourceMusic;
   public float turnDownSpeed;

   public bool gameFinished = false;

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
      if (gameFinished)
      {
         TurnDownMusic();
      }
   }

   private void TurnDownMusic()
   {
      audioSourceMusic.volume = Mathf.MoveTowards(audioSourceMusic.volume, 0f, turnDownSpeed * Time.deltaTime);
   }


}
