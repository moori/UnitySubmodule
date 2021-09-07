using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dMoori
{
    public static class Proto
    {
        public static TextMesh DebugText(MonoBehaviour mb, string text, Vector3 position, Quaternion rotation, Color color, int size = 14, float duration = -1, Transform parent = null)
        {
            var textMesh = new GameObject("DebugText", typeof(TextMesh)).GetComponent<TextMesh>();
            textMesh.text = text;
            textMesh.fontSize = size * 100;
            textMesh.characterSize = 0.01f;
            textMesh.color = color;
            textMesh.transform.position = position;
            textMesh.transform.rotation = rotation;
            textMesh.transform.parent = parent;
            textMesh.anchor = TextAnchor.MiddleCenter;

            if (duration > 0)
            {
                GameObject.Destroy(textMesh.gameObject, duration);
            }

            return textMesh;
        }
    }
}
