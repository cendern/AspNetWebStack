﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.ObjectModel;

namespace System.Web.Http.OData.Query
{
    /// <summary>
    /// This class describes the validation settings for querying.
    /// </summary>
    public class ODataValidationSettings
    {
        private const int MinMaxSkip = 0;
        private const int MinMaxTop = 0;

        private AllowedArithmeticOperators _allowedArithmeticOperators;
        private AllowedFunctions _allowedFunctions;
        private AllowedLogicalOperators _allowedLogicalOperators;
        private AllowedQueryOptions _allowedQueryParameters;
        private Collection<string> _allowedOrderByProperties;
        private int? _maxSkip;
        private int? _maxTop;

        /// <summary>
        /// Instantiates a new instance of the <see cref="ODataValidationSettings"/> class
        /// and initializes the default settings.
        /// </summary>
        public ODataValidationSettings()
        {
            // default it to all the operators
            _allowedArithmeticOperators = AllowedArithmeticOperators.All;
            _allowedFunctions = AllowedFunctions.AllFunctions;
            _allowedLogicalOperators = AllowedLogicalOperators.All;
            _allowedQueryParameters = AllowedQueryOptions.Supported;
            _allowedOrderByProperties = new Collection<string>();
        }

        /// <summary>
        /// Gets or sets a list of allowed arithmetic operators including 'add', 'sub', 'mul', 'div', 'mod'.
        /// </summary>
        public AllowedArithmeticOperators AllowedArithmeticOperators
        {
            get
            {
                return _allowedArithmeticOperators;
            }
            set
            {
                if (value > AllowedArithmeticOperators.All || value < AllowedArithmeticOperators.None)
                {
                    throw Error.InvalidEnumArgument("value", (Int32)value, typeof(AllowedArithmeticOperators));
                }

                _allowedArithmeticOperators = value;
            }
        }

        /// <summary>
        /// Gets or sets a list of allowed functions used in the $filter query. 
        /// 
        /// The allowed functions include the following:
        /// 
        /// String related: substringof, endswith, startswith, length, indexof, substring, tolower, toupper, trim, concat
        ///
        /// e.g. ~/Customers?$filter=length(CompanyName) eq 19
        ///
        /// DateTime related: year, years, month, months, day, days, hour, hours, minute, minutes, second, seconds
        ///
        /// e.g. ~/Employees?$filter=year(BirthDate) eq 1971
        ///
        /// Math related: round, floor, ceiling
        ///
        /// Type related:isof, cast, 
        ///
        /// Collection related: any, all
        ///  
        /// </summary>
        public AllowedFunctions AllowedFunctions
        {
            get
            {
                return _allowedFunctions;
            }
            set
            {
                if (value > AllowedFunctions.AllFunctions || value < AllowedFunctions.None)
                {
                    throw Error.InvalidEnumArgument("value", (Int32)value, typeof(AllowedFunctions));
                }

                _allowedFunctions = value;
            }
        }

        /// <summary>
        /// Gets or sets a list of allowed logical operators such as 'eq', 'ne', 'gt', 'ge', 'lt', 'le', 'and', 'or', 'not'.
        /// </summary>
        public AllowedLogicalOperators AllowedLogicalOperators
        {
            get
            {
                return _allowedLogicalOperators;
            }
            set
            {
                if (value > AllowedLogicalOperators.All || value < AllowedLogicalOperators.None)
                {
                    throw Error.InvalidEnumArgument("value", (Int32)value, typeof(AllowedLogicalOperators));
                }

                _allowedLogicalOperators = value;
            }
        }

        /// <summary>
        /// Gets a list of properties one can orderby the result with. Note, by default this list is empty, 
        /// it actually means it can be ordered by any properties.
        /// 
        /// For example, having an empty collection means client can order the queryable result by any properties.  
        /// Adding "Name" to this list means we only allow queryable result to be ordered by Name property.
        /// </summary>
        public Collection<string> AllowedOrderByProperties
        {
            get
            {
                return _allowedOrderByProperties;
            }
        }

        /// <summary>
        /// Gets or sets the query parameters that are allowed inside query. The default is all query options, 
        /// including $filter, $skip, $top, $orderby, $expand, $select, $inlineCount, $format and $skipToken
        /// </summary>
        public AllowedQueryOptions AllowedQueryOptions
        {
            get
            {
                return _allowedQueryParameters;
            }
            set
            {
                if (value > AllowedQueryOptions.All || value < AllowedQueryOptions.None)
                {
                    throw Error.InvalidEnumArgument("value", (Int32)value, typeof(AllowedQueryOptions));
                }

                _allowedQueryParameters = value;
            }
        }

        /// <summary>
        /// Gets or sets the max value of $skip that a client can request.
        /// </summary>
        public int? MaxSkip
        {
            get
            {
                return _maxSkip;
            }
            set
            {
                if (value.HasValue && value < MinMaxSkip)
                {
                    throw Error.ArgumentMustBeGreaterThanOrEqualTo("value", value, MinMaxSkip);
                }

                _maxSkip = value;
            }
        }

        /// <summary>
        /// Gets or sets the max value of $top that a client can request.
        /// </summary>
        public int? MaxTop
        {
            get
            {
                return _maxTop;
            }
            set
            {
                if (value.HasValue && value < MinMaxTop)
                {
                    throw Error.ArgumentMustBeGreaterThanOrEqualTo("value", value, MinMaxTop);
                }

                _maxTop = value;
            }
        }
    }
}