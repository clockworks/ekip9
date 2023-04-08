using UnityEngine;

namespace DefaultNamespace
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform player;
        public float smoothTime = 0.3f;
        public float zOffset = 0.0f;

        private Vector3 velocity = Vector3.zero;

        private void Update()
        {
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, player.position.z + zOffset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}