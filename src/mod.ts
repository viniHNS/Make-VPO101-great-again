import { DependencyContainer } from "tsyringe";
import { IPostDBLoadMod } from "@spt-aki/models/external/IPostDBLoadMod";
import { DatabaseServer } from "@spt-aki/servers/DatabaseServer";
import { IPreAkiLoadMod } from "@spt-aki/models/external/IPreAkiLoadMod";
import { ILogger } from "@spt-aki/models/spt/utils/ILogger";
import { LogTextColor } from "@spt-aki/models/spt/logging/LogTextColor";

class Mod implements IPostDBLoadMod, IPreAkiLoadMod
{
    preAkiLoad(container: DependencyContainer): void 
    {
        // get the logger from the server container
        const logger = container.resolve<ILogger>("WinstonLogger");
        logger.logWithColor("Making the VPO-101 great again!", LogTextColor.GREEN);
    }

    public postDBLoad(container: DependencyContainer): void 
    {
        // get database from server
        const databaseServer = container.resolve<DatabaseServer>("DatabaseServer");

        // Get all the in-memory json found in /assets/database
        const tables = databaseServer.getTables();

        // Find the VPO-101 item by its Id
        const vpo101 = tables.templates.items["5c501a4d2e221602b412b540"];
        
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5a34fd2bc4a282329a73b4c5") //AR-10 AAC Blackout 51T 7.62x51 flash hider
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5dfa3cd1b33c0951220c079b") //AR-10 KAC QDC 7.62x51 Flash Suppressor Kit
        vpo101._props.Slots[6]._props.filters[0].Filter.push("6130c43c67085e45ef1405a1") //AR-10 KAC QDC 7.62x51 Muzzle Brake Kit
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5c7954d52e221600106f4cc7") //Gemtech ONE Direct Thread Mount adapter
        vpo101._props.Slots[6]._props.filters[0].Filter.push("59bffc1f86f77435b128b872") //SilencerCo Hybrid 46 Direct Thread Mount adapter
        vpo101._props.Slots[6]._props.filters[0].Filter.push("628a66b41d5e41750e314f34") //AR-10 Dead Air Keymount 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("612e0e3c290d254f5e6b291d") //AR-10 TAA ZK-38 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("612e0d3767085e45ef14057f") //AWC PSR 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("615d8eb350224f204c1da1cf") //AR-10 SureFire Warden 7.62x51 blast regulator
        vpo101._props.Slots[6]._props.filters[0].Filter.push("607ffb988900dc2d9a55b6e4") //AR-10 SureFire ProComp 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("6065c6e7132d4d12c81fd8e1") //AR-10 CMMG SV Brake 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5c878e9d2e2216000f201903") //AR-10 Lantac Dragon 7.62x51 muzzle brake-compensator
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5bbdb8bdd4351e4502011460") //AR-10 Odin Works ATLAS-7 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5b7d693d5acfc43bca706a3d") //AR-10 2A Armanent X3 7.62x51 compensator
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5d026791d7ad1a04a067ea63") //AR-10 Fortis RED Brake 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5cdd7685d7f00c000f260ed2") //AR-10 Keeno Arms SHREWD 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5cdd7693d7f00c0010373aa5") //AR-10 Precision Armanent M11 Severe-Duty 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5cf78720d7f00c06595bc93e") //Lantac BMD 7.62x51 Blast Mitigation Device
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5d02677ad7ad1a04a15c0f95") //AR-10 Nordic Components Corvette 7.62x51 compensator
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5d1f819086f7744b355c219b") //AR-10 Daniel Defense WAVE 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5d443f8fa4b93678dd4a01aa") //AR-10 Thunder Beast Arms 30CB 7.62x51 muzzle brake
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5dfa3cd1b33c0951220c079b") //AR-10 KAC QDC 7.62x51 Flash Suppressor Kit
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5fbc22ccf24b94483f726483") //SIG Sauer Taper-LOK 7.62x51/.300 BLK muzzle adapter
        vpo101._props.Slots[6]._props.filters[0].Filter.push("5fbe7618d6fa9c00c571bb6c") //SIG Sauer SRD762Ti 7.62x51 sound suppressor
        
        vpo101._props.Ergonomics = 30;

    }
}

module.exports = { mod: new Mod() }