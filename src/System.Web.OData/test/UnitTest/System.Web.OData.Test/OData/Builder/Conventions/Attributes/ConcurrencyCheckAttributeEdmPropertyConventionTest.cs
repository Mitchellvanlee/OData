﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.OData.Formatter;
using Microsoft.OData.Edm;
using Microsoft.TestCommon;
using Moq;

namespace System.Web.OData.Builder.Conventions.Attributes
{
    public class ConcurrencyCheckAttributeEdmPropertyConventionTest
    {
        [Fact]
        public void Empty_Ctor_DoesnotThrow()
        {
            Assert.DoesNotThrow(() => new ConcurrencyCheckAttributeEdmPropertyConvention());
        }

        [Fact]
        public void Apply_SetsConcurrencyTokenProperty()
        {
            // Arrange
            Mock<PropertyInfo> property = new Mock<PropertyInfo>();
            property.Setup(p => p.Name).Returns("Property");
            property.Setup(p => p.PropertyType).Returns(typeof(string));
            property.Setup(p => p.GetCustomAttributes(It.IsAny<bool>())).Returns(new[] { new ConcurrencyCheckAttribute() });

            Mock<EntityTypeConfiguration> entityType = new Mock<EntityTypeConfiguration>();
            Mock<PrimitivePropertyConfiguration> primitiveProperty = new Mock<PrimitivePropertyConfiguration>(property.Object, entityType.Object);
            primitiveProperty.Object.AddedExplicitly = false;

            // Act
            new ConcurrencyCheckAttributeEdmPropertyConvention().Apply(primitiveProperty.Object, entityType.Object, new ODataConventionModelBuilder());

            // Assert
            Assert.True(primitiveProperty.Object.ConcurrencyToken);
        }

        [Fact]
        public void ConcurrencyCheckAttributeEdmPropertyConvention_ConfiguresETagPropertyAsETag()
        {
            // Arrange
            MockType type =
                new MockType("Entity")
                .Property(typeof(int), "ID")
                .Property(typeof(int?), "Count", new ConcurrencyCheckAttribute());

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var entityType = builder.AddEntityType(type);
            builder.AddEntitySet("EntitySet", entityType);

            // Act
            IEdmModel model = builder.GetEdmModel();

            // Assert
            IEdmEntityType entity = model.AssertHasEntityType(type);
            IEdmStructuralProperty property = entity.AssertHasPrimitiveProperty(
                model,
                "Count",
                EdmPrimitiveTypeKind.Int32,
                isNullable: true);
            IEdmEntitySet entitySet = model.EntityContainer.FindEntitySet("EntitySet");
            Assert.NotNull(entitySet);

            IEnumerable<IEdmStructuralProperty> currencyProperties = model.GetConcurrencyProperties(entitySet);
            IEdmStructuralProperty currencyProperty = Assert.Single(currencyProperties);
            Assert.Same(property, currencyProperty);
        }

        [Fact]
        public void ConcurrencyCheckAttributeEdmPropertyConvention_DoesnotOverwriteExistingConfiguration()
        {
            // Arrange
            MockType type =
                new MockType("Entity")
                .Property(typeof(int), "ID")
                .Property(typeof(int), "Count", new ConcurrencyCheckAttribute());

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var entityType = builder.AddEntityType(type);
            entityType.AddProperty(type.GetProperty("Count")).IsOptional();
            builder.AddEntitySet("EntitySet", entityType);

            // Act
            IEdmModel model = builder.GetEdmModel();

            // Assert
            IEdmEntityType entity = model.AssertHasEntityType(type);
            IEdmStructuralProperty property = entity.AssertHasPrimitiveProperty(
                model,
                "Count",
                EdmPrimitiveTypeKind.Int32,
                isNullable: true);

            IEdmEntitySet entitySet = model.EntityContainer.FindEntitySet("EntitySet");
            Assert.NotNull(entitySet);

            IEnumerable<IEdmStructuralProperty> currencyProperties = model.GetConcurrencyProperties(entitySet);
            IEdmStructuralProperty currencyProperty = Assert.Single(currencyProperties);
            Assert.Same(property, currencyProperty);
        }
    }
}
