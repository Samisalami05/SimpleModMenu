using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

namespace SimpleModMenu
{
    internal abstract class Tab
    {
        public string title;
        public Vector2 size;
        public Vector2 position;

        private GUIStyle _centeredLabel;

        public Tab(string title)
        {
            this.title = title;
            this.size = Ui.GetMenuRect().size;
            this.position = new Vector2(0, 0);
        }

        public virtual void DrawTab()
        {
            InitCenteredLabel();
        }

        private void InitCenteredLabel()
        {
            if (_centeredLabel == null)
            {
                _centeredLabel = new GUIStyle(GUI.skin.label);
                _centeredLabel.alignment = TextAnchor.MiddleCenter;
            }
        }

        public void DrawSlider(string label, ref float value, float min, float max)
        {
            // Draw label
            GUILayout.BeginHorizontal();
            GUILayout.Space(20);
            GUILayout.Label(label);
            GUILayout.EndHorizontal();

            // Draw slider
            GUILayout.BeginHorizontal();
            GUILayout.Space(20);
            value = GUILayout.HorizontalSlider(value, min, max, GUILayout.ExpandWidth(true));
            GUILayout.Label(value.ToString("F2"), _centeredLabel, GUILayout.Width(100));
            GUILayout.EndHorizontal();
        }

        public void DrawToggle(string label, ref bool value)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(label);
            value = GUILayout.Toggle(value, "");
            GUILayout.EndHorizontal();
        }

        public void DrawButton(string label, Action action)
        {
            if (GUILayout.Button(label))
            {
                action?.Invoke();
            }
        }

        public void DrawButton(string label, float width, Action action)
        {
            float clampedWidth = Mathf.Clamp01(width); // Prevent values outside 0..1
            float pixelWidth = Ui.GetMenuRect().width * clampedWidth;

            GUILayout.BeginHorizontal();

            if (GUILayout.Button(label, GUILayout.Width(pixelWidth)))
            {
                action?.Invoke();
            }

            GUILayout.EndHorizontal();
        }
    }
}
