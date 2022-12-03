using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof (TerrainGenerate))]
public class CubeGeneratorEditor : Editor
{
    public override void OnInspectorGUI() {
        TerrainGenerate terrainGen = (TerrainGenerate)target;
        if (DrawDefaultInspector()) {
            if (terrainGen.autoUpdate) {
                terrainGen.ResetCube();
            }
        };

        if (GUILayout.Button("Generate")) {
            terrainGen.ResetCube();
        }
    }
}
