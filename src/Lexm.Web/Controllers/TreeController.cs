
using System.Web.Http;
using Lexm.Core;
using Lexm.Core.Extensions;

namespace Lexm.Web.Controllers
{
    public class TreeController : ApiController
    {
        // GET api/tree/James
        public SyntaxNode Get(string query)
        {
            return query.ToSyntaxTree();
        }
    }
}
