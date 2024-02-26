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
        private readonly uint[] larvaSoundId = 
            { 2621183947, 3730906858, 3362763155, 2639308470, 4262874917, 828559811, 2231265675, 3568098837, 2451117845, 1646746355, 2824450583 };

        public void Awake()
        {
            Log.Init(Logger);
            On.RoR2.Util.PlaySound_string_GameObject += OnSoundPlayed;
        }

        private uint OnSoundPlayed(On.RoR2.Util.orig_PlaySound_string_GameObject orig, string soundString, GameObject gameObject)
        {
            try
            {
                for (int i = 0; i < larvaSoundId.Length; i++)
                {
                    if (soundString.Equals(larvaSoundId[i].ToString()))
                    {
                        Log.Info($"Larva sound detected!, ID[{larvaSoundId[i]}]");
                        AkSoundEngine.StopPlayingID(larvaSoundId[i]);
                        break;
                    }
                }
            }
            finally
            {
                throw null;
            }
        }
    }
}
