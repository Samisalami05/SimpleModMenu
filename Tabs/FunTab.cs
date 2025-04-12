using UnityEngine;

namespace SimpleModMenu.Tabs
{
    internal class FunTab : Tab
    {
        public FunTab(string title, Vector2 size, Vector2 position) : base(title, size, position)
        {
            // Initialize any fun-specific data here
        }
        // Override the DrawTab method to implement the fun tab UI
        public override void DrawTab()
        {
            // Draw the fun tab UI here
            // You can use GUILayout and other Unity UI elements to create the fun interface
            GUILayout.Label("Fun Tab");
            GUILayout.Label("This is where you can add fun features.");
        }
    }
}
