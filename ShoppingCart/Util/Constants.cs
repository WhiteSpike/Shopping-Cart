using CustomItemBehaviourLibrary.AbstractItems;
using ShoppingCart.Behaviour;
namespace ShoppingCart.Util
{
    internal static class Constants
    {
        internal const string ITEM_SCAN_NODE_KEY_FORMAT = "Enable scan node of {0}";
        internal const bool ITEM_SCAN_NODE_DEFAULT = true;
        internal const string ITEM_SCAN_NODE_DESCRIPTION = "Shows a scan node on the item when scanning";

        internal const string SHOPPING_CART_RARITY_KEY = $"Spawn Chance of the {ShoppingCartBehaviour.ITEM_NAME} Item";
        internal const float SHOPPING_CART_RARITY_DEFAULT = 0.1f;
        internal const string SHOPPING_CART_RARITY_DESCRIPTION = $"How likely it is for a {ShoppingCartBehaviour.ITEM_NAME} item to spawn when landing on a moon. (0.1 = 10%)";

        internal const string SHOPPING_CART_WEIGHT_KEY = $"Weight of the {ShoppingCartBehaviour.ITEM_NAME} Item";
        internal const int SHOPPING_CART_WEIGHT_DEFAULT = 25;
        internal const string SHOPPING_CART_WEIGHT_DESCRIPTION = $"Weight of the {ShoppingCartBehaviour.ITEM_NAME} without any items in lbs";

        internal const string SHOPPING_CART_CONDUCTIVE_KEY = "Conductive";
        internal const bool SHOPPING_CART_CONDUCTIVE_DEFAULT = true;
        internal const string SHOPPING_CART_CONDUCTIVE_DESCRIPTION = "Wether it attracts lightning to the item or not. (Or other mechanics that rely on item being conductive)";

        internal const string SHOPPING_CART_DROP_AHEAD_PLAYER_KEY = "Drop ahead of player when dropping";
        internal const bool SHOPPING_CART_DROP_AHEAD_PLAYER_DEFAULT = true;
        internal const string SHOPPING_CART_DROP_AHEAD_PLAYER_DESCRIPTION = "If on, the item will drop infront of the player. Otherwise, drops underneath them and slightly infront.";

        internal const string SHOPPING_CART_GRABBED_BEFORE_START_KEY = "Grabbable before game start";
        internal const bool SHOPPING_CART_GRABBED_BEFORE_START_DEFAULT = true;
        internal const string SHOPPING_CART_GRABBED_BEFORE_START_DESCRIPTION = "Allows wether the item can be grabbed before hand or not";

        internal const string SHOPPING_CART_HIGHEST_SALE_PERCENTAGE_KEY = "Highest Sale Percentage";
        internal const int SHOPPING_CART_HIGHEST_SALE_PERCENTAGE_DEFAULT = 50;
        internal const string SHOPPING_CART_HIGHEST_SALE_PERCENTAGE_DESCRIPTION = "Maximum percentage of sale allowed when this item is selected for a sale.";

        internal const string SHOPPING_CART_RESTRICTION_MODE_KEY = $"Restrictions on the {ShoppingCartBehaviour.ITEM_NAME} Item";
        internal const ContainerBehaviour.Restrictions SHOPPING_CART_RESTRICTION_MODE_DEFAULT = ContainerBehaviour.Restrictions.ItemCount;
        internal const string SHOPPING_CART_RESTRICTION_MODE_DESCRIPTION = $"Restriction applied when trying to insert an item on the {ShoppingCartBehaviour.ITEM_NAME}.\n" +
                                                                        "Supported values: None, ItemCount, TotalWeight, All";

        internal const string SHOPPING_CART_MINIMUM_VALUE_KEY = $"Minimum scrap value of {ShoppingCartBehaviour.ITEM_NAME}";
        internal const int SHOPPING_CART_MINIMUM_VALUE_DEFAULT = 50;
        internal const string SHOPPING_CART_MINIMUM_VALUE_DESCRIPTION = "Lower boundary of the scrap's possible value";

        internal const string SHOPPING_CART_MAXIMUM_VALUE_KEY = $"Maximum scrap value of {ShoppingCartBehaviour.ITEM_NAME}";
        internal const int SHOPPING_CART_MAXIMUM_VALUE_DEFAULT = 100;
        internal const string SHOPPING_CART_MAXIMUM_VALUE_DESCRIPTION = "Higher boundary of the scrap's possible value";

        internal const string SHOPPING_CART_MAXIMUM_WEIGHT_ALLOWED_KEY = $"Maximum amount of weight for {ShoppingCartBehaviour.ITEM_NAME}";
        internal const float SHOPPING_CART_MAXIMUM_WEIGHT_ALLOWED_DEFAULT = 100f;
        internal const string SHOPPING_CART_MAXIMUM_WEIGHT_ALLOWED_DESCRIPTION = $"How much weight (in lbs and after weight reduction multiplier is applied on the stored items) a {ShoppingCartBehaviour.ITEM_NAME} can carry in items before it is considered full.";

        internal const string SHOPPING_CART_MAXIMUM_AMOUNT_ITEMS_KEY = $"Maximum amount of items for {ShoppingCartBehaviour.ITEM_NAME}";
        internal const int SHOPPING_CART_MAXIMUM_AMOUNT_ITEMS_DEFAULT = 6;
        internal const string SHOPPING_CART_MAXIMUM_AMOUNT_ITEMS_DESCRIPTION = $"Amount of items allowed before the {ShoppingCartBehaviour.ITEM_NAME} is considered full";

        internal const string SHOPPING_CART_WEIGHT_REDUCTION_MULTIPLIER_KEY = $"Weight reduction multiplier for {ShoppingCartBehaviour.ITEM_NAME}";
        internal const float SHOPPING_CART_WEIGHT_REDUCTION_MULTIPLIER_DEFAULT = 0.5f;
        internal const string SHOPPING_CART_WEIGHT_REDUCTION_MUTLIPLIER_DESCRIPTION = $"How much an item's weight will be ignored to the {ShoppingCartBehaviour.ITEM_NAME}'s total weight";

        internal const string SHOPPING_CART_NOISE_RANGE_KEY = $"Noise range of the {ShoppingCartBehaviour.ITEM_NAME} Item";
        internal const float SHOPPING_CART_NOISE_RANGE_DEFAULT = 14f;
        internal const string SHOPPING_CART_NOISE_RANGE_DESCRIPTION = $"How far the {ShoppingCartBehaviour.ITEM_NAME} sound propagates to nearby enemies when in movement";

        internal const string SHOPPING_CART_LOOK_SENSITIVITY_DRAWBACK_KEY = $"Look sensitivity drawback of the {ShoppingCartBehaviour.ITEM_NAME} Item";
        internal const float SHOPPING_CART_LOOK_SENSITIVITY_DRAWBACK_DEFAULT = 0.4f;
        internal const string SHOPPING_CART_LOOK_SENSITIVITY_DRAWBACK_DESCRIPTION = $"Value multiplied on the player's look sensitivity when moving with the {ShoppingCartBehaviour.ITEM_NAME} Item";

        internal const string SHOPPING_CART_MOVEMENT_SLOPPY_KEY = $"Sloppiness of the {ShoppingCartBehaviour.ITEM_NAME} Item";
        internal const float SHOPPING_CART_MOVEMENT_SLOPPY_DEFAULT = 5f;
        internal const string SHOPPING_CART_MOVEMENT_SLOPPY_DESCRIPTION = $"Value multiplied on the player's movement to give the feeling of drifting while carrying the {ShoppingCartBehaviour.ITEM_NAME} Item";

        internal const string SHOPPING_CART_PLAY_NOISE_KEY = $"Plays noises for players with {ShoppingCartBehaviour.ITEM_NAME} Item";
        internal const bool SHOPPING_CART_PLAY_NOISE_DEFAULT = true;
        internal const string SHOPPING_CART_PLAY_NOISE_DESCRIPTION = "If false, it will just not play the sounds, it will still attract monsters to noise";

        internal const string DROP_ALL_ITEMS_SHOPPING_CART_KEYBIND_NAME = "Drop all items from wheelbarrow";
        internal const string DROP_ALL_ITEMS_SHOPPING_CART_DEFAULT_KEYBIND = "<Mouse>/middleButton";

        internal static readonly string SHOPPING_CART_SCAN_NODE_KEY = string.Format(ITEM_SCAN_NODE_KEY_FORMAT, ShoppingCartBehaviour.ITEM_NAME);
    }
}
