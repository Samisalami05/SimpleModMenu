using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

namespace SimpleModMenu
{
    internal class Tab
    {
        public string title;
        public Vector2 size;
        public Vector2 position;
        
        public Tab(string title, Vector2 size, Vector2 position)
        {
            this.title = title;
            this.size = size;
            this.position = position;
        }

        public virtual void DrawTab()
        {
            
        }

        public void DrawSlider(string label, ref float value, float min, float max)
        {
            GUILayout.Label(label);
            value = GUILayout.HorizontalSlider(value, min, max);
            GUILayout.Label(value.ToString("F2"));
        }
    }
}
