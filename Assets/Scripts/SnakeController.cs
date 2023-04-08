using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class SnakeController : MonoBehaviour
    {
        [SerializeField] private Character defaultCharacter;
        [SerializeField] private BodyPartItem defaultBodyPart;
        [SerializeField] private float spaceBetweenPart;

        public GameObject bodyPartPrefab;
        public List<BodyPartItem> BodyParts;

        public void Awake()
        {
            BodyParts = new List<BodyPartItem>();
            defaultBodyPart.Initialize(defaultCharacter, null);
            BodyParts.Add(defaultBodyPart);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AddBodyPart(defaultCharacter);
            }
        }

        private void AddBodyPart(Character character)
        {
            int lastIndex = BodyParts.Count - 1;
            var lastBodyPartTransform = BodyParts[lastIndex].transform;
            Vector3 point = lastBodyPartTransform.position + -lastBodyPartTransform.forward * spaceBetweenPart;

            var bodyPartObject = Instantiate(bodyPartPrefab, point, lastBodyPartTransform.rotation);
            bodyPartObject.transform.SetParent(this.transform);
            var bodyPart = bodyPartObject.GetComponent<BodyPartItem>();

            bodyPart.Initialize(character, BodyParts[lastIndex]);
            BodyParts.Add(bodyPart);
        }
    }
}