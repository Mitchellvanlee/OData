//---------------------------------------------------------------------
// <copyright file="GroupByToken.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

#if ODATA_CLIENT
namespace Microsoft.OData.Client.ALinq.UriParser
#else
namespace Microsoft.OData.UriParser.Aggregation
#endif
{
    using System.Collections.Generic;
    using Microsoft.OData.UriParser;

    /// <summary>
    /// Query token representing a GroupBy token.
    /// </summary>
    public sealed class GroupByToken : ApplyTransformationToken
    {
        private readonly IEnumerable<EndPathToken> properties;

        private readonly ApplyTransformationToken child;

        private readonly AggregateToken aggregateToken;

        /// <summary>
        /// Create a GroupByToken.
        /// </summary>
        /// <param name="properties">The list of group by properties.</param>
        /// <param name="child">The child of this token.</param>
        public GroupByToken(IEnumerable<EndPathToken> properties, ApplyTransformationToken child)
        {
            ExceptionUtils.CheckArgumentNotNull(properties, "properties");

            this.properties = properties;
            this.child = child;
        }

        /// <summary>
        /// Create a GroupByToken.
        /// </summary>
        /// <param name="properties">The list of group by properties.</param>
        /// <param name="child">The child of this token.</param>
        /// <param name="aggregate">Aggregation token within the groupbytoken.</param>
        public GroupByToken(IEnumerable<EndPathToken> properties, ApplyTransformationToken child, AggregateToken aggregate)
        {
            ExceptionUtils.CheckArgumentNotNull(properties, "properties");

            this.properties = properties;
            this.child = child;
            this.aggregateToken = aggregate;
        }

        /// <summary>
        /// Gets the kind of this token.
        /// </summary>
        public override QueryTokenKind Kind
        {
            get { return QueryTokenKind.AggregateGroupBy; }
        }

        /// <summary>
        /// Gets the list of group by properties.
        /// </summary>
        public IEnumerable<EndPathToken> Properties
        {
            get { return this.properties; }
        }

        /// <summary>
        /// Gets the child of this token.
        /// </summary>
        public ApplyTransformationToken Child
        {
            get { return this.child; }
        }

        /// <summary>
        /// Gets the aggregatetoken within this token.
        /// </summary>
        public AggregateToken AggregateToken
        {
            get { return this.aggregateToken; }
        }

        /// <summary>
        /// Accept a <see cref="ISyntacticTreeVisitor{T}"/> to walk a tree of <see cref="QueryToken"/>s.
        /// </summary>
        /// <typeparam name="T">Type that the visitor will return after visiting this token.</typeparam>
        /// <param name="visitor">An implementation of the visitor interface.</param>
        /// <returns>An object whose type is determined by the type parameter of the visitor.</returns>
        public override T Accept<T>(ISyntacticTreeVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
