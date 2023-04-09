using DG.Tweening;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.TurnBasedGame
{
    public class TurnPanel : MonoBehaviour
    {
        public TextMeshProUGUI ActionPointText;
        public TextMeshProUGUI TurnText;
        public TextMeshProUGUI TimerText;

        public void ShowHide(bool isShow)
        {
            this.gameObject.SetActive(isShow);
        }

        public void ShowTurnText(bool isPlayerTurn)
        {
            TurnText.text = isPlayerTurn ? "Your Turn" : "Oppponent Turn";
            TurnText.transform.DOShakeScale(.2f);
        }

        public void ActionPointChange(int actionPoint)
        {
            ActionPointText.text = actionPoint.ToString();
            ActionPointText.transform.DOPunchScale(Vector3.one, .5f);
        }
    }
}