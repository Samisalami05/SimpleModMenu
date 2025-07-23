using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MelonLoader;
using UnityEngine;

namespace SimpleModMenu
{
    internal class SledParameters
    {
        private GameObject body;
        private GameObject sled;

        private MeshInterpretter meshInterpretter;

        public SledData sledData;

        public bool isInitialized = false;

        public IEnumerator Initialize()
        {
            while (body == null)
            {
                FindBody();
                yield return null;
            }

            FindSled();
            if (sled == null)
            {
                MelonLogger.Warning("Sled was not found after body initialized.");
            }

            MelonLogger.Msg("Body found!");
            isInitialized = true;
        }

        public void FindBody()
        {
            this.body = GameObject.Find("Snowmobile(Clone)/Body");
        }

        public void FindSled()
        {
            if (body == null) return;

            foreach (Transform parent in body.transform)
            {
                if (parent.Find("CharacterControlPoints"))
                {
                    Melon<Core>.Logger.Msg("Found parent object: " + parent.gameObject.name);
                    this.sled = parent.gameObject;
                }
            }
        }

        public void GetSledData()
        {
            if (meshInterpretter == null)
            {
                Melon<Core>.Logger.Error("MeshInterpretter component not found on sled.");
                return;
            }
            this.sledData = new SledData();
            SledData.CopyValues(meshInterpretter, sledData.originalValues);
            SledData.CopyValues(meshInterpretter, sledData.newValues);
        }

        public void Apply()
        {
            if (meshInterpretter == null)
            {
                Melon<Core>.Logger.Error("MeshInterpretter component not found on sled.");
                return;
            }
            SledData.CopyValues(sledData.newValues, meshInterpretter);
        }

        public void GetMeshInterpretter()
        {
            if (body == null)
            {
                Melon<Core>.Logger.Error("Body is null, cannot get MeshInterpretter.");
                return;
            }
            this.meshInterpretter = body.GetComponent<MeshInterpretter>();
            if (meshInterpretter == null)
            {
                Melon<Core>.Logger.Error("MeshInterpretter component not found on sled.");
            }
        }

        public void Reload()
        {
            FindBody();
            if (body == null) { Melon<Core>.Logger.Error("Body not found during reload"); }
            FindSled();
            if (sled == null) { Melon<Core>.Logger.Error("Sled not found during reload"); }
        }
         
        public void CheckIfSledChanged()
        {
            if (body == null || sled == null && isInitialized)
            {
                FindBody();
                FindSled();
                GetMeshInterpretter();
                GetSledData();
            }
        }
    }
}
