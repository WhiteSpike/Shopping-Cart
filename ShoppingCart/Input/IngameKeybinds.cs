using LethalCompanyInputUtils.Api;
using UnityEngine.InputSystem;
using ShoppingCart.Util;

namespace ShoppingCart.Input
{
    /// <summary>
    /// Class which stores the used key binds in the mod
    /// </summary>
    internal class IngameKeybinds : LcInputActions
    {
        public static IngameKeybinds Instance;
        /// <summary>
        /// Asset used to store all the input bindings defined for our controls
        /// </summary>
        internal static InputActionAsset GetAsset()
        {
            return Instance.Asset;
        }

        /// <summary>
        /// Input binding used to trigger the drop all items in the wheelbarrow action
        /// </summary>
        [InputAction(Constants.DROP_ALL_ITEMS_SHOPPING_CART_DEFAULT_KEYBIND, Name = Constants.DROP_ALL_ITEMS_SHOPPING_CART_KEYBIND_NAME)]
        public InputAction ShoppingCartKey { get; set; }

    }
}
