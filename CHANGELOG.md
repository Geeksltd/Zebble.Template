# Integrate with new tools

As you might know, we've broken the `Zebble.exe` into a set of tiny dotnet global tools, and we hope this could help us increase our development speed, and allows us to provide more features easily in the future.

## Migrating our existing Zebble projects

If we use `zebble-build` CLI to create a new project, it will automatically take care of everything. But for now, we imagine that we want to upgrade an existing project. So, here are the steps we need to follow:

1- Download `Zebble.targets` file from [here](https://github.com/Geeksltd/Zebble.Template/blob/main/Template/Zebble.targets) and add it to the root of your solution, besides your project's `.sln` file.

2- In Visual Studio, unload the UWP project, right-click on it, then select `Edit Project File`. If scroll down to the end of the file, you'll see several `Target` tags similiar to the below:

```xml
<Target Name="zebbleExe generate" BeforeTargets="BeforeBuild">
   <Exec Command="&quot;$(ProjectDir)..\Android\Zebble.exe&quot; generate auto"/> 
</Target>
<Target Name="Update XML Schema" AfterTargets="AfterBuild">
    <Exec Command="&quot;$(ProjectDir)..\Android\Zebble&quot; update-schema auto" />
</Target>
<Target Name="zebbleExe watch-css" AfterTargets="AfterBuild">
  <Exec Command="start &quot;&quot; &quot;$(ProjectDir)..\Android\Zebble&quot; watch-css auto"/> 
</Target> 
```

Please remove all three `Target` tags, and then paste the following `Import` tag:

```xml
<Import Project="$(SolutionDir)\Zebble.targets"/>
```

3- You need to repeat step 2 for the remaining platforms, Android and iOS if you have any of them.
