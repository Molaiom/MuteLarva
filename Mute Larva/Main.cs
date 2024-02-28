using BepInEx;
using R2API;
using R2API.Utils;
using RoR2;
using UnityEngine;
using System.Security.Permissions;
using System;


[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace Mute_Larva
{
    [NetworkCompatibility(CompatibilityLevel.NoNeedForSync, VersionStrictness.DifferentModVersionsAreOk)]
    [BepInDependency(SoundAPI.PluginGUID)]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "Molaiom";
        public const string PluginName = "Mute_Larva";
        public const string PluginVersion = "1.0.0";

        public void Awake()
        {
            Log.Init(Logger);
            On.RoR2.Util.PlaySound_string_GameObject += OnSoundPlayed;
        }

        private uint OnSoundPlayed(On.RoR2.Util.orig_PlaySound_string_GameObject orig, string soundString, GameObject gameObject)
        {
            try
            {
                if (!soundString.Contains("acid_larva"))
                {
                    orig(soundString, gameObject);
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            return 0;
        }

        void OnDestroy()
        {
            On.RoR2.Util.PlaySound_string_GameObject -= OnSoundPlayed;
        }
    }
}
