using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StartSceneInPlayMode: EditorWindow
{
    string m_ScenePath = "Assets/Scenes/preloader.unity";

    private void OnEnable() {
        SetPlayModeStartScene( m_ScenePath );
    }

    void OnGUI() {
        // Use the Object Picker to select the start SceneAsset
        EditorSceneManager.playModeStartScene =
            (SceneAsset) EditorGUILayout.ObjectField( new GUIContent( "Start Scene" ), EditorSceneManager.playModeStartScene, typeof( SceneAsset ), false );

        // Or set the start Scene from code
        if( GUILayout.Button( "Set start scene: " + m_ScenePath ) )
        {
            SetPlayModeStartScene( m_ScenePath );
        }
    }

    void SetPlayModeStartScene( string scenePath ) {
        SceneAsset myWantedStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>( scenePath );
        if( myWantedStartScene != null )
            EditorSceneManager.playModeStartScene = myWantedStartScene;
        else
            Debug.Log( "Could not find scene " + scenePath );
    }

    [MenuItem( "Extra/Setup start scene in Play Mode" )]
    static void Open() {
        GetWindow<StartSceneInPlayMode>();
    }
}