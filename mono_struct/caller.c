#include <stdio.h>

#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/debug-helpers.h>

void Die (char * error)
{
	printf ("%s\n", error);
	exit (1);
}

void DoWorking (MonoClass *my_class, MonoObject* instance)
{
	MonoMethodDesc* desc = mono_method_desc_new("Test.Lib:get_ValueHolderArr()", 1);
	MonoMethod* method = mono_method_desc_search_in_class(desc, my_class);
	mono_method_desc_free(desc);

	MonoObject* exception = NULL;
	MonoObject* result = mono_runtime_invoke (method, instance, NULL, &exception);
	if (exception)
		Die ("Exception");
	
	MonoArray* resarr = (MonoArray *) result;
	if (!resarr)
		Die ("No Result");

	int resarrlength = mono_array_length (resarr);

	for (int residx = 0; residx < resarrlength; residx++) {
		MonoObject* val = mono_array_get (resarr, MonoObject *, residx);
		MonoClass *c = mono_object_get_class (val);
		printf ("Found %s", mono_class_get_name (c));
	}
}

void DoFailing (MonoClass *my_class, MonoObject* instance)
{
	MonoMethodDesc* desc = mono_method_desc_new("Test.Lib:get_ValueTypeArr()", 1);
	MonoMethod* method = mono_method_desc_search_in_class(desc, my_class);
	mono_method_desc_free(desc);

	MonoObject* exception = NULL;
	MonoObject* result = mono_runtime_invoke (method, instance, NULL, &exception);
	if (exception)
		Die ("Exception");
	
	MonoArray* resarr = (MonoArray *) result;
	if (!resarr)
		Die ("No Result");

	int resarrlength = mono_array_length (resarr);

	for (int residx = 0; residx < resarrlength; residx++) {
		MonoObject* val = mono_array_get (resarr, MonoObject *, residx);
		MonoClass * c = mono_object_get_class (val);
		printf ("What? Found %s", mono_class_get_name (c));
	}
}

int main ()
{
	MonoDomain *domain = mono_jit_init ("Test");

	MonoAssembly *assembly = mono_domain_assembly_open (domain, "lib.dll");
	if (!assembly)
		Die ("Unable to load library");

	MonoImage *image = mono_assembly_get_image (assembly);
	MonoClass *my_class = mono_class_from_name (image, "Test", "Lib");
	if (!assembly)
		Die ("Unable to find class");

	MonoObject *my_class_instance = mono_object_new (domain, my_class);
	mono_runtime_object_init (my_class_instance);

	printf ("Classes work\n");
	DoWorking (my_class, my_class_instance);

	printf ("Structs do not. About to die...\n");
	// Show our text before we crash
	fflush(stdout);

	DoFailing (my_class, my_class_instance);

	mono_jit_cleanup (domain);

	printf ("Done!\n");
	return 0;
}
