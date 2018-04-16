Quick Play Tool for Unity3D Game Engine
---

![license](https://img.shields.io/github/license/mashape/apistatus.svg)
[![Website](https://img.shields.io/website-up-down-green-red/http/shields.io.svg?label=forum%20thread)](https://forum.unity.com/threads/free-open-source-quick-play-tool-quickly-play-any-scene-from-anywhere.526158/)

An editor window for Unity3D game engine that lets you quickly list and play *all* scenes, as well as setting up a seperated "quick play scene". You can also set up *presets* of scenes that can be loaded together additively.

Developed and tested on 2017.3.1f1.

Unity Forum Thread: https://forum.unity.com/threads/open-source-quick-play-tool.526158/

Installation
---
Put the QuickPlayTool folder anywhere in under _Assets_ folder (preferebly under an _Editor_ folder).

You can also submodule this repository if you are using git.

Launch the window from "Window > Quick Play Tool"

Features
---

- Scans the entire Assets folder and subfolders for scene files. Then lists these scenes with a play button for each. You can set any of these scenes as the "quick play scene". You can play any scene even if the editor is currently in play mode.
- Prompts for save before switching scenes and confirmation before restarting play mode.
- Provides an option to automatically adjust its layout depending on the width, so all content remains visible and interactable no matter how narrow the window is.
- You can play a scene together with the active scenes _(play additive)_; or you can play it alone, closing all other active scenes _(play)_.
- Presets: Groups of scenes that can be loaded together additively, optionally closing the current active scenes beforehand.

For more information visit [the wiki](https://github.com/starikcetin/Quick-Play-Tool/wiki).

Screenshots
---

![Wide Screenshot](https://raw.githubusercontent.com/starikcetin/Quick-Play-Tool/repository_resources/screenshots/Wide.PNG)

![Normal Screenshot](https://raw.githubusercontent.com/starikcetin/Quick-Play-Tool/repository_resources/screenshots/Normal.PNG)

![Narrow Screenshot](https://raw.githubusercontent.com/starikcetin/Quick-Play-Tool/repository_resources/screenshots/Narrow.PNG)

![Already In Play Mode Screenshot](https://raw.githubusercontent.com/starikcetin/Quick-Play-Tool/repository_resources/screenshots/AlreadyInPlayMode.PNG)

![Remove Preset Screenshot](https://raw.githubusercontent.com/starikcetin/Quick-Play-Tool/repository_resources/screenshots/RemovePreset.PNG)

Licence
---
MIT license. Refer to the [LICENCE](https://github.com/starikcetin/Quick-Play-Tool/blob/master/LICENSE) file.

Copyright (c) 2018 S. Tarık Çetin
