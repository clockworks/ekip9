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

        Model.DOLocalMoveY(1, 1f).SetLoops(-1, LoopType.Yoyo);
    }
}