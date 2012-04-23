#ifndef __LINKS_PERSISTENT_MEMORY_MANAGER_H__
#define __LINKS_PERSISTENT_MEMORY_MANAGER_H__

#if defined(__cplusplus)
extern "C" {
#endif

// see http://stackoverflow.com/questions/538134/exporting-functions-from-a-dll-with-dllexport
#if defined(_WIN32)
#if defined(LINKS_DLL)
#define PREFIX_DLL __declspec(dllexport)
#else
#define PREFIX_DLL __declspec(dllimport)
#endif
// Linux,Unix
#else
#define PREFIX_DLL 
#endif


#if defined(_MSC_VER)
#elif defined(__GNUC__)
#endif

//void InitPersistentMemoryManager();
PREFIX_DLL void InitPersistentMemoryManager();
PREFIX_DLL int OpenStorageFile(char *filename);
PREFIX_DLL int CloseStorageFile();
PREFIX_DLL unsigned long EnlargeStorageFile();
PREFIX_DLL unsigned long ShrinkStorageFile();
PREFIX_DLL int SetStorageFileMemoryMapping();
PREFIX_DLL unsigned long ResetStorageFileMemoryMapping();
PREFIX_DLL Link* GetMappedLink(int index);
PREFIX_DLL void SetMappedLink(int index, Link* link);
PREFIX_DLL void ReadTest();
PREFIX_DLL void WriteTest();

Link* AllocateLink();
void FreeLink(Link* link);

PREFIX_DLL void WalkThroughAllLinks(func);
PREFIX_DLL int WalkThroughLinks(func);


#if defined(__cplusplus)
}
#endif

#endif
