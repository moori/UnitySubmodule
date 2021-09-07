using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace dMoori.EditorUtils
{
    public class EditorUtils
    {
        [MenuItem("Tools/Erase PlayerPrefs")]
        public static void ErasePlayerPrefs()
        {
            if (EditorUtility.DisplayDialog("Erase PlayerPrefs", "Are you sure you want to delete all PlayerPrefs?", "Delete", "Cancel"))
            {
                PlayerPrefs.DeleteAll();
            }
        }

    }
}
