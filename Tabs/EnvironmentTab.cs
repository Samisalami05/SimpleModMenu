using UnityEngine;

namespace SimpleModMenu.Tabs
{
    internal class EnvironmentTab : Tab
    {
        public EnvironmentTab(Vector2 size, Vector2 position) : base("Environment", size, position)
        {
            // Initialize any environment-specific data here
        }
        // Override the DrawTab method to implement the environment tab UI
        public override void DrawTab()
        {
            base.DrawTab();
            GUILayout.Label("Environment Tab");
            GUILayout.Label("This is where you can adjust environment settings.");
        }
    }
}
