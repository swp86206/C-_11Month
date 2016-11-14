#include <Windows.h>

__declspec(dllexport) int WINAPI Add1(int x)
{
  return x + 1;
}
