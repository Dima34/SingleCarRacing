using System.Linq;
using Infrastructure.Constants;
using StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(LevelStaticData))]
public class LevelStaticDataEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelStaticData levelData = (LevelStaticData)target;

        if (GUILayout.Button("Collect"))
        {
            AddSceneNameData(levelData);
            TryAddGroundData(levelData);
            TryAddStartData(levelData);
            TryAddFinishData(levelData);


            EditorUtility.SetDirty(levelData);
        }
    }

    private static void AddSceneNameData(LevelStaticData levelData)
    {
        levelData.LevelKey = SceneManager.GetActiveScene().name;
    }

    private static void TryAddGroundData(LevelStaticData levelData)
    {
        GameObject groundObject = GameObject.FindGameObjectWithTag(Tags.GROUND_TAG);
        if (groundObject != null)
        {
            FillByGroundData(levelData, groundObject);
        }
        else
        {
            FillByEmptyGroundData(levelData);
            Debug.LogWarning($"Can`t find ground. Mark object by '{Tags.GROUND_TAG}' tag");
        }
    }

    private static void FillByEmptyGroundData(LevelStaticData levelData)
    {
        levelData.GroundPosition = default;
        levelData.GroundRotation = default;
        levelData.GroundScale = default;
        levelData.GroundPrefab = default;
    }

    private static void FillByGroundData(LevelStaticData levelData, GameObject groundObject)
    {
        levelData.GroundPosition = groundObject.transform.position;
        levelData.GroundRotation = groundObject.transform.rotation;
        levelData.GroundScale = groundObject.transform.localScale;
        levelData.GroundPrefab = PrefabUtility.GetCorrespondingObjectFromSource(groundObject);
    }

    private static void TryAddStartData(LevelStaticData levelData)
    {
        GameObject respawnPoint = GameObject.FindGameObjectWithTag(Tags.RESPAWN_POINT);
        if (respawnPoint != null)
            levelData.StartPosition = respawnPoint.transform.position;
        else
            Debug.LogWarning($"Can`t start position. Mark object by '{Tags.RESPAWN_POINT}' tag");
    }

    private static void TryAddFinishData(LevelStaticData levelData)
    {
        GameObject finishObject = GameObject.FindGameObjectWithTag(Tags.FINISH_POINT);
        if (finishObject != null)
            levelData.FinishPosition = finishObject.transform.position;
        else
            Debug.LogWarning($"Can`t finish position. Mark object by '{Tags.FINISH_POINT}' tag");
    }
}