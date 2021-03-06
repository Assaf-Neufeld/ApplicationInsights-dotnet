﻿namespace Microsoft.ApplicationInsights.Extensibility.Implementation.External
{
    using System;
    using Microsoft.ApplicationInsights.Extensibility.Implementation.Platform;

    /// <summary>
    /// Additional implementation for ExceptionDetails.
    /// </summary>
#if UTC
    [Microsoft.Diagnostics.Tracing.EventData]
#endif
    internal partial class ExceptionDetails
    {
        /// <summary>
        /// Creates a new instance of ExceptionDetails from a System.Exception and a parent ExceptionDetails.
        /// </summary>
        internal static ExceptionDetails CreateWithoutStackInfo(Exception exception, ExceptionDetails parentExceptionDetails)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            var exceptionDetails = new External.ExceptionDetails()
            {
                id = exception.GetHashCode(),
                typeName = exception.GetType().FullName,
                message = exception.Message
            };

            if (parentExceptionDetails != null)
            {
                exceptionDetails.outerId = parentExceptionDetails.id;
            }

            return exceptionDetails;
        }
    }
}