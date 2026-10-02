<div align="center">

# Make VPO-101 Great Again!

Um mod de server para o SPT 4.1.6 que libera muzzle devices e supressores de 7.62x51 na VPO-101 Vepr-Hunter, para ela competir com os outros rifles do mesmo calibre.

![Version](https://img.shields.io/badge/version-1.5.0-orange?style=flat)
![SPT](https://img.shields.io/badge/SPT-4.1.6-blue?style=flat)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat&logo=dotnet)
![License](https://img.shields.io/badge/license-MIT-green?style=flat)

[Funcionalidades](#funcionalidades) · [Instalação](#instalação) · [Muzzle devices](#muzzle-devices) · [Build](#build-a-partir-do-código)

[English](README.md) · **Português**

</div>

---

## Funcionalidades

| Alteração | Jogo | Mod |
|---|---|---|
| Slot de muzzle | Peças da VPO-101 | + 23 quebra-chamas, freios de boca, adaptadores e um supressor de AR-10 / 7.62x51 |
| Ergonomia | 29 | 30 |

Os adaptadores Gemtech ONE, SilencerCo Hybrid 46 e SIG Taper-LOK abrem caminho para os supressores que encaixam neles.

---

## Instalação

Extraia o `makevpo101greatagain.zip` na pasta do jogo SPT:

```
<pasta do jogo>/
└── SPT_Runtime/user/mods/makevpo101greatagain/
    └── makevpo101greatagain.dll
```

Só server, não precisa de plugin no client.

---

## Muzzle devices

<details>
<summary>Os 23 itens adicionados ao slot de muzzle da VPO-101</summary>

| Item | Tipo |
|---|---|
| AR-10 AAC Blackout 51T flash hider | Quebra-chamas |
| AR-10 KAC QDC Flash Suppressor Kit | Quebra-chamas |
| AR-10 KAC QDC Muzzle Brake Kit | Freio de boca |
| AR-10 Dead Air Keymount muzzle brake | Freio de boca |
| AR-10 TAA ZK-38 muzzle brake | Freio de boca |
| AR-10 AWC PSR muzzle brake | Freio de boca |
| AR-10 SureFire Warden blast regulator | Regulador de blast |
| AR-10 SureFire ProComp muzzle brake | Freio de boca |
| AR-10 CMMG SV Brake muzzle brake | Freio de boca |
| AR-10 Lantac Dragon muzzle brake-compensator | Freio de boca |
| AR-10 Odin Works ATLAS-7 muzzle brake | Freio de boca |
| AR-10 2A Armanent X3 compensator | Compensador |
| AR-10 Fortis RED Brake muzzle brake | Freio de boca |
| AR-10 Keeno Arms SHREWD muzzle brake | Freio de boca |
| AR-10 Precision Armanent M11 Severe-Duty muzzle brake | Freio de boca |
| AR-10 Nordic Components Corvette compensator | Compensador |
| AR-10 Daniel Defense WAVE muzzle brake | Freio de boca |
| AR-10 Thunder Beast Arms 30CB muzzle brake | Freio de boca |
| Lantac BMD Blast Mitigation Device | Regulador de blast |
| Gemtech ONE Direct Thread Mount adapter | Adaptador de supressor |
| SilencerCo Hybrid 46 Direct Thread Mount adapter | Adaptador de supressor |
| SIG Sauer Taper-LOK 7.62x51/.300 BLK muzzle adapter | Adaptador de supressor |
| SIG Sauer SRD762Ti 7.62x51 sound suppressor | Supressor |

</details>

---

## Build a partir do código

**Requisitos:** .NET 10 SDK.

```sh
dotnet build makevpo101greatagain.sln -c Release
```

O build gera o `makevpo101greatagain.zip` na pasta da solution.

> O `.csproj` copia o build para `D:\Jogos\SPT4.1` para teste, quando essa pasta existe. Troque o `SptModsDir` pela sua pasta do SPT. Feche o server do SPT antes de compilar, senão a cópia falha porque a DLL está em uso.

### Estrutura do projeto

```
Make-VPO101-great-again/
├── makevpo101greatagain.sln
└── Server/                         server mod .NET 10
    ├── Mod.cs                      metadata do mod
    └── Vpo101Changes.cs            alterações no slot de muzzle e na ergonomia
```

---

## Recursos

| Recurso | URL |
|---|---|
| SPT Server C# | https://github.com/SP-Tushonka/server-csharp |
| Exemplos de server mod | https://github.com/SP-Tushonka/server-mod-examples |
| SPT Wiki — Modding Resources | https://wiki.sp-tushonka.com/en/modding/Modding_Resources |
| SPT Scaffold | https://github.com/viniHNS/spt-scaffold |
