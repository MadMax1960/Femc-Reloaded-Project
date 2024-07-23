//private void GenerateMusicScriptDeprecated()
//{
	//Deprecated DO NOT USE
	//Author: TheBestAstroNOT
	//Credit for all the music goes to Atlus,Mosq,Mineformer,Karma, Stella and GillStudio
	/*
	try
	{
		_logger.WriteLineAsync("Regenerating music script");
		var battleThemes = GetDependency<IBattleThemesApi>("Battle Themes");
		//Initialise the music picker
		string night = "const night1List=[";
		string dayoutside1 = "const dayout1List=[";
		string dayinside1 = "const dayin1List=[";
		string dayinside2 = "const dayin2List=[";
		string sociallink11 = "const social11List= [";
		string sociallink12 = "const social12List= [";
		string finalbattle = "const finalbattle=[";

		string path = _modLoader.GetDirectoryForModId(_modConfig.ModId)+"/BGME/scripts";

		//Code for writing the commands

		if (_configuration.mosq)
		{
			battleThemes.AddPath(_modConfig.ModId, _modLoader.GetDirectoryForModId(_modConfig.ModId) + "/battle-themes/Mosq");
		}


		if (_configuration.karma)
		{
			battleThemes.AddPath(_modConfig.ModId, _modLoader.GetDirectoryForModId(_modConfig.ModId) + "/battle-themes/Karma");
		}


		if (_configuration.rock)
		{
			battleThemes.AddPath(_modConfig.ModId, _modLoader.GetDirectoryForModId(_modConfig.ModId) + "/battle-themes/Stella_GillStudio");
		}
		var added = new Dictionary<string, int>
		{
			{"night",0},
			{"dayout1",0},
			{"social1",0},
			{"social2",0},
			{"dayin1",0},
			{"dayin2",0},
			{"final",0}
		};
		var collection = new Dictionary<string, Tuple<bool, string>>
		{
			//{"cue id",new Tuple<bool,string>(config value,category)}
			{"97",new Tuple<bool,string>(_configuration.colnight,"night")},
			{"2003",new Tuple<bool,string>(_configuration.midnight,"night")},
			{"2004",new Tuple<bool,string>(_configuration.femnight,"night")},
			{"25",new Tuple<bool,string>(_configuration.moon,"dayout1")},
			{"2005",new Tuple<bool,string>(_configuration.wayoflife,"dayout1")},
			{"50",new Tuple<bool,string>(_configuration.wantclose,"dayin1")},
			{"2006",new Tuple<bool,string>(_configuration.timeschool, "dayin1")},
			{"51",new Tuple<bool,string>(_configuration.seasons,"dayin2")},
			{"2009",new Tuple<bool,string>(_configuration.sun, "dayin2")},
			{"38",new Tuple<bool,string>(_configuration.joy,"social1")},
			{"43",new Tuple<bool,string>(_configuration.joy,"social2")},
			{"2007",new Tuple<bool,string>(_configuration.afterschool,"social1")},
			{"2008",new Tuple<bool,string>(_configuration.afterschool,"social2")},
			{"2015",new Tuple<bool,string>(_configuration.soulpk,"final")},
			{"29",new Tuple<bool, string>(_configuration.bmd,"final")}
		};
		foreach (KeyValuePair<string,Tuple<bool,string>> col in collection)
		{
			if (col.Value.Item1)
			{
				if (col.Value.Item2=="night")
				{
					if (added[col.Value.Item2] == 0)
					{
						night += col.Key;
						added[col.Value.Item2] = 1;
					}

					else
						night += "," + col.Key;
				}
				else if(col.Value.Item2=="dayout1")
				{
					if (added[col.Value.Item2] == 0)
					{
						dayoutside1 += col.Key;
						added[col.Value.Item2] = 1;
					}
					else
						dayoutside1 += "," + col.Key;
				}
				else if (col.Value.Item2 == "dayin1")
				{
					if (added[col.Value.Item2] == 0)
					{
						dayinside1 += col.Key;
						added[col.Value.Item2] = 1;
					}
					else
						dayinside1 += "," + col.Key;
				}
				else if( col.Value.Item2 == "dayin2")
				{
					if (added[col.Value.Item2] == 0)
					{
						dayinside2 += col.Key;
						added[col.Value.Item2] = 1;
					}
					else
						dayinside2 += "," + col.Key;
				}
				else if (col.Value.Item2 == "social1")
				{
					if (added[col.Value.Item2] == 0)
					{
						sociallink11 += col.Key;
						added[col.Value.Item2] = 1;
					}
					else
						sociallink11 += "," + col.Key;
				}
				else if (col.Value.Item2 == "social2")
				{
					if (added[col.Value.Item2] == 0)
					{
						sociallink12 += col.Key;
						added[col.Value.Item2] = 1;
					}
					else
						sociallink12 += "," + col.Key;
				}
				else if (col.Value.Item2=="final")
				{
					if (added[col.Value.Item2] == 0)
					{
						finalbattle += col.Key;
						added[col.Value.Item2] = 1;
					}
					else
						finalbattle += "," + col.Key;
				}
				else
				{
					_logger.WriteLineAsync("The Collection dictionary in mod.cs has been improperly configured, one of the specified categories DOES NOT exist.");
				}

			}
		}

		night += (added["night"]==0) ? "2004]" : "]";
		dayoutside1 += (added["dayout1"] == 0) ? "2005]" : "]";
		dayinside1 += (added["dayin1"] == 0) ? "2006]" : "]";
		dayinside2 += (added["dayin2"] == 0) ? "2009]" : "]";
		sociallink11 += (added["social1"] == 0) ? "2007]" : "]";
		sociallink12 += (added["social2"] == 0) ? "2008]" : "]";
		finalbattle += (added["final"] == 0) ? "2015]" : "]";

		//Writing the configuration File
		string[] lines = {night, "global_bgm[\"Color Your Night\"]:", "music = random_song(night1List)", "end", dayinside1, "global_bgm[\"Want to Be Close\"]:", "music = random_song(dayin1List)", "end", dayoutside1, "global_bgm[\"When The Moon's Reaching Out Stars\"]:", "music = random_song(dayout1List)", "end", sociallink11, "global_bgm[38]:", "music = random_song(social11List)","end",sociallink12,"global_bgm[43]:","music = random_song(social12List)","end",dayinside2, "global_bgm[51]:", "music = random_song(dayin2List)","end",finalbattle,"global_bgm[29]:","music=random_song(finalbattle)","end"};

		if (File.Exists(path + ".pme"))
		{
			File.Delete(path + ".pme");
		}
		using (StreamWriter outputFile = new StreamWriter(path))
		{
			foreach (string line in lines)
				outputFile.WriteLine(line);
		}
		File.Move(path, Path.ChangeExtension(path, ".pme"));
	}
	catch (Exception ex)
	{
		_context._utils.Log($"An error occured while trying to generate the music script: \"{ex.Message}\"", System.Drawing.Color.Red);
	}*/
//}