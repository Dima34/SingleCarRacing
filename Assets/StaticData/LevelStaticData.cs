using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public Vector3 StartPosition;
        public Vector3 FinishPosition;
        public Vector3 GroundPosition;
        public Quaternion GroundRotation;
        public Vector3 GroundScale;
        public GameObject GroundPrefab;
    }
}