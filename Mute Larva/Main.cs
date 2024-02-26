using BepInEx;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Security.Permissions;
using System.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace Mute_Larva
{
    [BepInDependency(SoundAPI.PluginGUID)]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "Molaiom";
        public const string PluginName = "Mute_Larva";
        public const string PluginVersion = "0.1";

        public void Awake()
        {
            Log.Init(Logger);

            On.EntityStates.AcidLarva.SpawnState.ctor += (orig, self) =>
            {
                Log.Info($"Larva spawned at {self.transform.position}, destroying it!");
                orig(self);
                self.gameObject.SetActive(false);
            };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                Transform transform = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;

                Log.Info($"Player pressed F2. Player is at {transform.position}");
            }
        }
    }
}
