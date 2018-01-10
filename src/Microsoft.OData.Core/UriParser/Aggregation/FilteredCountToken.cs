using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.OData.UriParser.Aggregation
{
    class FilteredCountToken : ApplyTransformationToken
    {
        public override QueryTokenKind Kind { get; }
        public override T Accept<T>(ISyntacticTreeVisitor<T> visitor)
        {
            throw new NotImplementedException();
        }
    }
}
