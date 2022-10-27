using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuickReplace : EditorWindow {

    [SerializeField] private GameObject prefab;
    [SerializeField] private Material material;
    private bool showPrefab = true;
    private bool showMaterial = false;
    private bool showTransform = false;
    private bool copyPosition = true;
    private bool copyRotation = true;
    private bool copyScale = true;

    [MenuItem("Tools/QuickReplace #R")]
    private static void ShowWindow() {
        EditorWindow.GetWindow<QuickReplace>();
    }

    private void OnGUI() {
        showPrefab = EditorGUILayout.Foldout(showPrefab, "Prefab");
        if(showPrefab) prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), false);
        
        showMaterial = EditorGUILayout.Foldout(showMaterial, "Material");
        if(showMaterial) material = (Material)EditorGUILayout.ObjectField("Material", material, typeof(Material), false);

        showTransform = EditorGUILayout.Foldout(showTransform, "Transform");
        if(showTransform){
            copyPosition = EditorGUILayout.Toggle("Copy position", copyPosition);
            copyRotation = EditorGUILayout.Toggle("Copy rotation", copyRotation);
            copyScale = EditorGUILayout.Toggle("Copy scale", copyScale);
        }

        if(GUILayout.Button("Replace")){
            GameObject[] selections = Selection.gameObjects;

            for (var i = 0; i < selections.Length; i++)
            {
                GameObject selected = selections[i];
                if(prefab != null){
                    PrefabAssetType prefabType = PrefabUtility.GetPrefabAssetType(prefab);
                    GameObject newObject;

                    Debug.Log("PrefabType: " + prefabType);

                    if(prefabType == PrefabAssetType.Regular){
                        newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                    }else{
                        newObject = Instantiate(prefab);
                        newObject.name = prefab.name;
                    }

                    if(newObject == null){
                        Debug.LogError("Error instantiating prefab");
                        break;
                    }

                    Undo.RegisterCreatedObjectUndo(newObject, "Replace with prefab");
                    newObject.transform.parent = selected.transform.parent;
                    if(copyPosition) newObject.transform.localPosition = selected.transform.localPosition;
                    if(copyRotation) newObject.transform.localRotation = selected.transform.localRotation;
                    if(copyScale) newObject.transform.localScale = selected.transform.localScale;
                    if(material != null) newObject.GetComponent<MeshRenderer>().material = material;
                    newObject.transform.SetSiblingIndex(selected.transform.GetSiblingIndex());
                    Undo.DestroyObjectImmediate(selected);
                }else{
                    selected.GetComponent<MeshRenderer>().material = material;
                }
                
            }
        }
        GUI.enabled = false;
        EditorGUILayout.LabelField("Selection count " + Selection.objects.Length);
    }
}