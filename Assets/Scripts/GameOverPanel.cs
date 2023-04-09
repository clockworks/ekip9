using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameOverPanel : MonoBehaviour
    {
        public GameObject camera;

        public void ShowHide(bool isShow)
        {
            camera.gameObject.SetActive(isShow);
            Vector3 start = new Vector3(0, 31.5f, 17);
            Vector3 end = new Vector3(0, 31.5f, 252f);
            camera.transform.DOPath(new Vector3[2] {start, end}, 30).SetLoops(-1, LoopType.Yoyo);
            this.gameObject.SetActive(isShow);
        }
    }
}