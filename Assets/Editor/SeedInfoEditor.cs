using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(SeedInfo))]
public class SeedInfoEditor : Editor {

    SeedInfo seedInfo;

    private void OnEnable() {
        seedInfo = (SeedInfo)target;
    }

    public override void OnInspectorGUI() {
        //base.OnInspectorGUI();
        
        EditorGUILayout.BeginHorizontal();

        seedInfo.seedImage = (Sprite)EditorGUILayout.ObjectField(seedInfo.seedImage, typeof(Sprite), false, GUILayout.Width(100f), GUILayout.Height(100f));
        
        EditorGUILayout.BeginVertical();

        seedInfo.seedName = EditorGUILayout.TextField("Name", seedInfo.seedName);
        seedInfo.seedDescription = EditorGUILayout.TextField("Description", seedInfo.seedDescription);
        seedInfo.chanceToDropSeed = EditorGUILayout.Slider("Drop Seed Chance", seedInfo.chanceToDropSeed, 0, 1);
        seedInfo.allowRandomRotation = EditorGUILayout.Toggle("Allow Random Rotation", seedInfo.allowRandomRotation);
        seedInfo.needsHitbox = EditorGUILayout.Toggle("Needs Hitbox", seedInfo.needsHitbox);

        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("growSeasons"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("growStages"), true);
        
    }
}