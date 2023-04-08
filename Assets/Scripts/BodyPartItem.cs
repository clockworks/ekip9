using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class BodyPartItem : MonoBehaviour
    {
        [SerializeField] private Character holdingCharacter;
        private BodyPartItem _connectedBodyPartItem;
        private Tween _moveTween;
        private Tween _lookTween;

        [SerializeField] private float speed;
        [SerializeField] private float addInterval;
        [SerializeField] private float threshold = .1f;
        
        private Vector3 _currentTarget;

        public Queue<Vector3> lastPoints;
        private Rigidbody _rigidbody;
        private float timer;
        private int seconds;
        private bool _isConnected;

        public void Initialize(Character character, BodyPartItem connectedBodyPart)
        {
            holdingCharacter = character;
            _connectedBodyPartItem = connectedBodyPart;
            _currentTarget = Vector3.one * -1;
            lastPoints = new Queue<Vector3>();
            this.gameObject.SetActive(true);
            _connectedBodyPartItem?.SetConnected(true);
            _rigidbody = this.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_connectedBodyPartItem == null)
            {
                return;
            }

            if (_lookTween == null)
            {
                _lookTween = this.transform.DOLookAt(_connectedBodyPartItem.transform.position, .1f).OnComplete(() => { _lookTween = null; });
            }
        }
        
        private void UpdatePointList()
        {
            lastPoints.Enqueue(this.transform.position);
        }

        public void SetConnected(bool isConnect)
        {
            _isConnected = isConnect;
        }
        
        private void LateUpdate()
        {
            timer += Time.deltaTime;
            seconds = (int) (timer % 60);

            if (_isConnected && timer >= addInterval)
            {
                UpdatePointList();
                timer = 0;
            }
            
            Move();
        }

        private void Move()
        {
            if (_connectedBodyPartItem == null)
            {
                return;
            }

            if (_currentTarget == Vector3.one * -1)
            {
                _currentTarget = _connectedBodyPartItem.lastPoints.Dequeue();
            }

            Vector3 direction = (_currentTarget - transform.position).normalized;
            
            this.transform.position += direction * speed * Time.deltaTime;
            float distance = Vector3.Distance(this.transform.position, _currentTarget);

            if (distance <= threshold)
            {
                _currentTarget = _connectedBodyPartItem.lastPoints.Dequeue();
            }
        }
    }
}