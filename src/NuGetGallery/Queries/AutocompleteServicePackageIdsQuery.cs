﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NuGetGallery.Configuration;
using NuGet.Services.Search.Client;

namespace NuGetGallery
{
    public class AutoCompleteServicePackageIdsQuery 
        : AutoCompleteServiceQuery, IAutoCompletePackageIdsQuery
    {
        public AutoCompleteServicePackageIdsQuery(IAppConfiguration configuration, AutoCompleteSearchClient autoCompleteSearchClient)
            : base(configuration, autoCompleteSearchClient)
        {
        }

        public async Task<IEnumerable<string>> Execute(
            string partialId, 
            bool? includePrerelease,
            string semVerLevel = null)
        {
            partialId = partialId ?? string.Empty;

            return await RunServiceQuery("take=30&q=" + Uri.EscapeUriString(partialId), includePrerelease, semVerLevel);
        }
    }
}