### LrcParser mod by appleneko2001
An lyric file parser (.lrc parser) for C# project.
This is modded version with slightly changes framework of working.
for original ver. ====>> https://github.com/OpportunityLiu/LrcParser

##### Changes: 
* Use TimeSpan type instead of DateTime on timestamp property
* UnitTest slightly changed to support this library

##### Requirements:
This modded library uses .Net Standard 2.0, so your project should targeting .Net Framework to 4.6.1 at least
for more information about minimum requirement of standard: https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support

Or if you really want to use more older framework version, you can try to rebuild this library and targeting to .Net Standard 1.1 (or create new library project and copy-paste all codes. UnitTest are optional component).