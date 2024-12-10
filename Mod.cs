using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using ff16.skins.clivesswords.Template;
using ff16.skins.clivesswords.Configuration;
using ff16.utility.modloader.Interfaces;
using System;
using static ff16.skins.clivesswords.Configuration.Config;

namespace ff16.skins.clivesswords;

public class Mod : ModBase
{
    private readonly IModLoader _modLoader;
    private readonly IReloadedHooks? _hooks;
    private readonly ILogger _logger;
    private readonly IMod _owner;
    private Config _configuration;
    private readonly IModConfig _modConfig;

    public Mod(ModContext context)
    {
        _modLoader = context.ModLoader;
        _hooks = context.Hooks;
        _logger = context.Logger;
        _owner = context.Owner;
        _configuration = context.Configuration;
        _modConfig = context.ModConfig;

        // Log initial configuration
        _logger.WriteLine($"[{_modConfig.ModId}] Initializing mod with configuration:");
        _logger.WriteLine($"[{_modConfig.ModId}] Selected Sword: {_configuration.SelectedSword}");
        _logger.WriteLine($"[{_modConfig.ModId}] Selected Skin: {_configuration.SelectedSkin}");

        try
        {
            // Get the chosen sword and its string value
            Sword chosenSword = _configuration.SelectedSword;
            string swordStringValue = SwordStringMappings[chosenSword];
            _logger.WriteLine($"[{_modConfig.ModId}] Mapped sword value: {swordStringValue}");

            // Get the chosen skin and its string value
            Skin chosenSkin = _configuration.SelectedSkin;
            string skinStringValue = SkinStringMappings[chosenSkin];
            _logger.WriteLine($"[{_modConfig.ModId}] Mapped skin value: {skinStringValue}");

            // Fetch IFF16ModPackManager to add files
            var controller = _modLoader.GetController<IFF16ModPackManager>();
            if (controller is null)
            {
                _logger.WriteLine($"[{_modConfig.ModId}] ERROR: Failed to get IFF16ModPackManager controller");
                return;
            }

            if (!controller.TryGetTarget(out IFF16ModPackManager modPackManager))
            {
                _logger.WriteLine($"[{_modConfig.ModId}] ERROR: Failed to get IFF16ModPackManager target");
                return;
            }

            if (modPackManager is null)
            {
                _logger.WriteLine($"[{_modConfig.ModId}] ERROR: ModPackManager is null");
                return;
            }

            // Generate correct file paths 
            string targetSwordFile = $"chara/c8001/model/body/{swordStringValue}/body.mdl";
            string targetSkinFile = $"chara/c8001/model/body/{skinStringValue}/body.mdl";

            _logger.WriteLine($"[{_modConfig.ModId}] Attempting to load skin file: {targetSkinFile}");

            if (!modPackManager.FileExists(targetSkinFile))
            {
                _logger.WriteLine($"[{_modConfig.ModId}] ERROR: Skin file not found: {targetSkinFile}");
                return;
            }

            // Load chosen skin
            var skinFileData = modPackManager.GetFileData(targetSkinFile);
            _logger.WriteLine($"[{_modConfig.ModId}] Successfully loaded skin file. Size: {skinFileData.Length} bytes");

            // Overwrite the chosen sword model file with the loaded skin file 
            modPackManager.AddModdedFile(_modConfig.ModId, targetSwordFile, skinFileData);
            _logger.WriteLine($"[{_modConfig.ModId}] Successfully applied skin to target sword file: {targetSwordFile}");
        }
        catch (Exception ex)
        {
            _logger.WriteLine($"[{_modConfig.ModId}] CRITICAL ERROR: {ex.Message}");
            _logger.WriteLine($"[{_modConfig.ModId}] Stack trace: {ex.StackTrace}");
        }
    }

    public override void ConfigurationUpdated(Config configuration)
    {
        _logger.WriteLine($"[{_modConfig.ModId}] Configuration update detected");
        _configuration = configuration;
        _logger.WriteLine($"[{_modConfig.ModId}] New configuration applied - Sword: {configuration.SelectedSword}, Skin: {configuration.SelectedSkin}");
    }

    #region For Exports, Serialization etc.
#pragma warning disable CS8618
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}