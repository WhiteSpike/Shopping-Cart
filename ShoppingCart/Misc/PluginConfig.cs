using BepInEx.Configuration;
using CSync.Extensions;
using CSync.Lib;
using ShoppingCart.Behaviour;
using ShoppingCart.Util;
using System.Runtime.Serialization;
using CustomItemBehaviourLibrary.AbstractItems;

namespace ShoppingCart.Misc
{
    [DataContract]
    public class PluginConfig : SyncedConfig2<PluginConfig>
    {
        [field: SyncedEntryField] public SyncedEntry<float> RARITY { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> SCAN_NODE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> MINIMUM_VALUE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> MAXIMUM_VALUE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> WEIGHT { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> DROP_AHEAD_PLAYER { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> GRABBED_BEFORE_START { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> CONDUCTIVE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<ContainerBehaviour.Restrictions> RESTRICTION_MODE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<int> MAXIMUM_AMOUNT_ITEMS { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> MAXIMUM_WEIGHT_ALLOWED { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> WEIGHT_REDUCTION_MULTIPLIER { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> LOOK_SENSITIVITY_DRAWBACK { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> MOVEMENT_SLOPPY { get; set; }
        [field: SyncedEntryField] public SyncedEntry<float> NOISE_RANGE { get; set; }
        [field: SyncedEntryField] public SyncedEntry<bool> PLAY_NOISE { get; set; }
        public PluginConfig(ConfigFile cfg) : base(Metadata.GUID)
        {
            string topSection = ShoppingCartBehaviour.ITEM_NAME;

            MINIMUM_VALUE = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_MINIMUM_VALUE_KEY, Constants.SHOPPING_CART_MINIMUM_VALUE_DEFAULT, Constants.SHOPPING_CART_MINIMUM_VALUE_DESCRIPTION);
            MAXIMUM_VALUE = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_MAXIMUM_VALUE_KEY, Constants.SHOPPING_CART_MAXIMUM_VALUE_DEFAULT, Constants.SHOPPING_CART_MAXIMUM_VALUE_DESCRIPTION);
            RARITY = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_RARITY_KEY, Constants.SHOPPING_CART_RARITY_DEFAULT, Constants.SHOPPING_CART_RARITY_DESCRIPTION);
            WEIGHT = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_WEIGHT_KEY, Constants.SHOPPING_CART_WEIGHT_DEFAULT, Constants.SHOPPING_CART_WEIGHT_DESCRIPTION);
            SCAN_NODE = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_SCAN_NODE_KEY, Constants.ITEM_SCAN_NODE_DEFAULT, Constants.ITEM_SCAN_NODE_DESCRIPTION);
            DROP_AHEAD_PLAYER = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_DROP_AHEAD_PLAYER_KEY, Constants.SHOPPING_CART_DROP_AHEAD_PLAYER_DEFAULT, Constants.SHOPPING_CART_DROP_AHEAD_PLAYER_DESCRIPTION);
            CONDUCTIVE = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_CONDUCTIVE_KEY, Constants.SHOPPING_CART_CONDUCTIVE_DEFAULT, Constants.SHOPPING_CART_CONDUCTIVE_DESCRIPTION);
            GRABBED_BEFORE_START = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_GRABBED_BEFORE_START_KEY, Constants.SHOPPING_CART_GRABBED_BEFORE_START_DEFAULT, Constants.SHOPPING_CART_GRABBED_BEFORE_START_DESCRIPTION);
            RESTRICTION_MODE = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_RESTRICTION_MODE_KEY, Constants.SHOPPING_CART_RESTRICTION_MODE_DEFAULT, Constants.SHOPPING_CART_RESTRICTION_MODE_DESCRIPTION);
            MAXIMUM_WEIGHT_ALLOWED = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_MAXIMUM_WEIGHT_ALLOWED_KEY, Constants.SHOPPING_CART_MAXIMUM_WEIGHT_ALLOWED_DEFAULT, Constants.SHOPPING_CART_MAXIMUM_WEIGHT_ALLOWED_DESCRIPTION);
            MAXIMUM_AMOUNT_ITEMS = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_MAXIMUM_AMOUNT_ITEMS_KEY, Constants.SHOPPING_CART_MAXIMUM_AMOUNT_ITEMS_DEFAULT, Constants.SHOPPING_CART_MAXIMUM_AMOUNT_ITEMS_DESCRIPTION);
            WEIGHT_REDUCTION_MULTIPLIER = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_WEIGHT_REDUCTION_MULTIPLIER_KEY, Constants.SHOPPING_CART_WEIGHT_REDUCTION_MULTIPLIER_DEFAULT, Constants.SHOPPING_CART_WEIGHT_REDUCTION_MUTLIPLIER_DESCRIPTION);
            NOISE_RANGE = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_NOISE_RANGE_KEY, Constants.SHOPPING_CART_NOISE_RANGE_DEFAULT, Constants.SHOPPING_CART_NOISE_RANGE_DESCRIPTION);
            LOOK_SENSITIVITY_DRAWBACK = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_LOOK_SENSITIVITY_DRAWBACK_KEY, Constants.SHOPPING_CART_LOOK_SENSITIVITY_DRAWBACK_DEFAULT, Constants.SHOPPING_CART_LOOK_SENSITIVITY_DRAWBACK_DESCRIPTION);
            MOVEMENT_SLOPPY = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_MOVEMENT_SLOPPY_KEY, Constants.SHOPPING_CART_MOVEMENT_SLOPPY_DEFAULT, Constants.SHOPPING_CART_MOVEMENT_SLOPPY_DESCRIPTION);
            PLAY_NOISE = cfg.BindSyncedEntry(topSection, Constants.SHOPPING_CART_PLAY_NOISE_KEY, Constants.SHOPPING_CART_PLAY_NOISE_DEFAULT, Constants.SHOPPING_CART_PLAY_NOISE_DESCRIPTION);

            ConfigManager.Register(this);
        }
    }
}
