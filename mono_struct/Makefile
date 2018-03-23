run::	lib.dll caller
	./caller

caller: caller.c
	clang -g caller.c `/Library/Frameworks/Mono.framework/Commands/pkg-config --cflags --libs mono-2 glib-2.0` -o caller

lib.dll: lib.cs
	csc lib.cs -t:library

clean::
	rm lib.dll caller
	rm -r caller.dSYM/
