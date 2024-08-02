using UnityEngine.InputSystem;
using ShoppingCart.Input;

namespace ShoppingCart.Compat
{
    /// <summary>
    /// Class responsible for compatibility with LethalCompany_InputUtils mod
    /// </summary>
    public static class InputUtilsCompat
    {
        /// <summary>
        /// Asset used to store all the input bindings defined for our controls
        /// </summary>
        internal static InputActionAsset Asset => IngameKeybinds.GetAsset();
        /// <summary>
        /// Input binding used to trigger the drop all items in the shopping cart action
        /// </summary>
        public static InputAction ShoppingCartKey => IngameKeybinds.Instance.ShoppingCartKey;

        /// <summary>
        /// Initialization of the compatibility class
        /// </summary>
        internal static void Init()
        {
            IngameKeybinds.Instance = new();
        }
    }
}
