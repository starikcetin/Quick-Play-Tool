Quick Play Tool for Unity3D Game Engine
---

An editor window for Unity3D game engine that lets you quickly list and play *all* scenes, as well as setting up a seperated "quick play scene". You can also set up *presets* of scenes that can be loaded together additively.

Developed and tested on 2017.3.1f1.

Unity Forum Thread: https://forum.unity.com/threads/open-source-quick-play-tool.526158/

Installation (with UPM and UpmGitExtension, recommended)
---

Install this package: https://github.com/mob-sakai/UpmGitExtension

Install Quick Play Tool using UpmGitExtension.


Installation (with UPM, without UpmGitExtension)
---

Add this as a dependency in your `packages.json` file:

```
"com.starikcetin.quickplaytool": "https://github.com/starikcetin/Quick-Play-Tool.git#1.0.0-upm",
```

Replace `1.0.0-upm` with the tag of the version that you want to install, or update using the Package Manager window.


Installation (without UPM)
---

Put the _Assets/QuickPlayTool_ folder in anywhere under _Assets_ folder.

You can also submodule this repository if you are using git.
  Here is a comprehensive tutorial from prime31 about submodules, symlinks and Unity: http://prime31.github.io/A-Method-for-Working-with-Shared-Code-with-Unity-and-Git/

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

License
---
MIT license. Refer to the [LICENSE](https://github.com/starikcetin/Quick-Play-Tool/blob/master/LICENSE) file.

Copyright (c) 2018 S. Tarık Çetin
