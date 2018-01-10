using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OData.Edm;

namespace Microsoft.OData.UriParser.SemanticAst
{
    class FilteredCountPropertyNode : SingleValueNode
    {
        /// <summary>Constructor.</summary>
        public FilteredCountPropertyNode()
        {
        }

        /// <summary>Kind of the single value node.</summary>
        public override QueryNodeKind Kind
        {
            get
            {
                return QueryNodeKind.FilteredCount;
            }
        }

        /// <summary>Type returned by the $count virtual property.</summary>
        public override IEdmTypeReference TypeReference
        {
            get
            {
                // Issue #758: CountDistinct and $Count should return type Edm.Decimal with Scale="0" and sufficient Precision.
                return EdmCoreModel.Instance.GetPrimitive(EdmPrimitiveTypeKind.Int64, false);
            }
        }
    }
}
