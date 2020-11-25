# Integrate with new tools

As you might know, we've broken Zebble.exe into a set of tiny dotnet global tools, and we hope this could help us increase our development speed, and allows up to bring more features easily in future. 
 
## Migrating our existing Zebble projects

If we use `zebble-build` CLI to create a new project, it will automatically takes care of everything. But for know, we imagine that we want to upgrade our existing project. So, here are the steps we need to follow:

1- Download `[$SolutionName$.targets](https://github.com/Geeksltd/Zebble.Template/blob/main/Template/%24SolutionName%24.targets)` file and add it into the root of your solution, beside you project's .sln file. Use should rename the file name to something meaningful.

2- In Visual Studio, unload the UWP project, right click on it, then select Edit Project File. If scroll down to the end of the file, you'll see a build target similiar to the below:

`xml
<Target Name="zebbleExe generate" BeforeTargets="BeforeBuild">
   <Exec Command="&quot;$(ProjectDir)..\Android\Zebble.exe&quot; generate auto"/> 
</Target>
<Target Name="Update XML Schema" AfterTargets="AfterBuild">
    <Exec Command="&quot;$(ProjectDir)..\Android\Zebble&quot; update-schema auto" />
</Target>
<Target Name="zebbleExe watch-css" AfterTargets="AfterBuild">
  <Exec Command="start &quot;&quot; &quot;$(ProjectDir)..\Android\Zebble&quot; watch-css auto"/> 
</Target> 
`

Please remove all the three targets, and then paste the following Import tag:

`xml
<Import Project="$(SolutionDir)\$SolutionName$.targets"/>
`

Please note that you should replace `$SolutionName$` with the name you chosen for the targets file in previous step.

3- You need to repeat step 2 for the remaining platforms, Android and iOS, if you have any of them.

