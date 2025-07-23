using MelonLoader;
using Unity.VisualScripting;
using UnityEngine;

[assembly: MelonInfo(typeof(SimpleModMenu.Core), "SimpleModMenu", "2.0.0", "Samisalami", null)]
[assembly: MelonGame("Hanki Games", "Sledders")]

namespace SimpleModMenu
{
    public class Core : MelonMod
    {
        private SledParameters sledParams;
        private Ui ui;

        public override void OnApplicationStart()
        {
            ui = new Ui();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "TitleScreen" || sceneName == "Garage" || sceneName == "LoadingScene") return;

            sledParams = new SledParameters();
            MelonCoroutines.Start(sledParams.Initialize());
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                ui.menuOpen = !ui.menuOpen;
                Cursor.visible = ui.menuOpen;
                MelonLogger.Msg("Right Shift pressed, toggling menu: " + ui.menuOpen);
            }

            if (sledParams != null && sledParams.isInitialized && sledParams.sledData == null)
            {
                sledParams.GetSledData();

                if (sledParams.sledData != null) 
                    ui.setSledParams(sledParams);
            }
        }

        public override void OnInitializeMelon()
        {
            MelonEvents.OnGUI.Subscribe(ui.DrawMenu, 100);
        }
    }
}