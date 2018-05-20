# FullscreenLock
Provide fullscreen mouse boundaries for games that don't.

This is a program that locks the cursor to the primary monitor for games where the devs were too incompetent to do so themselves.

In certain games, for example CS:GO, GTA V in windowed fullscreen and Skyrim, the mouse will not be locked to the primary monitor.
This can cause a user to drag the cursor out of the program, click, suddenly minimize the game and have to switch back in.

## Why make this program?

The original(?) PrimaryLock by AKADEVIL does the job well, but it is a little rudimentary, in that it just locks the cursor as long as PrimaryLock is open. 

My improved version doesn't lock the cursor if you alt-tab out manually or if no fullscreen application is open, allowing much more seamless switching to music players etc.
This also lets you keep the application open while no game is running, so that you don't have to keep in mind to open the application every time you start the game.

All this is made possible by watching what window is focused. Any window both fullscreen and in focus will trigger the primary monitor lock.

# Installation

It's been made apparent from comments from some very nice people that it's not obvious from the README how to install the application. There's a green bar above, click the tab "Releases" and you'll be taken to the newest release available. Click download, put the .exe in an appropriate place, and run.


# Demo

Here's a demonstration of mouse movement when:
- A focused window becomes fullscreen
- A fullscreen window loses focus
- A fullscreen window regains focus
- A focused, fullscreen window regains window decorations.

https://streamable.com/pj91p
