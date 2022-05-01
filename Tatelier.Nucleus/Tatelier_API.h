#pragma once

#define DllExport __declspec(dllexport)

extern "C" {
	DllExport void Start();

	DllExport void Run();

	DllExport void Finish();
}