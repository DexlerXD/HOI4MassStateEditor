# HOI4MassStateEditor
This is a very simple tool that lets you edit many hoi4 state files with ease!
The main purpose of this program is to quickly add and remove, if nedeed, some entries in state files (like `add_state_core` and `owner`).
I've created it to solve my modding problems, as I had needed to edit many files, deleting the same lines, which made this process very long and boring, so I hope that now everyone can do this easier and faster.
## Features
This tool is currently capable of:
- removing `owner = TAG` from multiple files
- removing `add_core_of = TAG` from multiple files
- adding `owner = TAG` to multiple files
- adding `add_core_of = TAG` to multiple files

I also want to add more options to these features and some new features too (like mass editing claims).
Now it's only a console application, but I'll probably remake it with Windows forms.
## Usage
### Prerequisites
- .NET 5.0 or higher
### Getting started
1. Download the latest release from the [releases](https://github.com/DexlerXD/HOI4MassStateEditor/releases) tab.
2. Double click on the downloaded executable (`HOI4MassStateEditor.exe`).
3. Follow the instructions:
    - Type an amount of tags that you want to add
    - Type all the tags that you want to add
    - Decide, whether you want to delete other tags before adding yours
    - Insert a path to the folder with state files
4. PROFIT!

You've done! Currently, program will break files with brackets coming after the `history = ` definition. I'm going to fix this soon, I'm just a bit lazy...

> Like here\
![](https://user-images.githubusercontent.com/69513582/222714720-b27df91d-4c38-4fdb-be79-bf0526aa4a59.png) 
