using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Services;

namespace makevpo101greatagain;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.vinihns.makevpo101greatagain";
    public override string Name { get; init; } = "Make VPO-101 Great Again";
    public override string Author { get; init; } = "ViniHNS";
    public override SemanticVersioning.Version Version { get; init; } = new("1.3.0"); 
    public override SemanticVersioning.Range SptVersion { get; init; } = new("~4.0.0");
    public override string? License { get; init; } = "MIT";
    
    public override List<string>? Contributors { get; init; }
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }
    public override string? Url { get; init; }
    public override bool? IsBundleMod { get; init; }
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class Mod(
    ISptLogger<Mod> logger,
    DatabaseService databaseService)
    : IOnLoad
{
    // ID (TPL) da VPO-101
    private const string VPO101_TPL = "5c501a4d2e221602b412b540";
    
    public Task OnLoad()
    {
        logger.Success("[ViniHNS] Making the VPO-101 great again!");

        var items = databaseService.GetItems();
        
        if (!items.TryGetValue(VPO101_TPL, out var vpo101))
        {
            logger.Error($"Could not find VPO-101 ({VPO101_TPL}). Aborting.");
            return Task.CompletedTask;
        }
        
        if (vpo101.Properties?.Slots == null || vpo101.Properties.Slots.Count() <= 6)
        {
            logger.Error($"VPO-101 ({VPO101_TPL}) does not have the expected muzzle slot (index 6). Aborting.");
            return Task.CompletedTask;
        }
        
        var muzzleFilterObject = vpo101.Properties.Slots.ElementAt(6).Properties?.Filters?.FirstOrDefault();
        if (muzzleFilterObject?.Filter == null)
        {
            logger.Error("Could not find filter set on VPO-101 muzzle slot. Aborting.");
            return Task.CompletedTask;
        }
        var muzzleFilterSet = muzzleFilterObject.Filter;

        // Lista de todos os quebra-chamas/compensadores 7.62x51 para adicionar
        var muzzleDeviceIds = new List<string>
        {
            "5a34fd2bc4a282329a73b4c5", "5dfa3cd1b33c0951220c079b", "6130c43c67085e45ef1405a1", 
            "5c7954d52e221600106f4cc7", "59bffc1f86f77435b128b872", "628a66b41d5e41750e314f34", 
            "612e0e3c290d254f5e6b291d", "612e0d3767085e45ef14057f", "615d8eb350224f204c1da1cf", 
            "607ffb988900dc2d9a55b6e4", "6065c6e7132d4d12c81fd8e1", "5c878e9d2e2216000f201903", 
            "5bbdb8bdd4351e4502011460", "5b7d693d5acfc43bca706a3d", "5d026791d7ad1a04a067ea63", 
            "5cdd7685d7f00c000f260ed2", "5cdd7693d7f00c0010373aa5", "5cf78720d7f00c06595bc93e", 
            "5d02677ad7ad1a04a15c0f95", "5d1f819086f7744b355c219b", "5d443f8fa4b93678dd4a01aa", 
            "5dfa3cd1b33c0951220c079b", "5fbc22ccf24b94483f726483", "5fbe7618d6fa9c00c571bb6c"
        };
        
        // Adiciona cada ID da lista ao HashSet de filtros
        foreach (var id in muzzleDeviceIds)
        {
            muzzleFilterSet.Add(new MongoId(id));
        }

        // Modifica a ergonomia da arma
        if (vpo101.Properties != null)
        {
            vpo101.Properties.Ergonomics = 30;
        }

        logger.Info("VPO-101 modded successfully!");

        return Task.CompletedTask;
    }
}