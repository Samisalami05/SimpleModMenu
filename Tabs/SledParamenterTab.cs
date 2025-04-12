using TestMod;
using UnityEngine;

namespace SimpleModMenu.Tabs
{
    internal class SledParamenterTab : Tab
    {
        private SledData sledData;
        public SledParamenterTab(string title, Vector2 size, Vector2 position, SledData sledData) : base(title, size, position)
        {
            this.sledData = sledData;
        }
        // Override the DrawTab method to implement the sled parameter tab UI
        public override void DrawTab()
        {
            // Draw the sled parameter tab UI here
            // You can use GUILayout and other Unity UI elements to create the sled parameter interface
            GUILayout.Label("Sled Parameter Tab");
            GUILayout.Label("This is where you can adjust sled parameters.");
            DrawSlider(title, ref sledData.originalValues.power, 0f, 100f);
        }
    }
}
