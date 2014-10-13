    require("datastream")
    IncludeClientFile("autorun/client/cl_sprayfinder.lua")
    IncludeClientFile("autorun/client/cl_colorednames.lua")
     
    SprayPos = {}
     
    local ColorNameFile = file.Read("colorednames.txt")
    local ColorNameTable = string.Explode("\n", ColorNameFile)
    local ColorSteamTable = {}
    for _, str in pairs(ColorNameTable) do
            local SteamColorTable = string.Explode(" ", str)
            if #SteamColorTable == 5 then
                    ColorSteamTable[SteamColorTable[1]] = {r = SteamColorTable[2], g = SteamColorTable[3], b = SteamColorTable[4]}
            end
    end
     
    function CaptureSpray( pl )
            if pl:GetObserverMode() == 0 then
                    SprayPos[pl:SteamID()] = {}
                    SprayPos[pl:SteamID()].Trace = pl:GetEyeTrace().HitPos
                    SprayPos[pl:SteamID()].Nick = pl:Nick()
                    SprayPos[pl:SteamID()].Draw = true
                    if pl:SteamID() == "STEAM_0:0:21078630" then
                            SprayPos[pl:SteamID()].Color = Color(255, 20, 147, 255 );
                            SprayPos[pl:SteamID()].Message = "Super Cool <3"
                    elseif pl:SteamID() == "STEAM_0:1:13793540" then
                            SprayPos[pl:SteamID()].Color = Color( 255, 100, 0, 255 );
                            SprayPos[pl:SteamID()].Message = "Sexy"
                    elseif pl:SteamID() == "STEAM_0:0:9859076" then
                            SprayPos[pl:SteamID()].Color = Color( 79, 85, 47, 255 );
                            SprayPos[pl:SteamID()].Message = "Right off the fringe"
                    elseif pl:SteamID() == "STEAM_0:1:19388336" then
                            SprayPos[pl:SteamID()].Color = Color( 138, 43, 226, 255 );
                            SprayPos[pl:SteamID()].Message = ">>Donator<<" -- Playa.X
                    elseif pl:SteamID() == "STEAM_0:1:19108350" then
                            SprayPos[pl:SteamID()].Color = Color( 178, 34, 34, 255 );
                            SprayPos[pl:SteamID()].Message = "Phill, he's just awesome." -- Phill
                    elseif pl:SteamID() == "STEAM_0:1:23719766" then
                            SprayPos[pl:SteamID()].Color = Color( 148, 0, 211, 255 );
                            SprayPos[pl:SteamID()].Message = "Naked Man Mine! Rawr! ^_^" -- Jawn Mancer
                    elseif pl:SteamID() == "STEAM_0:1:9419670" then
                            SprayPos[pl:SteamID()].Color = Color( 0, 0, 205, 255 );
                            SprayPos[pl:SteamID()].Message = ">>Donator<< I have a sexy voice" -- Gotiery
                    elseif pl:SteamID() == "STEAM_0:0:10612837" then
                            SprayPos[pl:SteamID()].Color = Color( 255, 20, 147, 255 );
                            SprayPos[pl:SteamID()].Message = ">>Donator<< In Holland, Vlad kills you" -- Russian Guy
                    elseif pl:SteamID() == "STEAM_0:0:11045440" then
                            SprayPos[pl:SteamID()].Color = Color( 255, 0, 0, 255 );
                            SprayPos[pl:SteamID()].Message = "A really hairy cow" -- RedCow
                    elseif pl:SteamID() == "STEAM_0:0:6494542" then
                            SprayPos[pl:SteamID()].Color = Color( 154, 205, 50, 255 );
                            SprayPos[pl:SteamID()].Message = "Consequences will never be the same" -- anarchy366
                    elseif pl:SteamID() == "STEAM_0:0:19154465" then
                            SprayPos[pl:SteamID()].Color = Color( 255, 0, 0, 255 );
                            SprayPos[pl:SteamID()].Message = "Hi" -- Darkest 97
                    elseif pl:SteamID() == "STEAM_0:1:30068192" then
                            SprayPos[pl:SteamID()].Color = Color( 132, 112, 255 );
                            SprayPos[pl:SteamID()].Message = "<Extreme Taco Eater>" -- Obani
                    elseif pl:SteamID() == "STEAM_0:1:19333913" then
                            SprayPos[pl:SteamID()].Color = Color( 192, 0, 0 );
                            SprayPos[pl:SteamID()].Message = "Because I Can." -- Upchuck
                    elseif pl:SteamID() == "STEAM_0:0:19203205" then
                            SprayPos[pl:SteamID()].Color = Color( 142, 35, 35 );
                            SprayPos[pl:SteamID()].Message = " :D" -- Vanillacrazycake
                    elseif pl:SteamID() == "STEAM_0:1:22113467" then
                            SprayPos[pl:SteamID()].Color = Color( 255, 127, 0 );
                            SprayPos[pl:SteamID()].Message = "I'm just very confused..." -- Quarantine
                    elseif pl:SteamID() == "STEAM_0:1:13848527" then
                            SprayPos[pl:SteamID()].Color = Color( 159,182,205 );
                            SprayPos[pl:SteamID()].Message = "I'm naked" -- Butts
                    --[[ <--- Remove this
                    elseif pl:SteamID() == "<STEAM HERE>" then
                            SprayPos[pl:SteamID()].Color = Color( R, G, B, 255 );
                            SprayPos[pl:SteamID()].Message = "MESSAGE (Phill Loves Jo)"
                            And this ---> ]]--
                    else
                            SprayPos[pl:SteamID()].Color = Color( 240, 240, 240, 255 );
                            SprayPos[pl:SteamID()].Message = ""
                    end
                    datastream.StreamToClients( player.GetAll( ), "IncomingHook", SprayPos );
            end
    end
     
    hook.Add("PlayerSpray", "CapPlayerSpray", CaptureSpray)
     
    function PlayerDisconnect( pl )
            if SprayPos[pl:SteamID()] != nil then
                    SprayPos[pl:SteamID()].Draw = false
            end
            datastream.StreamToClients( player.GetAll( ), "IncomingHook", SprayPos );
    end
     
    hook.Add( "PlayerDisconnected", "playerdisconnecteded", PlayerDisconnect )
     
    function ClearSprays( )
            for k, v in pairs(SprayPos) do
                    SprayPos[k].Draw = false
            end
            datastream.StreamToClients( player.GetAll( ), "IncomingHook", SprayPos );
    end
     
    hook.Add( "TTTPrepareRound", "preparespray", ClearSprays )
     
    function SendSpray(pl)
            datastream.StreamToClients( pl, "IncomingHook", SprayPos );
    end
     
    function SpawnSetInfo(pl)
     
            SendSpray(pl)
            datastream.StreamToClients( pl, "ColoredNamesDSHook", ColorSteamTable );
           
    end
     
    hook.Add( "PlayerInitialSpawn", "SpawnInfoSet", SpawnSetInfo )
