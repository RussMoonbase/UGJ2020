using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public static UIManager instance;

   public bool fadeToClear;
   public bool fadeToColor;

   [SerializeField] private Image _screenImage;
   [SerializeField] private float _fadeSpeed;

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
      FadeImageInOut();
   }

   private void FadeImageInOut()
   {
      if (fadeToColor)
      {
         FadeScreenToColor();
      }

      if (fadeToClear)
      {
         FadeScreenToClear();
      }
   }

   private void FadeScreenToColor()
   {
      _screenImage.color = new Color(_screenImage.color.r, _screenImage.color.g, _screenImage.color.b,
         Mathf.MoveTowards(_screenImage.color.a, 1f, _fadeSpeed * Time.deltaTime));

      if (_screenImage.color.a == 1f)
      {
         fadeToColor = false;
      }
   }

   private void FadeScreenToClear()
   {
      _screenImage.color = new Color(_screenImage.color.r, _screenImage.color.g, _screenImage.color.b,
   Mathf.MoveTowards(_screenImage.color.a, 0f, _fadeSpeed * Time.deltaTime));

      if (_screenImage.color.a == 0f)
      {
         fadeToClear = false;
      }
   }
}
