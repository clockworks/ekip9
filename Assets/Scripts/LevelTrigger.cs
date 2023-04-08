using UnityEngine;

namespace DefaultNamespace
{
    public class LevelTrigger : MonoBehaviour
    {
        public Level Level;
        private void OnTriggerEnter(Collider other)
        {
            var snake = other.transform.parent.GetComponent<SnakeController>();
            snake.SetActive(false);
            Level.Initialize();
            this.gameObject.SetActive(false);
        }
    }
}