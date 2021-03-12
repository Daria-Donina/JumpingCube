//using UnityEngine;
//using UnityEditor;

//public class ExampleClass : MonoBehaviour
//{
//    public bool flag;
//    public int i = 1;
//}

//[CustomEditor(typeof(ExampleClass))]
//public class MyScriptEditor : Editor
//{
//    override public void OnInspectorGUI()
//    {
//        var myScript = target as ExampleClass;

//        myScript.flag = GUILayout.Toggle(myScript.flag, "Flag");

//        if (myScript.flag)
//            myScript.i = EditorGUILayout.IntSlider("I field:", myScript.i, 1, 100);

//    }
//}