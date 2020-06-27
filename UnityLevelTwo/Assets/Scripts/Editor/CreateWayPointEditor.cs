//#if UNITY_EDITOR
//using UnityEngine;
//using UnityEditor;
//using UnityEditor.SceneManagement;


//[CustomEditor(typeof(CreateWayPoint))]
//public sealed class CreateWayPointEditor : Editor
//{
//    #region Fields

//    private CreateWayPoint _testTarget;

//    #endregion


//    #region UnityMethods

//    private void OnEnable()
//    {
//        _testTarget = (CreateWayPoint)target;
//    }

//    //private void OnSceneGUI()
//    //{
//    //    //отлавливаем событие нажатия левой кнопки мыши
//    //    if (Event.current.button == 0 && Event.current.type == tEventType.MouseDown)
//    //    {
//    //        Ray ray = Camera.current.ScreenPointToRay(new Vector3(Event.current.mousePosition.x,
//    //            SceneView.currentDrawingSceneView.camera.pixelHeight - Event.current.mousePosition.y));

//    //        if (Physics.Raycast(ray, out var hit))
//    //        {
//    //            _testTarget.InstantiateObj(hit.point);
//    //            SetObjectDirty(_testTarget.gameObject);
//    //        }
//    //    }
//    //    //выделяем объект, чтобы он не съезжал
//    //    Selection.activeGameObject = _testTarget.gameObject;
//    //}

//    #endregion


//    #region Methods

//    public void SetObjectDirty(GameObject obj)
//    {
//        if (!Application.isPlaying)
//        {
//            //помечаем объект, как грязный для того, тобы Unity понимало, что мы эти объекты создали
//            //в следствии чего, сцену дает пересохранить.
//            EditorUtility.SetDirty(obj);
//            EditorSceneManager.MarkSceneDirty(obj.scene);
//        }
//    }

//    #endregion
//}
//#endif