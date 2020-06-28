using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
   public static UIManager instance;

   public bool fadeToClear;
   public bool fadeToColor;

   // loaded in Inspector
   [SerializeField] private Image _screenImage;
   [SerializeField] private float _fadeSpeed;
   [SerializeField] private TextMeshProUGUI _player1ScoreText; 
   [SerializeField] private TextMeshProUGUI _player2ScoreText;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
      UpdatePlayer1Score(0);
      UpdatePlayer2Score(0);
   }

   // Update is called once per frame
   void Update()
   {
      FadeImageInOut();
   }

   public void UpdatePlayer1Score(int score)
   {
      string scoreText;

      if (score == 0)
      {
         scoreText = " ";
      }
      else if (score == 1)
      {
         scoreText = "W";
      }
      else if (score == 2)
      {
         scoreText = "W W";
      }
      else if (score == 3)
      {
         scoreText = "W W W";
      }
      else
      {
         scoreText = " ";
      }

      _player1ScoreText.text = scoreText;
   }

   public void UpdatePlayer2Score(int score)
   {
      string scoreText;

      if (score == 0)
      {
         scoreText = " ";
      }
      else if (score == 1)
      {
         scoreText = "W";
      }
      else if (score == 2)
      {
         scoreText = "W W";
      }
      else if (score == 3)
      {
         scoreText = "W W W";
      }
      else
      {
         scoreText = " ";
      }

      _player2ScoreText.text = scoreText;
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
