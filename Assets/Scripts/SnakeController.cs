using System.Collections.Generic;
using DefaultNamespace.TurnBasedGame;
using UnityEngine;

namespace DefaultNamespace
{
    public class SnakeController : MonoBehaviour
    {
        [SerializeField] private Character defaultCharacter;
        [SerializeField] private BodyPartItem defaultBodyPart;
        [SerializeField] private float spaceBetweenPart;

        public List<GameObject> CharacterPrefabs;

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
                AddBodyPart(CharacterType.Mage);
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                AddBodyPart(CharacterType.Archer);
            }
        }

        public void AddBodyPart(CharacterType characterType)
        {
            int lastIndex = BodyParts.Count - 1;
            var lastBodyPartTransform = BodyParts[lastIndex].transform;
            Vector3 point = lastBodyPartTransform.position + -lastBodyPartTransform.forward * spaceBetweenPart;

            var bodyPartObject = Instantiate(bodyPartPrefab, point, lastBodyPartTransform.rotation);
            bodyPartObject.transform.SetParent(this.transform);
            var bodyPart = bodyPartObject.GetComponent<BodyPartItem>();
            var characterClone = Instantiate(CharacterPrefabs[(int) characterType]);
            characterClone.transform.SetParent(bodyPart.transform);
            characterClone.transform.localPosition = Vector3.zero;
            var character = characterClone.GetComponent<Character>();

            bodyPart.Initialize(character, BodyParts[lastIndex]);
            BodyParts.Add(bodyPart);
        }

        public void SetActive(bool isActive)
        {
            this.gameObject.SetActive(isActive);
        }
    }
}