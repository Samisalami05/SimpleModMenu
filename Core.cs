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

        private string sceneName = "";

        public override void OnApplicationStart()
        {
            ui = new Ui();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            this.sceneName = sceneName;
            if (sceneName == "TitleScreen" || sceneName == "Garage" || sceneName == "LoadingScene") return;

            sledParams = new SledParameters();
            MelonCoroutines.Start(sledParams.Initialize());
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                ui.menuOpen = !ui.menuOpen;
                if (sceneName != "TitleScreen" || sceneName != "Garage" || sceneName != "LoadingScene")
                {
                    Cursor.visible = ui.menuOpen;
                }
            }
            
            if (sceneName == "TitleScreen" || sceneName == "Garage" || sceneName == "LoadingScene") return;

            if (sledParams != null && sledParams.sledData != null)
            {
                sledParams.CheckIfSledChanged();
            }

            if (sledParams != null && sledParams.isInitialized && sledParams.sledData == null)
            {
                MelonLogger.Msg("Sled Parameters initialized, fetching sled data...");
                sledParams.GetMeshInterpretter();
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