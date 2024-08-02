using BepInEx;
using BepInEx.Logging;
using ShoppingCart.Behaviour;
using ShoppingCart.Misc;
using HarmonyLib;
using LethalLib.Modules;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using CustomItemBehaviourLibrary.Misc;
using ShoppingCart.Input;
using ShoppingCart.Compat;
using LethalLib.Extras;
using static BepInEx.BepInDependency;
namespace ShoppingCart
{
    [BepInPlugin(Metadata.GUID,Metadata.NAME,Metadata.VERSION)]
    [BepInDependency("com.sigurd.csync")]
    [BepInDependency("evaisa.lethallib")]
    [BepInDependency("com.rune580.LethalCompanyInputUtils")]
    [BepInDependency("com.github.WhiteSpike.CustomItemBehaviourLibrary")]
    public class Plugin : BaseUnityPlugin
    {
        internal static readonly Harmony harmony = new(Metadata.GUID);
        internal static readonly ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(Metadata.NAME);
        internal static readonly List<AudioClip> wheelsNoise = [];

        public new static PluginConfig Config;

        void Awake()
        {
            Config = new PluginConfig(base.Config);

            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "shoppingcart");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);
            string root = "Assets/Shopping Cart/";

            Item shoppingCartItem = ScriptableObject.CreateInstance<Item>();
            shoppingCartItem.name = "ShoppingCartItemProperties";
            shoppingCartItem.allowDroppingAheadOfPlayer = Config.DROP_AHEAD_PLAYER;
            shoppingCartItem.canBeGrabbedBeforeGameStart = Config.GRABBED_BEFORE_START;
            shoppingCartItem.canBeInspected = false;
            shoppingCartItem.isScrap = true;
            shoppingCartItem.minValue = Config.MINIMUM_VALUE;
            shoppingCartItem.maxValue = Config.MAXIMUM_VALUE;
            shoppingCartItem.floorYOffset = -90;
            shoppingCartItem.restingRotation = new Vector3(0f, 0f, 0f);
            shoppingCartItem.rotationOffset = new Vector3(0f, 0f, 0f);
            shoppingCartItem.positionOffset = new Vector3(0f, -1.7f, 0.35f);
            shoppingCartItem.weight = 0.99f + (Config.WEIGHT / 100f);
            shoppingCartItem.twoHanded = true;
            shoppingCartItem.itemIcon = bundle.LoadAsset<Sprite>(root + "Icon.png");
            shoppingCartItem.spawnPrefab = bundle.LoadAsset<GameObject>(root + "ShoppingCart.prefab");
            shoppingCartItem.dropSFX = bundle.LoadAsset<AudioClip>(root + "Drop.ogg");
            shoppingCartItem.grabSFX = bundle.LoadAsset<AudioClip>(root + "Grab.ogg");
            shoppingCartItem.pocketSFX = bundle.LoadAsset<AudioClip>(root + "Pocket.ogg");
            shoppingCartItem.throwSFX = bundle.LoadAsset<AudioClip>(root + "Throw.ogg");
            wheelsNoise.Add(bundle.TryLoadAudioClipAsset(root + "Shopping_Cart_Move_1.ogg"));
            wheelsNoise.Add(bundle.TryLoadAudioClipAsset(root + "Shopping_Cart_Move_2.ogg"));
            wheelsNoise.Add(bundle.TryLoadAudioClipAsset(root + "Shopping_Cart_Move_3.ogg"));
            wheelsNoise.Add(bundle.TryLoadAudioClipAsset(root + "Shopping_Cart_Move_4.ogg"));
            shoppingCartItem.highestSalePercentage = Config.HIGHEST_SALE_PERCENTAGE;
            shoppingCartItem.itemName = ShoppingCartBehaviour.ITEM_NAME;
            shoppingCartItem.itemSpawnsOnGround = true;
            shoppingCartItem.isConductiveMetal = Config.CONDUCTIVE;
            shoppingCartItem.requiresBattery = false;
            shoppingCartItem.batteryUsage = 0f;
            shoppingCartItem.twoHandedAnimation = true;
            shoppingCartItem.grabAnim = "HoldJetpack";

            ShoppingCartBehaviour grabbableObject = shoppingCartItem.spawnPrefab.AddComponent<ShoppingCartBehaviour>();
            grabbableObject.itemProperties = shoppingCartItem;
            grabbableObject.grabbable = true;
            grabbableObject.grabbableToEnemies = true;
            Utilities.FixMixerGroups(shoppingCartItem.spawnPrefab);
            NetworkPrefabs.RegisterNetworkPrefab(shoppingCartItem.spawnPrefab);
            Items.RegisterItem(shoppingCartItem);

            AnimationCurve curve = new(new Keyframe(0, 0), new Keyframe(1f - Config.RARITY.Value, 1), new Keyframe(1, 1));
            SpawnableMapObjectDef mapObjDef = ScriptableObject.CreateInstance<SpawnableMapObjectDef>();
            mapObjDef.spawnableMapObject = new SpawnableMapObject
            {
                prefabToSpawn = shoppingCartItem.spawnPrefab
            };
            MapObjects.RegisterMapObject(mapObjDef, Levels.LevelTypes.All, (_) => curve);
            InputUtilsCompat.Init();
            harmony.PatchAll(typeof(Keybinds));

            mls.LogInfo($"{Metadata.NAME} {Metadata.VERSION} has been loaded successfully.");
        }
    }   
}
