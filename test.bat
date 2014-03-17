SET FILENAME=sonar-project.properties
echo sonar.projectKey=testu> %FILENAME%
echo sonar.projectVersion=0.1>> %FILENAME%
echo sonar.projectName=testu>> %FILENAME%
echo sources=.>> %FILENAME%
echo sonar.language=cs>> %FILENAME%
echo #Core C# Settings>> %FILENAME%
echo sonar.dotnet.visualstudio.solution.file=Serrow-csharp.sln>> %FILENAME%
sonar-runner
 
