using p3rpc.commonmodutils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class MissingPerson : ModuleAsmInlineColorEdit<FemcContext>
    {
        public unsafe MissingPerson(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            // TODO
        }
        public override void Register() { }
    }
}
