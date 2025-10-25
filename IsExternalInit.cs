// Today I discovered that you can use (most) new C# language features on older dotNET versions by simply changing the LangVersion tag in csproj...

using System.ComponentModel;

namespace System.Runtime.CompilerServices;

[EditorBrowsable(EditorBrowsableState.Never)]
class IsExternalInit{}