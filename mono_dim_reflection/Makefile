CSC=/Library/Frameworks/Mono.framework/Commands/csc-dim
COMPILE_ARGS=/nologo /langversion:7.1
all:: lib.dll main.exe

run::
	mono main.exe

clean::
	rm main.exe
	rm lib.dll

lib.dll: Makefile lib.cs
	$(CSC) -t:library lib.cs $(COMPILE_ARGS)

main.exe: Makefile main.cs lib.dll
	$(CSC) main.cs -r:lib.dll $(COMPILE_ARGS)
