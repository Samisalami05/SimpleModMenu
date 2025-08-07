using SimpleModMenu.Tabs;   
using UnityEngine;

namespace SimpleModMenu
{
    internal class Ui
    {
        public bool menuOpen;
        public Color themeColor; // Todo: Add theme color functionality

        private static Vector2 menuSize = new Vector2(800, 600);
        private static Rect menuRect = new Rect(Screen.width / 2 - menuSize.x / 2, Screen.height / 2 - menuSize.y / 2, menuSize.x, menuSize.y);

        public Ui()
        {
            this.menuOpen = false;
            this.themeColor = new Vector4(1f, 0f, 0f, 1f); // Red
        }

        /// <summary>
        /// Draws the mod menu if it is open. Should be called in a MelonEvents.OnGUI event.
        /// </summary>
        public void DrawMenu()
        {
            if (!menuOpen) return;

            menuRect = GUI.Window(1, menuRect, DrawMenuWindow, "Simple Mod Menu");
        }

        private void DrawMenuWindow(int windowID)
        {
            GUIStyle centeredStyle = new GUIStyle(GUI.skin.label);
            centeredStyle.alignment = TextAnchor.MiddleCenter;

            DrawTabs();

            GUI.Label(new Rect(menuRect.width / 2 - 100, menuRect.height - 40, 200, 20), "Made by Samisalami", centeredStyle);

            // Make the window draggable
            GUI.DragWindow(new Rect(0, 0, menuRect.width, 20));
        }

        private void DrawTabs()
        {
            GUILayoutOption gUILayoutOption = GUILayout.MinHeight(40);

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 20;


            GUILayout.BeginHorizontal();
            int i = 0;
            foreach (Tab tab in API.GetTabs()) {
                if (GUILayout.Button(tab.title, buttonStyle, gUILayoutOption))
                {
                    Core.selectedTab = i;
                }
                i++;
            }
            GUILayout.EndHorizontal();

            DrawTabContent();
        }

        private void DrawTabContent()
        {
            Rect tabContentRect = new Rect(0, 40, menuRect.width, menuRect.height - 40);
            GUI.BeginGroup(tabContentRect);
            
            // Draw the content of the selected tab
            if (Core.selectedTab >= 0 && Core.selectedTab < API.GetTabCount())
            {
                API.GetTab(Core.selectedTab).DrawTab();
            }
            GUI.EndGroup();
        }

        /// <summary>
        /// Returns the rectangle for the menu window.
        /// </summary>
        /// <returns>The rectangle</returns>
        public static Rect GetMenuRect()
        {
            return menuRect;
        }
    }
}
