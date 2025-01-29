using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using ff16.skins.clivesswords.Template;
using ff16.skins.clivesswords.Configuration;
using ff16.utility.modloader.Interfaces;
using System;
using static ff16.skins.clivesswords.Configuration.Config;
using System.IO;

namespace ff16.skins.clivesswords;

public class Mod : ModBase
{
    private readonly IModLoader _modLoader;
    private readonly IReloadedHooks? _hooks;
    private readonly ILogger _logger;
    private readonly IMod _owner;
    private Config _configuration;
    private readonly IModConfig _modConfig;

    private class ModFileInfo
    {
        public string TargetPath { get; set; }  // Path the mod file should be written to
        public string OriginPath { get; set; }   // Path to the mod file to be retrieved
    }

    // Dictionary containing hardcoded external paths for specific weapon skins
    private static readonly Dictionary<Skin, List<ModFileInfo>> ExternalFiles = new()
    {
        { (Skin.HolyMoonlight), new List<ModFileInfo>
            {
                new ModFileInfo
                {
                    TargetPath = "TBD", // TBD indicates the body.mdl file which must be written to the target sword path
                    OriginPath = "HML/body.mdl"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/material/m_c8001b0hml_body.mtl",
                    OriginPath = "m_c8001b0hml_body.mtl"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/material/m_c8001b0hml_body1.mtl",
                    OriginPath = "m_c8001b0hml_body1.mtl"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body_base.tex",
                    OriginPath = "t_c8001b0hml_body_base.tex"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body_flow.tex",
                    OriginPath = "t_c8001b0hml_body_flow.tex"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body_meta.tex",
                    OriginPath = "t_c8001b0hml_body_meta.tex"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body_norm.tex",
                    OriginPath = "t_c8001b0hml_body_norm.tex"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body_occl.tex",
                    OriginPath = "t_c8001b0hml_body_occl.tex"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body_roug.tex",
                    OriginPath = "t_c8001b0hml_body_roug.tex"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body_tile0_mask.tex",
                    OriginPath = "t_c8001b0hml_body_tile0_mask.tex"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body_tile1_mask.tex",
                    OriginPath = "t_c8001b0hml_body_tile1_mask.tex"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body1_base.tex",
                    OriginPath = "t_c8001b0hml_body1_base.tex"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body1_mask.tex",
                    OriginPath = "t_c8001b0hml_body1_mask.tex"
                },
                new ModFileInfo
                {
                    TargetPath = "0001/chara/c8001/model/body/b0030/texture/t_c8001b0hml_body1_norm.tex",
                    OriginPath = "t_c8001b0hml_body1_norm.tex"
                }
            }
        }
    };

    // Define list of required mod files - Hardcoded paths must be maintained inside here also
    private List<ModFileInfo> GetRequiredFiles()
    {
        string modPath = _modLoader.GetDirectoryForModId(_modConfig.ModId);
        List<ModFileInfo> requiredFiles = new();
        var skinKey = (_configuration.SelectedSkin);

        if (ExternalFiles.TryGetValue(skinKey, out var externalFiles))
        {
            foreach (var externalFile in externalFiles)
            {
                if (externalFile.TargetPath != "TBD")
                {
                    AddFileIfNotExists(requiredFiles, new ModFileInfo
                    {
                        TargetPath = externalFile.TargetPath,
                        OriginPath = Path.Combine(modPath, "mdlmtltex", externalFile.OriginPath)
                    });
                }
                
            }
        }

        /*
        // DEBUG logging after this, remove before publishing
        _logger.WriteLine($"[{_modConfig.ModId}] DEBUG: Contents of requiredFiles list:", _logger.ColorLightBlue);
        foreach (var file in requiredFiles)
        {
            _logger.WriteLine($"[{_modConfig.ModId}] TargetPath: {file.TargetPath}", _logger.ColorLightBlue);
            _logger.WriteLine($"[{_modConfig.ModId}] OriginPath: {file.OriginPath}", _logger.ColorLightBlue);
            _logger.WriteLine($"[{_modConfig.ModId}] ----------------------", _logger.ColorLightBlue);
        }
        */

        return requiredFiles;
    }

    private void AddFileIfNotExists(List<ModFileInfo> files, ModFileInfo newFile)
    {
        if (!files.Any(f => f.TargetPath == newFile.TargetPath))
        {
            files.Add(newFile);
        }
    }

    string GetOriginPathForTBDTarget(Dictionary<Skin, List<ModFileInfo>> externalFiles)
    {
        foreach (var kvp in externalFiles)
        {
            foreach (var fileInfo in kvp.Value)
            {
                if (fileInfo.TargetPath == "TBD")
                {
                    return fileInfo.OriginPath;
                }
            }
        }

        return null; // Return null if no entry with TargetPath "TBD" is found
    }

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

        string modPath = _modLoader.GetDirectoryForModId(_modConfig.ModId);

        try
        {
            // Get the chosen sword and its string value
            Sword chosenSword = _configuration.SelectedSword;
            string swordStringValue = SwordStringMappings[chosenSword];

            // Get the chosen skin and its path information
            Skin chosenSkin = _configuration.SelectedSkin;
            string skinPackNum = SkinStringMappings[chosenSkin].PackNum;
            string skinModelPath = SkinStringMappings[chosenSkin].ModelPath;

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

            string targetSwordFile = $"chara/c8001/model/body/{swordStringValue}/body.mdl";

            if (skinPackNum != "External")
            {
                // Generate correct internal file path
                string targetSkinFile = $"chara/{skinPackNum}/model/body/{skinModelPath}/body.mdl";

                if (!modPackManager.FileExists(targetSkinFile))
                {
                    _logger.WriteLine($"[{_modConfig.ModId}] ERROR: Skin file not found: {targetSkinFile}");
                    return;
                }

                // Load chosen skin
                var skinFileData = modPackManager.GetFileData(targetSkinFile);

                // Overwrite the chosen sword model file with the loaded skin file 
                modPackManager.AddModdedFile(_modConfig.ModId, targetSwordFile, skinFileData);
                _logger.WriteLine($"[{_modConfig.ModId}] Successfully applied skin to target sword file.");

                // Overwrite Odin's blades with the loaded skin file if user has chosen that
                if (_configuration.ReskinOdin is true)
                {
                    string odinFeatFile1 = $"chara/c1804/model/body/b0001/body.mdl";
                    string odinFeatFile2 = $"chara/c1804/model/body/b0002/body.mdl";

                    modPackManager.AddModdedFile(_modConfig.ModId, odinFeatFile1, skinFileData);
                    modPackManager.AddModdedFile(_modConfig.ModId, odinFeatFile2, skinFileData);
                }
            }
            else
            {
                // Get list of required external files for chosen skin
                var requiredFiles = GetRequiredFiles();

                // Add all required files
                foreach (var fileInfo in requiredFiles)
                {
                    byte[] fileData;

                    // Handle external mod files
                    if (!File.Exists(fileInfo.OriginPath))
                    {
                        _logger.WriteLine($"[{_modConfig.ModId}] ERROR: Local mod file not found: {fileInfo.OriginPath}");
                        continue;
                    }
                    fileData = File.ReadAllBytes(fileInfo.OriginPath);

                    try
                    {
                        // Load the game path from list
                        string gameFilePath = $"{fileInfo.TargetPath}";

                        // Write the file to the game
                        modPackManager.AddModdedFile(_modConfig.ModId, gameFilePath, fileData);
                        // Debug line below this, remove before publishing
                        _logger.WriteLine($"[{_modConfig.ModId}] DEBUG: Successfully loaded Mod file from {fileInfo.OriginPath} into {fileInfo.TargetPath}", _logger.ColorLightBlue);
                    }
                    catch (Exception ex)
                    {
                        _logger.WriteLine($"[{_modConfig.ModId}] Failed to load Mod file {fileInfo.OriginPath}: {ex.Message}", _logger.ColorRed);
                    }
                }

                // Load chosen skin's body.mdl file
                string skinMdlPath = Path.Combine(modPath, "mdlmtltex", GetOriginPathForTBDTarget(ExternalFiles));
                byte[] skinFileData;

                skinFileData = File.ReadAllBytes(skinMdlPath);

                // Overwrite the chosen sword model file with the loaded skin file 
                modPackManager.AddModdedFile(_modConfig.ModId, targetSwordFile, skinFileData);
                _logger.WriteLine($"[{_modConfig.ModId}] Successfully applied skin to target sword file.");
                // Debug line below this, remove before publishing
                _logger.WriteLine($"[{_modConfig.ModId}] DEBUG: Successfully loaded Mod file from {skinMdlPath} into {targetSwordFile}", _logger.ColorLightBlue);

                // Overwrite Odin's blades with the loaded skin file if user has chosen that
                if (_configuration.ReskinOdin is true)
                {
                    string odinFeatFile1 = $"chara/c1804/model/body/b0001/body.mdl";
                    string odinFeatFile2 = $"chara/c1804/model/body/b0002/body.mdl";

                    modPackManager.AddModdedFile(_modConfig.ModId, odinFeatFile1, skinFileData);
                    modPackManager.AddModdedFile(_modConfig.ModId, odinFeatFile2, skinFileData);
                }

            }
            
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