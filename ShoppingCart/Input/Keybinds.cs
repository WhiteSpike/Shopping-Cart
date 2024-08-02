using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine.InputSystem;
using ShoppingCart.Behaviour;
using ShoppingCart.Compat;
using static UnityEngine.InputSystem.InputAction;

namespace ShoppingCart.Input
{
    /// <summary>
    /// Class used to initialize the keybinds on game boot
    /// </summary>
    [HarmonyPatch]
    internal static class Keybinds
    {
        /// <summary>
        /// Asset used to store all the input bindings defined for our controls
        /// </summary>
        public static InputActionAsset Asset;

        public static InputActionMap ActionMap;

        /// <summary>
        /// Input binding used to trigger the drop all items in the shopping cart action
        /// </summary>
        public static InputAction ShoppingCartAction;

        public static PlayerControllerB localPlayerController => StartOfRound.Instance?.localPlayerController;

        /// <summary>
        /// Initializes the related assets with the control bindings
        /// </summary>
        [HarmonyPatch(typeof(PreInitSceneScript), "Awake")]
        [HarmonyPrefix]
        public static void AddToKeybindMenu()
        {
            Asset = InputUtilsCompat.Asset;
            ActionMap = Asset.actionMaps[0];
            ShoppingCartAction = InputUtilsCompat.ShoppingCartKey;
        }
        /// <summary>
        /// Turn on relevant control bindings when starting a game
        /// </summary>
        [HarmonyPatch(typeof(StartOfRound), "OnEnable")]
        [HarmonyPostfix]
        public static void OnEnable()
        {
            Asset.Enable();
            ShoppingCartAction.performed += OnShoppingCartActionPerformed;
        }

        /// <summary>
        /// Turn off relevant control bindings when exiting a game
        /// </summary>
        [HarmonyPatch(typeof(StartOfRound), "OnDisable")]
        [HarmonyPostfix]
        public static void OnDisable()
        {
            Asset.Disable();
            ShoppingCartAction.performed -= OnShoppingCartActionPerformed;
        }
        /// <summary>
        /// Function performed when triggering the "Drop all items in Shopping Cart" control binding
        /// </summary>
        /// <param name="context">Context which triggered this function</param>
        private static void OnShoppingCartActionPerformed(CallbackContext context)
        {
            if (localPlayerController == null || !localPlayerController.isPlayerControlled || (localPlayerController.IsServer && !localPlayerController.isHostPlayerObject))
            {
                return;
            }

            if (!localPlayerController.currentlyHeldObjectServer) return;
            ShoppingCartBehaviour shoppingCart = localPlayerController.currentlyHeldObjectServer.GetComponent<ShoppingCartBehaviour>();
            if (!shoppingCart) return;

            shoppingCart.UpdateContainerDrop();
        }
    }
}
