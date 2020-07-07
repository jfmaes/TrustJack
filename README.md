# TrustJack
Yet another PoC for https://www.wietzebeukema.nl/blog/hijacking-dlls-in-windows

To be used with a cmd that does whatever the F you want, for a dll that pops cmd, Please Check my cmd-dll repo.
check the list in wietze's site to check how you should call your dll.

will automatically create c:\Windows \System32 and drop your dll and chosen binary in there, followed by execution.
Clean up after yourself by running trustjack again with the -c flag. 


**You migh be missing fody 2.0, run nuget package restore to fix (right click Solution 'TrustJacker' and select 'restore NuGet packages')** 

```
 _______             _       _            _
|__   __|           | |     | |          | |
   | |_ __ _   _ ___| |_    | | __ _  ___| | __
   | | '__| | | / __| __|   | |/ _` |/ __| |/ /
   | | |  | |_| \__ \ || |__| | (_| | (__|   <
   |_|_|   \__,_|___/\__\____/ \__,_|\___|_|\_\


 V1.0.0 by https://twitter.com/Jean_Maes_1994
Usage:
      --dllpath=VALUE        Path to the dll on the computer
      --binary=VALUE         The binary name to pop the shell
  -c, --clean, --cleanup     Cleanup the fake folder and it's contents
  -h, -?, --help             show this help menu.

```
![Alt Text](https://redteamer.tips/wp-content/uploads/2020/07/TrustJack.gif)
