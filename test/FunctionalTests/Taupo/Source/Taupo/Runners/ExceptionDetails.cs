﻿//---------------------------------------------------------------------
// <copyright file="ExceptionDetails.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

namespace Microsoft.Test.Taupo.Runners
{
    using System;
    using System.Security;
#if !WIN8
    using System.Security.Permissions;
#endif
    using Microsoft.Test.Taupo.Common;

    /// <summary>
    /// Data captured from an exception caught during test execution for serialization.
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public class ExceptionDetails
    {
        /// <summary>
        /// Initializes a new instance of the ExceptionDetails class.
        /// </summary>
        /// <param name="ex">The exception</param>
#if !SILVERLIGHT
        [SecuritySafeCritical]
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        [AssertJustification("Some exceptions (such as SecurityExceptions) need elevated permissions to read all of their information.")]
#endif
        public ExceptionDetails(Exception ex)
        {
            this.ExceptionAsString = ex.ToString();
            this.ExceptionFullTypeName = ex.GetType().FullName;
            this.Message = ex.Message;
#if !SILVERLIGHT
            this.Source = ex.Source;
#endif
        }

        /// <summary>
        /// Gets a string representation of the exception
        /// </summary>
        public string ExceptionAsString { get; private set; }

        /// <summary>
        /// Gets the full Type name of the exception
        /// </summary>
        public string ExceptionFullTypeName { get; private set; }

        /// <summary>
        /// Gets a message describing the exception
        /// </summary>
        public string Message { get; private set; }

#if !SILVERLIGHT
        /// <summary>
        /// Gets the name of the application or object that caused the exception
        /// </summary>
        public string Source { get; private set; }
#endif
    }
}
