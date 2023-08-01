using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "CarStaticData", menuName = "StaticData/Car")]
    public class CarStaticData : ScriptableObject
    {
        [Range(400,2000)]
        public float Speed = 800f;
        [Range(1000,3000)]
        public float RotationSpeed = 1800f;
        [Range(0.01f,1f)]
        public float SuspensionDamping = .25f;
        [Range(0.05f,4f)]
        public float CarMass = 2f;
    }
}