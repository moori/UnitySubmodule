using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;

namespace dMoori.Utils
{
    public static class MonoExtensions
    {
        public static void DelayedAction(this MonoBehaviour mb, float delay, System.Action onComplete)
        {
            mb.StartCoroutine(DelayedCoroutine(delay, onComplete));
        }
        public static IEnumerator DelayedCoroutine(float delay, System.Action onComplete)
        {
            yield return new WaitForSeconds(delay);
            onComplete();
        }
    }

    public static class CollectionExtensions
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = new System.Random().Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public static T GetRandom<T>(this List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static T GetRandom<T>(this IEnumerable<T> list)
        {
            return list.ToList().GetRandom();
        }

        public static T GetNext<T>(this List<T> list, T value)
        {
            var index = list.IndexOf(value);
            return (index + 1) >= list.Count ? list[0] : list[index + 1];
        }

        public static T GetPreview<T>(this List<T> list, T value)
        {
            var index = list.IndexOf(value);
            return (index - 1) < 0 ? list[list.Count - 1] : list[index - 1];
        }
    }

    public static class StringUtils
    {
        public static string RemoveDiacritics(this string text)
        {
            string formD = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char ch in formD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }

    public static class Vector2Extensions
    {
        public static Vector2 SetX(this Vector2 v, float value) { return new Vector2(value, v.y); }
        public static Vector2 SetY(this Vector2 v, float value) { return new Vector2(v.x, value); }
    }

    public static class Vector3Extensions
    {
        public static Vector3 SetX(this Vector3 v, float value) { return new Vector3(value, v.y, v.z); }
        public static Vector3 SetY(this Vector3 v, float value) { return new Vector3(v.x, value, v.z); }
        public static Vector3 SetZ(this Vector3 v, float value) { return new Vector3(v.x, v.y, value); }
        public static Vector3 SetXY(this Vector3 v, float x, float y) { return new Vector3(x, y, v.z); }
        public static Vector3 SetXZ(this Vector3 v, float x, float z) { return new Vector3(x, v.y, z); }
        public static Vector3 SetYZ(this Vector3 v, float y, float z) { return new Vector3(v.x, y, z); }
    }
}