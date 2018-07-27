nuget::
	$(Q) - dotnet tool uninstall -g dotnet-tool-path
	$(Q) dotnet pack -c release -o ./nupkg
	$(Q) dotnet tool install --add-source nupkg -g dotnet-tool-path

test::
	pathtest

clean::
	$(Q) - dotnet tool uninstall -g dotnet-tool-path
	dotnet clean
