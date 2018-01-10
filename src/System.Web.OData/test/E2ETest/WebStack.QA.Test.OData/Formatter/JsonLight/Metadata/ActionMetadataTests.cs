﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using Newtonsoft.Json.Linq;
using Nuwa;
using WebStack.QA.Common.XUnit;
using WebStack.QA.Test.OData.Common;
using WebStack.QA.Test.OData.Formatter.JsonLight.Metadata.Model;
using Xunit.Extensions;

namespace WebStack.QA.Test.OData.Formatter.JsonLight.Metadata
{
    [NuwaFramework]
    [NuwaHttpClientConfiguration(MessageLog = false)]
    [NuwaTrace(typeof(PlaceholderTraceWriter))]
    public class ActionMetadataTests
    {
        [NuwaBaseAddress]
        public string BaseAddress { get; set; }

        [NuwaHttpClient]
        public HttpClient Client { get; set; }

        [NuwaConfiguration]
        public static void UpdateConfiguration(HttpConfiguration configuration)
        {
            configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            configuration.MapODataServiceRoute("Actions", "Actions", GetActionsModel(configuration), new DefaultODataPathHandler(), ODataRoutingConventions.CreateDefault());
            configuration.AddODataQueryFilter();
        }

        private static IEdmModel GetActionsModel(HttpConfiguration config)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder(config);
            var baseEntitySet = builder.EntitySet<BaseEntity>("BaseEntity");
            var alwaysAvailableActionBaseType = baseEntitySet.EntityType.Action("AlwaysAvailableActionBaseType");
            var transientActionBaseType = baseEntitySet.EntityType.Action("TransientActionBaseType");

            Func<ResourceContext, Uri> transientActionBaseTypeLinkFactory = eic =>
            {
                IEdmEntityType baseType = eic.EdmModel.FindType(typeof(BaseEntity).FullName) as IEdmEntityType;
                object id;
                eic.EdmObject.TryGetPropertyValue("Id", out id);
                if (!eic.StructuredType.IsOrInheritsFrom(baseType) || (int)id % 2 == 1)
                {
                    return null;
                }
                else
                {
                    // find the action
                    var action = eic.EdmModel.SchemaElements
                       .Where(elem => elem.Name == "TransientActionBaseType")
                       .Cast<EdmAction>()
                       .FirstOrDefault();

                    var segments = new List<ODataPathSegment>();
                    segments.Add(new EntitySetSegment(eic.NavigationSource as IEdmEntitySet));
                    segments.Add(new KeySegment(new[] { new KeyValuePair<string, object>("Id", id) }, eic.StructuredType as IEdmEntityType, null));
                    var pathHandler = eic.Request.GetPathHandler();
                    string link = eic.Url.CreateODataLink("Actions", pathHandler, segments);
                    link += "/" + action.FullName();
                    return new Uri(link);
                }
            };

            transientActionBaseType.HasActionLink(transientActionBaseTypeLinkFactory, true);
            var derivedEntityType = builder.EntityType<DerivedEntity>().DerivesFrom<BaseEntity>();
            var alwaysAvailableActionDerivedType = derivedEntityType.Action("AlwaysAvailableActionDerivedType");
            var transientActionDerivedType = derivedEntityType.Action("TransientActionDerivedType");
            Func<ResourceContext, Uri> transientActionDerivedTypeLinkFactory = eic =>
            {
                IEdmEntityType derivedType = eic.EdmModel.FindType(typeof(DerivedEntity).FullName) as IEdmEntityType;
                object id;
                eic.EdmObject.TryGetPropertyValue("Id", out id);
                if (!eic.StructuredType.IsOrInheritsFrom(derivedType) || (int)id % 2 == 1)
                {
                    return null;
                }
                else
                {
                    // find the action
                    var action = eic.EdmModel.SchemaElements
                       .Where(elem => elem.Name == "TransientActionDerivedType")
                       .Cast<EdmAction>()
                       .FirstOrDefault();

                    var segments = new List<ODataPathSegment>();
                    segments.Add(new EntitySetSegment(eic.NavigationSource as IEdmEntitySet));
                    segments.Add(new KeySegment(new[] {new KeyValuePair<string, object>("Id", id)}, eic.StructuredType as IEdmEntityType, null));
                    segments.Add(new TypeSegment(derivedType, null));
                    // bug 1985: Make the internal constructor as public in BoundActionPathSegment
                    //segments.Add(new BoundActionPathSegment(action));
                    var pathHandler = eic.Request.GetPathHandler();
                    string link = eic.Url.CreateODataLink("Actions", pathHandler, segments);
                    link += "/" + action.FullName();
                    return new Uri(link);
                }
            };
            transientActionDerivedType.HasActionLink(transientActionDerivedTypeLinkFactory, true);
            return builder.GetEdmModel();
        }

        public static TheoryDataSet<string> AllAcceptHeaders
        {
            get
            {
                return ODataAcceptHeaderTestSet.GetInstance().GetAllAcceptHeaders();
            }
        }

        [Theory]
        [PropertyData("AllAcceptHeaders")]
        public void AlwaysAvailableActionsGetAdvertisedOnFullMetadataOnly(string acceptHeader)
        {
            //Arrange
            string requestUrl = BaseAddress.ToLowerInvariant() + "/Actions/BaseEntity(1)/";
            string expectedTargetUrl = BaseAddress.ToLowerInvariant() + "/Actions/BaseEntity(1)/Default.AlwaysAvailableActionBaseType";
            string expectedAlwaysAvailableActionName = "AlwaysAvailableActionBaseType";
            string expectedAlwaysAvailableActionContainer = "#Default." + expectedAlwaysAvailableActionName;
            string expectedContextUrl = BaseAddress.ToLowerInvariant() + "/Actions/$metadata#BaseEntity/$entity";
            JObject container;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.SetAcceptHeader(acceptHeader);

            //Act
            HttpResponseMessage response = Client.SendAsync(request).Result;
            JObject result = response.Content.ReadAsAsync<JObject>().Result;

            //Assert
            if (acceptHeader.Contains("odata.metadata=full"))
            {
                // full metadata
                JsonAssert.ContainsProperty(expectedAlwaysAvailableActionContainer, result);
                container = (JObject)result[expectedAlwaysAvailableActionContainer];
                JsonAssert.PropertyEquals(expectedTargetUrl, "target", container);
                JsonAssert.PropertyEquals(expectedAlwaysAvailableActionName, "title", container);
                JsonAssert.PropertyEquals(expectedContextUrl, "@odata.context", result);
                JsonAssert.PropertyEquals("#WebStack.QA.Test.OData.Formatter.JsonLight.Metadata.Model.BaseEntity", "@odata.type", result);
            }
            else if (acceptHeader.Contains("odata.metadata=none"))
            {
                // none metadata
                JsonAssert.DoesNotContainProperty(expectedContextUrl, result);
                JsonAssert.PropertyEquals("1", "Id", result);
            }
            else
            {
                // minimal metadata & application/json
                JsonAssert.PropertyEquals(expectedContextUrl, "@odata.context", result);
                JsonAssert.DoesNotContainProperty(expectedAlwaysAvailableActionContainer, result);
            }
        }

        [Theory]
        [PropertyData("AllAcceptHeaders")]
        public void TransientActionsDontGetAdvertisedWhenTheyArentAvailable(string acceptHeader)
        {
            //Arrange
            string requestUrl = BaseAddress.ToLowerInvariant() + "/Actions/BaseEntity(1)/";
            string expectedTransientActionName = "TransientActionBaseType";
            string expectedTransientActionContainer = "#Default." + expectedTransientActionName;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.SetAcceptHeader(acceptHeader);

            //Act
            HttpResponseMessage response = Client.SendAsync(request).Result;
            JObject result = response.Content.ReadAsAsync<JObject>().Result;

            //Assert
            if (acceptHeader.Contains("odata.metadata=full"))
            {
                JsonAssert.ContainsProperty(expectedTransientActionContainer, result);
            }
            else
            {
                JsonAssert.DoesNotContainProperty(expectedTransientActionContainer, result);
            }
        }

        [Theory]
        [PropertyData("AllAcceptHeaders")]
        public async Task TransientActionsGetAdvertisedWhenTheyAreAvailable(string acceptHeader)
        {
            //Arrange
            string actionName = "TransientActionBaseType";
            string qualifiedActionName = "Default." + actionName;
            string containerName = "#" + qualifiedActionName;
            string expectedTargetUrl = BaseAddress + "/Actions/BaseEntity(2)/" + qualifiedActionName;
            string expectedContextUrl = BaseAddress + "/Actions/$metadata#BaseEntity/$entity";

            //Act
            var requestUrl = BaseAddress + "/Actions/BaseEntity(2)/";
            var response = await Client.GetWithAcceptAsync(requestUrl, acceptHeader);
            var result = await response.Content.ReadAsAsync<JObject>();

            // Assert
            if (acceptHeader.Contains("odata.metadata=full"))
            {
                // full metadata
                JObject container = (JObject)result[containerName];

                var actualTargetUrl = container["target"].ToString();
                ODataUrlAssert.UrlEquals(expectedTargetUrl, actualTargetUrl, BaseAddress);

                JsonAssert.PropertyEquals(actionName, "title", container);

                var actualContextUrl = result["@odata.context"].ToString();
                ODataUrlAssert.UrlEquals(expectedContextUrl, actualContextUrl, BaseAddress);

                JsonAssert.PropertyEquals("#WebStack.QA.Test.OData.Formatter.JsonLight.Metadata.Model.BaseEntity", "@odata.type", result);
            }
            else if (acceptHeader.Contains("odata.metadata=none"))
            {
                // none metadta
                JsonAssert.DoesNotContainProperty("@odata.context", result);
                JsonAssert.DoesNotContainProperty("@odata.type", result);
                JsonAssert.PropertyEquals("2", "Id", result);
            }
            else
            {
                // minimal metadata & "application/json"
                var actualContextUrl = result["@odata.context"].ToString();
                ODataUrlAssert.UrlEquals(expectedContextUrl, actualContextUrl, BaseAddress);
                JsonAssert.DoesNotContainProperty("@odata.type", result);
            }
        }

        [Theory]
        [PropertyData("AllAcceptHeaders")]
        public void AlwaysAvailableActionsGetAdvertisedForDerivedTypesOnFullMetadataOnly(string acceptHeader)
        {
            //Arrange
            string requestUrl = BaseAddress.ToLowerInvariant() + "/Actions/BaseEntity(9)/";

            string expectedTargetUrl = BaseAddress.ToLowerInvariant() + "/Actions/BaseEntity(9)/Default.AlwaysAvailableActionBaseType";
            string expectedAlwaysAvailableActionName = "AlwaysAvailableActionBaseType";
            string expectedAlwaysAvailableActionContainer = "#Default." + expectedAlwaysAvailableActionName;

            string expectedDerivedTypeTargetUrl = BaseAddress.ToLowerInvariant() + "/Actions/BaseEntity(9)/WebStack.QA.Test.OData.Formatter.JsonLight.Metadata.Model.DerivedEntity/Default.AlwaysAvailableActionDerivedType";
            string expectedAlwaysAvailableDerivedTypeActionName = "AlwaysAvailableActionDerivedType";
            string expectedAlwaysAvailableDerivedTypeActionContainer = "#Default." + expectedAlwaysAvailableDerivedTypeActionName;
            string expectedContextUrl = BaseAddress.ToLowerInvariant() + "/Actions/$metadata#BaseEntity/WebStack.QA.Test.OData.Formatter.JsonLight.Metadata.Model.DerivedEntity/$entity";
            JObject container;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.SetAcceptHeader(acceptHeader);

            //Act
            HttpResponseMessage response = Client.SendAsync(request).Result;
            JObject result = response.Content.ReadAsAsync<JObject>().Result;

            //Assert
            if (acceptHeader.Contains("odata.metadata=full"))
            {
                // full metadata
                JsonAssert.ContainsProperty(expectedAlwaysAvailableActionContainer, result);
                container = (JObject)result[expectedAlwaysAvailableActionContainer];
                JsonAssert.PropertyEquals(expectedTargetUrl, "target", container);
                JsonAssert.PropertyEquals(expectedAlwaysAvailableActionName, "title", container);

                JsonAssert.ContainsProperty(expectedAlwaysAvailableDerivedTypeActionContainer, result);
                container = (JObject)result[expectedAlwaysAvailableDerivedTypeActionContainer];
                JsonAssert.PropertyEquals(expectedDerivedTypeTargetUrl, "target", container);
                JsonAssert.PropertyEquals(expectedAlwaysAvailableDerivedTypeActionName, "title", container);

                JsonAssert.PropertyEquals(expectedContextUrl, "@odata.context", result);
                JsonAssert.PropertyEquals("#WebStack.QA.Test.OData.Formatter.JsonLight.Metadata.Model.DerivedEntity", "@odata.type", result);
            }
            else if (acceptHeader.Contains("odata.metadata=none"))
            {
                // none metadata
                JsonAssert.DoesNotContainProperty("@odata.context", result);
                JsonAssert.DoesNotContainProperty(expectedAlwaysAvailableActionContainer, result);
                JsonAssert.DoesNotContainProperty(expectedAlwaysAvailableDerivedTypeActionContainer, result);
            }
            else
            {
                // minimal metadata, "application/json" equal to "application/json;odata.metadata=minimal"
                JsonAssert.PropertyEquals(expectedContextUrl, "@odata.context", result);
                JsonAssert.PropertyEquals("#WebStack.QA.Test.OData.Formatter.JsonLight.Metadata.Model.DerivedEntity", "@odata.type", result);

                JsonAssert.DoesNotContainProperty(expectedAlwaysAvailableActionContainer, result);
                JsonAssert.DoesNotContainProperty(expectedAlwaysAvailableDerivedTypeActionContainer, result);
            }
        }

        [Theory]
        [PropertyData("AllAcceptHeaders")]
        public async Task TransientActionsDontGetAdvertisedForDerivedTypesWhenTheyArentAvailable(string acceptHeader)
        {
            // Arrange
            string expectedTransientActionName = "TransientActionBaseType";
            string expectedTransientActionContainer = "#Default." + expectedTransientActionName;
            string expectedDerivedTypeTransientActionName = "TransientActionDerivedType";
            string expectedDerivedTypeTransientActionContainer = "#Default." + expectedDerivedTypeTransientActionName;

            // Act
            var requestUrl = BaseAddress.ToLowerInvariant() + "/Actions/BaseEntity(9)/";
            var response = await Client.GetWithAcceptAsync(requestUrl, acceptHeader);
            var result = await response.Content.ReadAsAsync<JObject>();

            // Assert
            if (acceptHeader.Contains("odata.metadata=full"))
            {
                JsonAssert.ContainsProperty(expectedTransientActionContainer, result);
                JsonAssert.ContainsProperty(expectedDerivedTypeTransientActionContainer, result);
            }
            else
            {
                JsonAssert.DoesNotContainProperty(expectedTransientActionContainer, result);
                JsonAssert.DoesNotContainProperty(expectedDerivedTypeTransientActionContainer, result);
            }
        }

        [Theory]
        [PropertyData("AllAcceptHeaders")]
        public async Task TransientActionsGetAdvertisedForDerivedTypesWhenTheyAreAvailable(string acceptHeader)
        {
            // Arrange
            string baseActionName = "TransientActionBaseType";
            string baseQualifiedActionName = "Default." + baseActionName;
            string baseContainerName = "#" + baseQualifiedActionName;
            string baseTargetUrl = BaseAddress + "/Actions/BaseEntity(8)/" + baseQualifiedActionName;

            string derivedActionName = "TransientActionDerivedType";
            string derivedQualifiedActionName = "Default." + derivedActionName;
            string derivedContainerName = "#" + derivedQualifiedActionName;
            string derviedTargetUrl = string.Format("{0}/Actions/BaseEntity(8)/{1}/{2}",
                BaseAddress, typeof(DerivedEntity).FullName, derivedQualifiedActionName);

            // Act
            var requestUrl = BaseAddress + "/Actions/BaseEntity(8)/";
            var response = await Client.GetWithAcceptAsync(requestUrl, acceptHeader);
            var result = await response.Content.ReadAsAsync<JObject>();

            // Assert
            JObject baseContainer = (JObject)result[baseContainerName];
            JObject derivedContainer = (JObject)result[derivedContainerName];
            if (acceptHeader.Contains("odata.metadata=full"))
            {
                var actualBaseTargetUrl = baseContainer["target"].ToString();
                ODataUrlAssert.UrlEquals(baseTargetUrl, actualBaseTargetUrl, BaseAddress);
                JsonAssert.PropertyEquals(baseActionName, "title", baseContainer);

                var actualDerivedTargetUrl = derivedContainer["target"].ToString();
                ODataUrlAssert.UrlEquals(derviedTargetUrl, actualDerivedTargetUrl, BaseAddress);
                JsonAssert.PropertyEquals(derivedActionName, "title", derivedContainer);
            }
            else
            {
                JsonAssert.Equals(null, baseContainer);

                JsonAssert.Equals(null, derivedContainer);
            }
        }
    }
}
