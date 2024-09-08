using FabricCli.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricCli.Service
{
    public interface IFabricService
    {
        IEnumerable<FabricWorkspace> GetWorkspaces();
    }
}
