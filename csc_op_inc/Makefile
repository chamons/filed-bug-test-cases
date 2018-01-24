all::
	mcs Prim.cs -unsafe -t:library -out:mcs.dll
	monodis mcs.dll > mcs.dis
	csc Prim.cs -unsafe -t:library -out:csc.dll
	monodis csc.dll > csc.dis

clean::
	rm -f *.dll
	rm -f *.dis
