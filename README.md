<div align="center">

# Make VPO-101 Great Again!

A server mod for SPT 4.1.6 that lets the VPO-101 Vepr-Hunter run 7.62x51 muzzle devices and suppressors, so it can compete with the other rifles of its caliber.

![Version](https://img.shields.io/badge/version-1.5.0-orange?style=flat)
![SPT](https://img.shields.io/badge/SPT-4.1.6-blue?style=flat)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat&logo=dotnet)
![License](https://img.shields.io/badge/license-MIT-green?style=flat)

[Features](#features) · [Install](#install) · [Muzzle Devices](#muzzle-devices) · [Build](#build-from-source)

**English** · [Português](README_BR.md)

</div>

---

## Features

| Change | Game | Mod |
|---|---|---|
| Muzzle slot | VPO-101 devices | + 23 AR-10 / 7.62x51 flash hiders, muzzle brakes, adapters and a suppressor |
| Ergonomics | 29 | 30 |

The Gemtech ONE, SilencerCo Hybrid 46 and SIG Taper-LOK adapters open the way to the suppressors that mount on them.

---

## Install

Extract `makevpo101greatagain.zip` into your SPT game folder:

```
<game folder>/
└── SPT_Runtime/user/mods/makevpo101greatagain/
    └── makevpo101greatagain.dll
```

Server only, no client plugin needed.

---

## Muzzle Devices

<details>
<summary>The 23 devices added to the VPO-101 muzzle slot</summary>

| Device | Type |
|---|---|
| AR-10 AAC Blackout 51T flash hider | Flash hider |
| AR-10 KAC QDC Flash Suppressor Kit | Flash hider |
| AR-10 KAC QDC Muzzle Brake Kit | Muzzle brake |
| AR-10 Dead Air Keymount muzzle brake | Muzzle brake |
| AR-10 TAA ZK-38 muzzle brake | Muzzle brake |
| AR-10 AWC PSR muzzle brake | Muzzle brake |
| AR-10 SureFire Warden blast regulator | Blast regulator |
| AR-10 SureFire ProComp muzzle brake | Muzzle brake |
| AR-10 CMMG SV Brake muzzle brake | Muzzle brake |
| AR-10 Lantac Dragon muzzle brake-compensator | Muzzle brake |
| AR-10 Odin Works ATLAS-7 muzzle brake | Muzzle brake |
| AR-10 2A Armanent X3 compensator | Compensator |
| AR-10 Fortis RED Brake muzzle brake | Muzzle brake |
| AR-10 Keeno Arms SHREWD muzzle brake | Muzzle brake |
| AR-10 Precision Armanent M11 Severe-Duty muzzle brake | Muzzle brake |
| AR-10 Nordic Components Corvette compensator | Compensator |
| AR-10 Daniel Defense WAVE muzzle brake | Muzzle brake |
| AR-10 Thunder Beast Arms 30CB muzzle brake | Muzzle brake |
| Lantac BMD Blast Mitigation Device | Blast regulator |
| Gemtech ONE Direct Thread Mount adapter | Suppressor adapter |
| SilencerCo Hybrid 46 Direct Thread Mount adapter | Suppressor adapter |
| SIG Sauer Taper-LOK 7.62x51/.300 BLK muzzle adapter | Suppressor adapter |
| SIG Sauer SRD762Ti 7.62x51 sound suppressor | Suppressor |

</details>

---

## Build from Source

**Requirements:** .NET 10 SDK.

```sh
dotnet build makevpo101greatagain.sln -c Release
```

The build creates `makevpo101greatagain.zip` in the solution folder.

> The `.csproj` copies the build output into `D:\Jogos\SPT4.1` for testing when that folder exists. Change `SptModsDir` to your own SPT folder. Close the SPT server before building, or the copy fails because the DLL is in use.

### Project Structure

```
Make-VPO101-great-again/
├── makevpo101greatagain.sln
└── Server/                         .NET 10 server mod
    ├── Mod.cs                      mod metadata
    └── Vpo101Changes.cs            muzzle slot and ergonomics changes
```

---

## Resources

| Resource | URL |
|---|---|
| SPT Server C# | https://github.com/SP-Tushonka/server-csharp |
| Server Mod Examples | https://github.com/SP-Tushonka/server-mod-examples |
| SPT Wiki — Modding Resources | https://wiki.sp-tushonka.com/en/modding/Modding_Resources |
| SPT Scaffold | https://github.com/viniHNS/spt-scaffold |
