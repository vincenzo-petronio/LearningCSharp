using BlazorWasm.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm.Shared
{
    public partial class Photos
    {
        [Parameter]
        public PhotoDto PhotoDto { get; set; }
    }
}
