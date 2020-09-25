using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace SwipeableView
{
    public class LoadTextureScene : MonoBehaviour
    {
        [SerializeField]
        private UISwipeableViewLoadTexture swipeableView = default;

        private GameController gameController;

        private string m_Path;
        private static readonly string[] _imageUrls =
        {
            "/img/card1.png",
            "/img/card2.png",
            "/img/card3.png",
            "/img/card4.png",
            "/img/card5.png",
            "/img/card6.png",
            "/img/card7.png",
            "/img/card8.png",
            "/img/card9.png",
            "/img/card10.png"

        };
        // ALTERADO **********************************************
        private static readonly Dictionary<string,bool> cards = new Dictionary<string,bool> () {
            {"/img/card1.png", true},
            {"/img/card2.png", false},
        };
        
        public static bool[] answers = new bool[] {
            false,
            false,
            true,
            false,
            false,
            false,
            true,
            true,
            false,
            true
            };

        //
        void Start()
        {
            m_Path = Application.dataPath;
            var data = _imageUrls
                .Select(imageUrl => new LoadTextureCardData
                {
                    url = m_Path + imageUrl
                })
                .ToList();
            var data2 = cards
                .Select(card => new LoadTextureCardData
                {
                    url = m_Path + card.Key,
                    isCorrect = card.Value
                })
                .ToList();

            swipeableView.UpdateData(data);
            gameController = FindObjectOfType<GameController>();
        }

        public void OnClickLike()
        {
            if (swipeableView.IsAutoSwiping) return;
            swipeableView.AutoSwipe(SwipeDirection.Right);
            
            //Debug.Log(swipeableView.GetDataValue());
            gameController.LikeAnswerButtonClicked();
        }

        public void OnClickNope()
        {
            if (swipeableView.IsAutoSwiping) return;
            swipeableView.AutoSwipe(SwipeDirection.Left);
            
            gameController.NopeAnswerButtonClicked();
        }

    }
}