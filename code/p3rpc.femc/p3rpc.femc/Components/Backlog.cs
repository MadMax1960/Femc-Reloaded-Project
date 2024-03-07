using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class Backlog : ModuleBase
    {
        private UICommon _uiCommon;

        public unsafe Backlog(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
    }
}
