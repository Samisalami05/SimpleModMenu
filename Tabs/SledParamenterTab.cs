using UnityEngine;

namespace SimpleModMenu.Tabs
{
    internal class SledParamenterTab : Tab
    {
        private SledParameters sledPararms;
        public SledParamenterTab(SledParameters sledParam) : base("SledParameters")
        {
            this.sledPararms = sledParam;
        }
        
        public override void DrawTab()
        {
            base.DrawTab();
            if (sledPararms == null)
            {
                GUILayout.Label("Sled Parameters not initialized.");
                return;
            }
            SledData sledData = sledPararms.sledData;
            if (sledData == null) return; // Return if no sled is found

            GUILayout.Label("Sled Parameter Tab");
            GUILayout.Label("This is where you can adjust sled parameters.");

            DrawSlider("Power", ref sledData.newValues.power, 0f, 300000f);
            DrawSlider("Lug Height", ref sledData.newValues.lugHeight, 0f, 3f);
            DrawSlider("Pitch Factor", ref sledData.newValues.pitchFactor, 0f, 10f);
            DrawSlider("Friction", ref sledData.newValues.coefficientOfFriction, 0f, 5f);
            DrawSlider("Snow Push Force", ref sledData.newValues.snowPushForceFactor, 0f, 100f);

            DrawButton("Apply Changes", () =>
            {
                sledPararms.Apply();
            });
        }
    }
}
