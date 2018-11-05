WOWSharp is a .NET Library for accessing Blizzard's World of Warcraft and Diablo Community APIs on Battle.net.
The Library is written in C# and is available for .NET Framework 4, Silverlight 4 (or higher), Windows Phone 7.5 (or higher) and .NET for Windows Store Apps.
Originally this project was created by Sherif Elmetainy (Grendiser@Kazzak-EU) @ https://wowsharp.codeplex.com/ under the MIT license.
Since codeplex is going to be closed and this project was abandoned by Grendizer i am copying the project here.

To use the Blizzard API and this library, you will need an account and API Key from https://dev.battle.net/

## Features

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/634aa715861b40cbbdfac28514fd287e)](https://www.codacy.com/app/Shogobg/wowsharp?utm_source=github.com&utm_medium=referral&utm_content=Shogobg/wowsharp&utm_campaign=badger)

* The library handles all HTTP connections, error handling and JSON deserialization
* Uses Task based async operations which makes developing responsive application easier.
* The following World of WarCraft API functions are currently supported
    * Get Character Profile
    * Get Guild Profile
    * Get Realm Status
    * Get Current Auctions Data
    * Get Item Information
    * Get PVP Leaderboards (Arena and Rated Battlegrounds)
    * Get Character Classes
    * Get Character Races
    * Get Guild Perks
    * Get Guild Rewards
    * Get Item Classes
    * Get Guild Achievements
    * Get Character achievements
    * Get Quest information
    * Get Battlegroups
    * Get Recipe
    * Get Item Set Information
    * Get Spell Information
    * Get Battle Pet Ability
    * Get Battle Pet Species Info
    * Get Talents
    * Get Battle Pet Types
    * Get Challenge Mode Leaderboard Information
* The following Diablo 3 API functions are currently supported
    * Get Diablo profile information
    * Get Hero information
    * Get Item or recipe information
    * Get Artisan information
    * Get Follower information
* Supports basic caching functionality (Cache Manager implementation not included, but the library supports hooking to any cache manager such as enterprise manager caching block, or MemoryCache)

## Links
https://dev.battle.net/ - API Home
https://us.battle.net/forums/en/bnet/15051533/index - Known issues
https://www.npmjs.com/package/battlenet-api - NPM API Package
https://github.com/benweier/blizzard.js - NPM API Package
https://wowwiki.wikia.com/wiki/Battle.net_API - API Wiki
https://worldofwarcraft.com/en-us/news/15336025/attention-web-developers - Blizzard OAUTH2 for login with battle.net account
