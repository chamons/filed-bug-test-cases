VERSION = 0.1.0
NUGET = sdk-project-prototype.$(VERSION).nupkg
NUGET_CACHE = ~/nuget/$(NUGET)

test-mac:: $(NUGET_CACHE)
	nuget restore sample.csproj
	msbuild sample.csproj

$(NUGET_CACHE): nuget/bin/$(NUGET)
	dotnet nuget locals all --clear
	cp nuget/bin/$(NUGET) $(NUGET_CACHE)

nuget/bin/$(NUGET): nuget/Sdk.Project.Prototype.nuspec nuget/Sdk/Sdk.props nuget/Sdk/Sdk.targets
	nuget pack -OutputDirectory nuget/bin nuget/Sdk.Project.Prototype.nuspec

