using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hack2025_LegalAlchemists
{
    public class AddDaryNotePlugin
    {

        [KernelFunction("archive_data")]
        [Description("Saves data to a file on your computer.")]
        public async Task WriteData(Kernel kernel, string fileName, string data)
        {
            await File.WriteAllTextAsync($@"C:\Users\Lushan.Jayanath\source\repos\WorkflowKernel\Hack2025-LegalAlchemists\{fileName}.txt", data);
        }
    }
}
