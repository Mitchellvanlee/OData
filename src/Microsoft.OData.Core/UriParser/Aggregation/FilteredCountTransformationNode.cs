using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.OData.UriParser.Aggregation
{
    class FilteredCountTransformationNode : TransformationNode
    {
        private readonly FilterClause filterClause;

        /// <summary>
        /// Create a FilterTransformationNode.
        /// </summary>
        /// <param name="filterClause">A <see cref="FilterClause"/> representing the metadata bound filter expression.</param>
        public FilteredCountTransformationNode(FilterClause filterClause)
        {
            ExceptionUtils.CheckArgumentNotNull(filterClause, "filterClause");

            this.filterClause = filterClause;
        }

        /// <summary>
        /// Gets the <see cref="FilterClause"/> representing the metadata bound filter expression.
        /// </summary>
        public FilterClause FilterClause
        {
            get
            {
                return this.filterClause;
            }
        }

        /// <summary>
        /// Gets the kind of the transformation node.
        /// </summary>
        public override TransformationNodeKind Kind
        {
            get
            {
                return TransformationNodeKind.Filter;
            }
        }
    }
}

