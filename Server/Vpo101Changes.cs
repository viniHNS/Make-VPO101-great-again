using SPTarkov.Common.Models.Logging;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Spt.Tables;

namespace MakeVpo101GreatAgain;

/// <summary>
/// Lets the VPO-101 use 7.62x51 muzzle devices and bumps its ergonomics.
/// </summary>
[Injectable(TypePriority = OnLoadOrder.PostLoad + 1)]
public class Vpo101Changes(
    ISptLogger<Vpo101Changes> logger,
    TemplateTable templateTable) : IOnLoad
{
    // Molot Arms VPO-101 Vepr-Hunter 7.62x51 carbine
    private const string Vpo101Tpl = "5c501a4d2e221602b412b540";

    // Index of "mod_muzzle" in the VPO-101 Slots list
    private const int MuzzleSlotIndex = 6;

    private const double NewErgonomics = 30;

    // 7.62x51 flash hiders, muzzle brakes, adapters and suppressors to allow on the muzzle slot
    private static readonly string[] MuzzleDeviceIds =
    [
        "5a34fd2bc4a282329a73b4c5", // AR-10 AAC Blackout 51T flash hider
        "5dfa3cd1b33c0951220c079b", // AR-10 KAC QDC Flash Suppressor Kit
        "6130c43c67085e45ef1405a1", // AR-10 KAC QDC Muzzle Brake Kit
        "5c7954d52e221600106f4cc7", // Gemtech ONE Direct Thread Mount adapter
        "59bffc1f86f77435b128b872", // SilencerCo Hybrid 46 Direct Thread Mount adapter
        "628a66b41d5e41750e314f34", // AR-10 Dead Air Keymount muzzle brake
        "612e0e3c290d254f5e6b291d", // AR-10 TAA ZK-38 muzzle brake
        "612e0d3767085e45ef14057f", // AR-10 AWC PSR muzzle brake
        "615d8eb350224f204c1da1cf", // AR-10 SureFire Warden blast regulator
        "607ffb988900dc2d9a55b6e4", // AR-10 SureFire ProComp muzzle brake
        "6065c6e7132d4d12c81fd8e1", // AR-10 CMMG SV Brake muzzle brake
        "5c878e9d2e2216000f201903", // AR-10 Lantac Dragon muzzle brake-compensator
        "5bbdb8bdd4351e4502011460", // AR-10 Odin Works ATLAS-7 muzzle brake
        "5b7d693d5acfc43bca706a3d", // AR-10 2A Armanent X3 compensator
        "5d026791d7ad1a04a067ea63", // AR-10 Fortis RED Brake muzzle brake
        "5cdd7685d7f00c000f260ed2", // AR-10 Keeno Arms SHREWD muzzle brake
        "5cdd7693d7f00c0010373aa5", // AR-10 Precision Armanent M11 Severe-Duty muzzle brake
        "5cf78720d7f00c06595bc93e", // Lantac BMD Blast Mitigation Device
        "5d02677ad7ad1a04a15c0f95", // AR-10 Nordic Components Corvette compensator
        "5d1f819086f7744b355c219b", // AR-10 Daniel Defense WAVE muzzle brake
        "5d443f8fa4b93678dd4a01aa", // AR-10 Thunder Beast Arms 30CB muzzle brake
        "5fbc22ccf24b94483f726483", // SIG Sauer Taper-LOK 7.62x51/.300 BLK muzzle adapter
        "5fbe7618d6fa9c00c571bb6c", // SIG Sauer SRD762Ti 7.62x51 sound suppressor
    ];

    public Task OnLoadAsync(CancellationToken cancellationToken)
    {
        logger.Success("[ViniHNS] Making the VPO-101 great again!");

        if (!templateTable.Items.TryGetValue(Vpo101Tpl, out var vpo101))
        {
            logger.Error($"Could not find VPO-101 ({Vpo101Tpl}). Aborting.");
            return Task.CompletedTask;
        }

        var slots = vpo101.Properties?.Slots?.ToList();
        if (slots == null || slots.Count <= MuzzleSlotIndex)
        {
            logger.Error($"VPO-101 ({Vpo101Tpl}) does not have the expected muzzle slot (index {MuzzleSlotIndex}). Aborting.");
            return Task.CompletedTask;
        }

        var muzzleFilterSet = slots[MuzzleSlotIndex].Properties?.Filters?.FirstOrDefault()?.Filter;
        if (muzzleFilterSet == null)
        {
            logger.Error("Could not find filter set on VPO-101 muzzle slot. Aborting.");
            return Task.CompletedTask;
        }

        foreach (var id in MuzzleDeviceIds)
        {
            muzzleFilterSet.Add(new MongoId(id));
        }

        vpo101.Properties!.Ergonomics = NewErgonomics;

        logger.Info("VPO-101 modded successfully!");
        return Task.CompletedTask;
    }
}
