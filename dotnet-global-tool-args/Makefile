nuget::
	$(Q) - dotnet tool uninstall -g dotnet-global-tool-args
	$(Q) dotnet pack -c release -o ./nupkg
	$(Q) dotnet tool install --add-source nupkg -g dotnet-global-tool-args

clean::
	$(Q) - dotnet tool uninstall -g dotnet-global-tool-args
	dotnet clean
