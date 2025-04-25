#!/usr/bin/bash
mcs comicbuddyabout.cs comicstrips.cs main.cs -r:gtk-sharp.dll -r:glib-sharp.dll -r:System.Drawing -o ComicBuddy.exe
