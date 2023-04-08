using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class Timer : MonoBehaviour
    {
        public float _totalTime = 60f;
        private float _currentTime;
        private bool _isStarted;
        private Action _onComplete;
        private Action<int> _onUpdate;

        public void StartTimer(Action<int> onUpdate, Action onComplete)
        {
            _onComplete = onComplete;
            _onUpdate = onUpdate;
            _currentTime = _totalTime;
        }

        public void Stop()
        {
            _isStarted = false;
        }
        
        private void Update()
        {
            if (!_isStarted)
            {
                return;
            }

            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
            {
                _currentTime = 0;
                Debug.Log("Time's up!");
                _onComplete?.Invoke();
            }

            int seconds = Mathf.FloorToInt(_currentTime % 60f);
            _onUpdate?.Invoke(seconds);
        }
    }
}