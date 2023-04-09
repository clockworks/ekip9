using DefaultNamespace;
using DefaultNamespace.TurnBasedGame;
using DG.Tweening;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private MeshRenderer renderer;
    private Knight knight;
    [SerializeField] private Transform Model;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.BonusHealth++;
        Destroy(this.gameObject);
    }

    private void Start()
    {
        Debug.Log("Start");

        Sequence sequence = DOTween.Sequence();

        sequence.Append(Model.DOLocalMoveY(1, .5f));
        sequence.Append(Model.DOLocalMoveY(0, .5f));
        sequence.Append(Model.DOLocalMoveY(1, .5f));
        sequence.Play();
    }
}