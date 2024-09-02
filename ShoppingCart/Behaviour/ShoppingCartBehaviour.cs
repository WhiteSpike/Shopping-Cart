using CustomItemBehaviourLibrary.AbstractItems;
using UnityEngine;
using UnityEngine.InputSystem;
using ShoppingCart.Input;
using ShoppingCart.Misc;

namespace ShoppingCart.Behaviour
{
    internal class ShoppingCartBehaviour : ContainerBehaviour
    {
        internal const string ITEM_NAME = "Shopping Cart";
        protected bool KeepScanNode
        {
            get
            {
                return Plugin.Config.SCAN_NODE;
            }
        }

        public override void Start()
        {
            base.Start();
            PluginConfig config = Plugin.Config;
            maximumAmountItems = config.MAXIMUM_AMOUNT_ITEMS.Value;
            weightReduceMultiplier = config.WEIGHT_REDUCTION_MULTIPLIER.Value;
            restriction = config.RESTRICTION_MODE;
            maximumWeightAllowed = config.MAXIMUM_WEIGHT_ALLOWED.Value;
            noiseRange = config.NOISE_RANGE.Value;
            sloppiness = config.MOVEMENT_SLOPPY.Value;
            lookSensitivityDrawback = config.LOOK_SENSITIVITY_DRAWBACK.Value;
            playSounds = config.PLAY_NOISE.Value;
            wheelsClip = Plugin.wheelsNoise.ToArray();
            if (scrapValue <= 0)
            {
                System.Random random = new System.Random(StartOfRound.Instance.randomMapSeed + 45);
                SetScrapValue(random.Next(config.MINIMUM_VALUE.Value, config.MAXIMUM_VALUE.Value));
            }
            if (!KeepScanNode) Destroy(gameObject.GetComponentInChildren<ScanNodeProperties>());
        }

        protected override void SetupScanNodeProperties()
        {
            ScanNodeProperties scanNodeProperties = GetComponentInChildren<ScanNodeProperties>();
            if (scanNodeProperties != null) Tools.ChangeScanNode(ref scanNodeProperties, (Tools.NodeType)scanNodeProperties.nodeType, header: ITEM_NAME);
            else Tools.AddScrapScanNode(objectToAddScanNode: gameObject, header: ITEM_NAME);
        }

        protected override string[] SetupContainerTooltips()
        {
            string controlBind = IngameKeybinds.Instance.ShoppingCartKey.GetBindingDisplayString();
            return [$"Drop all items: [{controlBind}]"];
        }
    }
}
